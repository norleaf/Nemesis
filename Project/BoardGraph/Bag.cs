using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public class Bag<T>
    {
        public List<T> Tokens { get; set; }
        private Random random;

        public Bag()
        {
            random = new Random();
            Tokens = new List<T>();
        }

        /// <summary>
        /// Removes a random item from the bag and returns it
        /// </summary>
        /// <returns></returns>
        public T Pick()
        {
            int i = random.Next(Tokens.Count());
            T token = Tokens[i];
            Tokens.RemoveAt(i);
            return token;
        }

        public void Put(T token)
        {
            Tokens.Add(token);
        }
    }
}
