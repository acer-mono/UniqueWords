using System;

namespace UniqueWords
{
    public class Word : IComparable<Word>
    {
        private readonly string _word;
        private int _amount;

        public Word(string word)
        {
            _word = word;
            _amount = 1;
        }

        public string Value => _word;

        public void Increment()
        {
            _amount++;
        }

        public override string ToString()
        {
            return $"{_word}\t{_amount}";
        }

        public int CompareTo(Word other)
        {
            if (ReferenceEquals(this, other)) return 0;
            return ReferenceEquals(null, other) ? 1 : _amount.CompareTo(other._amount);
        }
    }
}