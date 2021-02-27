using System.Collections.Generic;

namespace DataStructures
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        void Write(T value);
        T Read();
        bool IsEmpty {get;}
    }
    public class Buffer<T> : IBuffer<T>
    {
        Queue<T> _queue = Queue<T>();

        protected bool IsEmpty
        {
            get{ return _queue.Count == 0;}
        }
        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }
        public virtual T Read()
        {
            _queue.Dequeue();
        }
        public IEnumerable<T> GetEnumerator()
        {
            // return _queue.GetEmunerator(); // one option.
            foreach (var item in _queue)
            {
                // massage or filter etc data.
                yield return item; // yeild return is the magic C# syntax that will build the state machine to implement IEnumerator<T>.
            }
        }
        IEnumerable IEnumerable.GetEnumerator() // must use 'explicit interface implementation' here otherwise the method signatures will be the same.
        {
            return GetEnumerator(); // calls the GetEnumerator method above.
        }
    }

    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity=10)
        {
            _capacity = capacity;
        }
        public override void Write(T value)
        {
            base.Write(value);
            if (_queue.Count > _capacity)
            {
                _queue.Dequeue();
            }
        }
        public bool IsFull
        {
            get {return _queue.Count == _capacity;}
        }
    }
}
