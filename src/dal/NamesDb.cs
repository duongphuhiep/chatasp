using System.Collections.Generic;

namespace Dal
{
    public class NamesDb
    {
        private readonly List<string> _store = new List<string>();
        
        public void Store(string name)
        {   
            _store.Add(name);
        }

        public string[] GetAll()
        {
            return _store.ToArray();
        }
    }
}
