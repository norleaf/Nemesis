using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGraph
{
    

    public static class Extensions
    {
        

        public static List<T> Shuffle<T>(this List<T> list )
        {
            var random = new Random();
            var tempList = new List<T>();
            while (list.Any())
            {
                T element = list[random.Next(list.Count())];
                tempList.Add(element);
                list.Remove(element);
            }
            list.AddRange(tempList);
            return list;
        }
        public static Queue<T> ShuffleQue<T>(this Queue<T> queue)
        {
            var list = queue.ToList();
            _ = list.Shuffle();
            queue.Clear();
            foreach (var item in list) 
                queue.Enqueue(item);
            return queue;
        }

        public static List<T> Insert<T>(this List<T> list, T element)
        {
            list.Add(element);
            return list;
        }

        public static List<T> InsertRange<T>(this List<T> list, IEnumerable<T> elements)
        {
            list.AddRange(elements);
            return list;
        }

        public static List<T> Add<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
            return list;
        }

        public static List<T> New<T>(this List<T> list)
        {
            return new List<T>();
        }

        public static List<T> StartList<T>(this T element)
        {
            List<T> list = new List<T>() { element };
            return list;
        }

        public static bool Not<T>(this object obj)
        {
            return !(obj is T);
        }

    }
}
