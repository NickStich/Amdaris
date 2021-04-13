using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo.Observer
{
    public class Publisher<T>

    {
        private List<ISubscriber<T>> _subscribers;
        public Publisher()
        {
            _subscribers = new List<ISubscriber<T>>();
        }
        public void AddSubscriber(ISubscriber<T> subscriber)
        {
            _subscribers.Add(subscriber);
        }
        public void Publish(T item)
        {
            _subscribers.ForEach(s => s.Notify(item));
        }
    }
}
