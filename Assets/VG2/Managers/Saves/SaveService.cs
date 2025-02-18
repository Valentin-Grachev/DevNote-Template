using System;
using VG2.Internal;

namespace VG2
{
    public abstract class SaveService : Service
    {
        public abstract string GetData();
        public abstract void Commit(string data, Action<bool> onCommited);


    }
}


