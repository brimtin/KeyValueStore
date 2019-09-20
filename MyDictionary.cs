using System.Collections.Generic;

namespace KeyValueStore
{
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
