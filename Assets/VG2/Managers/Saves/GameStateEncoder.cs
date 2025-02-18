using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using UnityEngine;


namespace VG2
{
    public static class GameStateEncoder
    {
        public const char cellSeparator = '|';
        public const char keyValuePairSeparator = ';';


        public static Dictionary<string, string> Decode(string compressedData, bool useLogs)
        {
            if (compressedData == string.Empty) 
                return new Dictionary<string, string>();

            string originData = Decompress(compressedData);

            if (useLogs) Debug.Log($"[{nameof(GameStateEncoder)}] {originData}");

            if (originData == string.Empty) 
                return new Dictionary<string, string>();

            return ToDataDictionary(originData);
        }

        public static string Encode(Dictionary<string, string> originDataDictionary)
        {
            string originData = ToDataString(originDataDictionary);
            return Compress(originData);
        }




        private static Dictionary<string, string> ToDataDictionary(string data)
        {
            var result = new Dictionary<string, string>();
            var splitByCellData = data.Split(cellSeparator);

            for (int i = 0; i < splitByCellData.Length; i++)
            {
                var splitCell = splitByCellData[i].Split(keyValuePairSeparator);
                result.Add(splitCell[0], splitCell[1]);
            }

            return result;
        }

        private static string ToDataString(Dictionary<string, string> dataDictionary)
        {
            var result = string.Empty;

            int i = 0;
            foreach (var keyValue in dataDictionary)
            {
                result += $"{keyValue.Key}{keyValuePairSeparator}{keyValue.Value}";
                if (i != dataDictionary.Count - 1) result += cellSeparator;
                i++;
            }

            return result;
        }


        private static string Compress(string uncompressedString)
        {
            byte[] compressedBytes;

            using (var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(uncompressedString)))
            {
                using (var compressedStream = new MemoryStream())
                {
                    using (var compressorStream = new DeflateStream(compressedStream, 
                        System.IO.Compression.CompressionLevel.Fastest, true))
                    {
                        uncompressedStream.CopyTo(compressorStream);
                    }
                    compressedBytes = compressedStream.ToArray();
                }
            }

            return Convert.ToBase64String(compressedBytes);
        }

        private static string Decompress(string compressedString)
        {
            try
            {
                byte[] decompressedBytes;

                var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString));
                using (var decompressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                {
                    using (var decompressedStream = new MemoryStream())
                    {
                        decompressorStream.CopyTo(decompressedStream);

                        decompressedBytes = decompressedStream.ToArray();
                    }
                }

                return Encoding.UTF8.GetString(decompressedBytes);
            }
            catch 
            {
                return string.Empty;
            }
        }




    }
}


