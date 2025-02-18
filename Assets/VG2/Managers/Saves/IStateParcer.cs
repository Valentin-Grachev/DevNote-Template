using System.Collections.Generic;

namespace VG2
{
    public interface IStateParcer
    {

        public abstract void Parse(Dictionary<string, string> data);

        public void AddDataString(Dictionary<string, string> data);
    }
}


