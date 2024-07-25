using ItratorPattern.Iterator.Interface;
namespace ItratorPattern.Iterator
{
    public class NumberCollection : IAggregate<int>
    {
        private readonly List<int> _numbers = new List<int>();

        public void Add(int number) => _numbers.Add(number);

        public int Count => _numbers.Count;

        public int this[int index] => _numbers[index];

        public IIterator<int> CreateIterator() => new NumberIterator(this);
    } 
}
