using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Utils
{
    public static class Shuffler
    {
        static Random rand = new Random();
        public static void Shuffle<T>(List<T> list)
        {
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
        }

        public static void Shuffle<T>(T[] list)
        {
            for (int i = list.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
        }
        public static void ShuffleObj<T>(List<T> list) where T : ICloneable
        {
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = (T)list[j].Clone();
                list[j] = (T)list[i].Clone();
                list[i] = tmp;
            }
        }

        public static void ShuffleObj<T>(T[] list) where T : ICloneable
        {
            for (int i = list.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = (T)list[j].Clone();
                list[j] = (T)list[i].Clone();
                list[i] = tmp;
            }
        }
    }
}
