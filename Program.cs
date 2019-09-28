using System;
using System.Collections.Generic;

namespace KeyValueStore
{
  
        struct KeyValue<T>
        {
            public readonly string key;
            public readonly T value;

            public KeyValue(string key, T value)
            {
                this.key = key;
                this.value = value;
            }

        }
    class MyDictionary<T>
    {
        KeyValue <T>[] arry = new KeyValue <T>[10];
        int tracker = 0;

        public T this[string indexer]
        {
            get
            {
                foreach (var item in arry)
                {
                    if (item.key == indexer)
                    {
                        return item.value;
                    }
                }

                throw new KeyNotFoundException();
            }

            set
            {
                for (int i = 0; i < arry.Length; i++)
                {
                    if (arry[i].key == indexer)
                    {
                        arry[i] = new KeyValue<T>(indexer, value);
                        return;
                    }
                }

                if (tracker < arry.Length)
                {
                    arry[tracker++] = new KeyValue<T>(indexer, value);
                }
            }

        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int> d = new MyDictionary<int>();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }
}
