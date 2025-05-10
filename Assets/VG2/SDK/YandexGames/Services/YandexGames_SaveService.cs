using System;
using System.Collections;
using UnityEngine;
using VG2.YandexGames;

namespace VG2
{
    public class YandexGames_SaveService : SaveService
    {
        private string _savesData = null;



        public override bool supported => 
            Environment.platform == Environment.Platform.WebGL && !Environment.editor;


        public override void SaveLocal(string data)
            => YG_Saves.SendSaves(data, null);



        public override string GetData() => _savesData;

        public override void Initialize()
        {
            StartCoroutine(SavesInitializing());
        }


        private IEnumerator SavesInitializing()
        {
            while (!YG_Saves.available)
            {
                yield return new WaitForSecondsRealtime(0.1f);
#if UNITY_WEBGL
                YG_Saves.InitializePlayer();
#endif

            }

            YG_Saves.RequestSaves((savesData) =>
            {
                _savesData = savesData;
                InitCompleted();
            });

            
        }

        
    }
}


