using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Hashcs
    {
        private int size = 255;
        private int step = 10;
        Dictionary<int, string> hashmap;

        public Hashcs()
        {
            hashmap = new Dictionary<int, string>(size);
        }

        public int F(int key)
        {
            return key % size;
        }

        public void Add(int key, string value)
        {
            int hash = F(key);
            for (int i = 0; i < size; i++)
            {
                int hashStep = hash + (i * step);
                if (hashStep > size)
                {
                    break;
                }
                if (!hashmap.ContainsKey(hashStep))
                {
                    hashmap.Add(hashStep, value);
                    break;
                }
            }
            
        }

        public string search(int key)
        {
            int hash = F(key);
            for (int i = 0; i < size; i++)
            {
                int hashStep = hash + (i * step);
                if (hashStep > size)
                {
                    return null;
                }
                if (hashmap.ContainsKey(hashStep))
                {
                    return hashmap[hashStep];
                }
            }
            return null;
        }
        // https://pikabu.ru/story/kheshtablitsa_hashtable_na_yazyike_c_5805617
        // https://razilov-code.ru/2018/11/02/binarytree-on-csharp-and-java/
    }
}
