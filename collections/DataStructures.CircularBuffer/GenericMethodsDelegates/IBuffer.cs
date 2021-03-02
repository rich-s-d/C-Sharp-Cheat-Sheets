namespace DataStructures
{
        public interface IBuffer<T> : IEnumerable<T> 
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();

        IEnumerable<TOutput> AsEnumerableOf<TOutput>(); // TOutput becomes a generic type parameter. T is already specified (IBuffer<T>)
    }
}