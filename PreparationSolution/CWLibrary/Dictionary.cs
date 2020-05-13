using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWLibrary
{
    public class Dictionary : IEnumerable
    {

        /// <summary>
        /// Поле для свойства <see cref="Locale"/>.
        /// </summary>
        int locale;
        /// <summary>
        /// Определяет тип словаря.
        /// </summary>
        /// <remarks>
        /// Принимает значение 0, если словарь русско-английский, 
        /// и 1, если словарь англо-русский.
        /// Поле для данного свойства - <see cref="locale"/>.
        /// </remarks>
        public int Locale { get { return locale; } }
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        static Random rnd = new Random();


        List<Pair<string, string>> words;
        public List<Pair<string, string>> Words
        {
            get
            {
                List<Pair<string, string>> toReturn =
                    new List<Pair<string, string>>();
                foreach (Pair<string, string> word in words)
                    toReturn.Add(new Pair<string, string>(
                        word.Item1, word.Item2));
                return toReturn;
            }
        }

        public Dictionary()
        {
            locale = rnd.Next(0, 2);
            words = new List<Pair<string, string>>();
        }
        public Dictionary(List<Pair<string, string>> _words) : base()
        {
            if (_words is null)
                throw new ArgumentNullException(
                    "Поданный в качестве параметра список слов " +
                    "не должен быть null. ");
            words = _words;
            words.Sort((p1, p2) =>
            {
                int result;
                if ((result = p1.CompareTo(p2)) == 0)
                    return p1.Item2.CompareTo(p2.Item2);
                return result;
            });
        }

        public void Add(Pair<string, string> pairToAdd)
        {
            words.Add(new Pair<string, string>(
                pairToAdd.Item1, pairToAdd.Item2));
            words.FindIndex(p => (p.CompareTo(pairToAdd) == -1));
        }
        public void Add(string s1ToAdd, string s2ToAdd)
        {
            words.Add(new Pair<string, string>(
                s1ToAdd, s2ToAdd));
        }

        public IEnumerator GetEnumerator()
        {
            return words.GetEnumerator();
        }
        public IEnumerator MyEnumerator()
        {

        }
    }
}
