using System;
using System.Collections.Generic;

namespace KeyValueStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new MyDictionary();
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

    struct KeyValue
    {
        public readonly string key;
        public readonly object value;

        public KeyValue(string key, object value)
        {
            this.key = key;
            this.value = value;
        }

    }

    class MyDictionary
    {
        KeyValue[] arry = new KeyValue[10];
        int tracker = 0;

        public object this[string indexer]
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
                        arry[i] = new KeyValue(indexer, value);
                        return;
                    }
                }

                if (tracker < arry.Length)
                {
                    arry[tracker++] = new KeyValue(indexer, value);
                }
            }

        }

    }
}
