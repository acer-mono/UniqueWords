using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UniqueWords
{
    public class TextParser
    {
        private readonly List<Word> _words = new List<Word>();

        public void Parse(string input)
        {
            var regex = new Regex(@"(\w+)(-|')?(\w*)", RegexOptions.IgnoreCase);
            var words = regex.Matches(input);
            
            foreach (var matches in words)
            {
                var str = matches.ToString()?.ToUpper();
                
                AddWord(str);
            }
        }

        private void AddWord(string str)
        {
            var index = _words.FindIndex(w => w.Value.Equals(str));
            if (index != -1)
            {
                _words[index].Increment();
            }
            else
            {
                _words.Add(new Word(str));
            }
        }

        public override string ToString()
        {
            _words.Sort();
            _words.Reverse();
            return _words.Aggregate(string.Empty, (current, word) => 
                current + (word + Environment.NewLine));
        }
    }
}