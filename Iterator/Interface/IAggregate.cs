namespace ItratorPattern.Iterator.Interface
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}
