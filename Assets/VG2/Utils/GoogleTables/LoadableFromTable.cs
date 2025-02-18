using System.Collections.Generic;
using UnityEngine;


namespace VG2
{
    public abstract class LoadableFromTable : ScriptableObject
    {
        public abstract void LoadData(Dictionary<string, Table> allTables);

}
}


