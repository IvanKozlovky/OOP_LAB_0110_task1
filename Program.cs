using System;
using System.Collections.Generic;
using System.Linq;

namespace CharSetOperations
{
    public class CharSet
    {
        private HashSet<char> _charSet;

        public CharSet()
        {
            _charSet = new HashSet<char>();
        }

        public CharSet(IEnumerable<char> chars)
        {
            _charSet = new HashSet<char>(chars);
        }

        public static CharSet operator +(CharSet set, char c)
        {
            set._charSet.Add(c);
            return set;
        }

        public static CharSet operator *(CharSet set1, CharSet set2)
        {
            return new CharSet(set1._charSet.Intersect(set2._charSet));
        }

        public int Cardinality()
        {
            return _charSet.Count;
        }

        public override string ToString()
        {
            return string.Join(", ", _charSet);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharSet set1 = new CharSet("abcde");
            CharSet set2 = new CharSet("cdefg");

            set1 += 'f';
            CharSet intersection = set1 * set2;

            Console.WriteLine($"Set 1: {{{set1}}}");
            Console.WriteLine($"Set 2: {{{set2}}}");
            Console.WriteLine($"Intersection: {{{intersection}}}");
            Console.WriteLine($"Cardinality of Set 1: {set1.Cardinality()}");
        }
    }
}
