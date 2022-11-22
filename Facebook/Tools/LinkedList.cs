using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Tools
{
    public class LinkedList<T>
    {
        private class ListItem
        {
            public T Value;
            public ListItem Next;
        }

        private ListItem first = null;

        public void Add(T value)
        {
            ListItem item = new ListItem();
            item.Value = value;

            if (first == null)
            {
                first = item;
                return;
            }

            ListItem iterator = first;
            while(iterator.Next != null)
            {
                iterator = iterator.Next;
            }

            iterator.Next = item;
        }

        public T GetAt(int index)
        {
            int count = 0;
            ListItem iterator = first;
            while (count < index)
            {
                iterator = iterator.Next;
                count++;
            }

            return iterator.Value;
        }

        public int Count()
        {
            if (first == null)
            {
                return 0;
            }

            int count = 1;

            ListItem iterator = first;
            while (iterator.Next != null)
            {
                iterator = iterator.Next;
                count++;
            }

            return count;
        }

        public void RemoveAt(int index)
        {
            if (index == 0 && first.Next == null)
            {
                first = null;
            }
            else if (index == 0)
            {
                first = first.Next;
            }
            else
            {
                int count = 0;
                ListItem iterator = first;
                while (count < (index - 1))
                {
                    iterator = iterator.Next;
                    count++;
                }

                iterator.Next = iterator.Next.Next;
            }
        }
    }
}
