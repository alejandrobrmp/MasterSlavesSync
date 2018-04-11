using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Models
{
    public class Queue<T>
    {
        public delegate void ItemAdded();
        public event ItemAdded OnItemAdded;

        private static object _lock = new object();
        private LinkedList<T> items = new LinkedList<T>();

        public int Count
        {
            get
            {
                int count = 0;
                lock(_lock)
                {
                    count = items.Count;
                }
                return count;
            }
        }

        public void AddItem(T item)
        {
            lock(_lock)
            {
                bool notify = !(items.Count == 0);
                items.AddLast(item);
                if (notify) OnItemAdded?.Invoke();
            }
        }

        public T GetNext()
        {
            T item;
            lock(_lock)
            {
                item = items.First();
                items.RemoveFirst();
            }
            return item;
        }

    }
}
