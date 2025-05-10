using UnityEngine;
using NaughtyAttributes;
using System;

namespace VG2
{
    public class PlayerPrefs_SaveService : SaveService
    {
        [SerializeField] private bool _onlyEditor;


        public override bool supported => _onlyEditor ? Environment.editor : true;

        public override void SaveLocal(string data)
        {
            PlayerPrefs.SetString("data", data);
            PlayerPrefs.Save();
            //onCommited?.Invoke(true);
        }

        public override string GetData() => PlayerPrefs.GetString("data", string.Empty);

        public override void Initialize() => InitCompleted();

        [Button("Clear data")]
        private void ClearData() => PlayerPrefs.DeleteAll();

    }

}

