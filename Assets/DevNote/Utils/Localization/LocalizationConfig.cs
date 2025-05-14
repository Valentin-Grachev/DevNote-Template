using System.Collections.Generic;
using UnityEngine;


namespace DevNote
{
    [CreateAssetMenu(menuName = "DevNote/Localization", fileName = "Localization")]
    public class LocalizationConfig : LoadableFromTable
    {
        [field: SerializeField] public Language DefaultLanguage { get; private set; }
        [field: SerializeField] public List<Language> AvailableLanguages { get; private set; }
        [field: SerializeField] public List<Translation> Translations { get; private set; }


        public override void LoadData(Dictionary<TableKey, Table> tables)
        {
            Translations = new();

            foreach (var tableKey in Translation.TranslationTableKeys)
            {
                var table = tables[tableKey];

                for (int i = 2; i <= table.Rows; i++)
                {
                    var translation = new Translation();
                    translation.key = table.Get(row: i, column: 0);

                    translation.ru = table.Get(row: i, Column.B);
                    translation.en = table.Get(row: i, Column.C);
                    translation.tr = table.Get(row: i, Column.D);

                    Translations.Add(translation);
                }
            }
        }
    }
}



