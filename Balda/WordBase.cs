using System;
using System.Collections.Generic;

namespace Balda
{
    [Serializable]
    public class WordBase
    {
        private HashSet<string> words;

        public WordBase()
        {
            words = new HashSet<string>();
        }

        public void Add(string word)
        {
            words.Add(word.ToUpper());
        }

        public bool Contains(string word)
        {
            return words.Contains(word.ToUpper());
        }
    }
}

