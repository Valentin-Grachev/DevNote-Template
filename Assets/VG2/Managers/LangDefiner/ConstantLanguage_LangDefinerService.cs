using UnityEngine;


namespace VG2
{
    public class ConstantLanguage_LangDefinerService : LangDefinerService
    {
        [SerializeField] private Language _selectedLanguage;

        public override bool supported => true;

        public override Language GetLanguage() => _selectedLanguage;

        public override void Initialize() => InitCompleted();
    }
}




