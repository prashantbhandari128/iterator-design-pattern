using ItratorPattern.Iterator.Interface;

namespace ItratorPattern.Iterator
{
    public class NumberIterator : IIterator<int>
    {
        private readonly NumberCollection _collection;
        private int _position = 0;

        public NumberIterator(NumberCollection collection)
        {
            _collection = collection;
        }

        public bool HasNext() => _position < _collection.Count;

        public int Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more elements in the collection.");
            }
            return _collection[_position++];
        }
    }
}
