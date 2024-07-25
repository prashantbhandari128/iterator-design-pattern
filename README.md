## Iterator Design Pattern

The Iterator pattern is a behavioral design pattern that provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation. This pattern is especially useful for collections, such as lists or arrays, allowing for traversing through the elements in a uniform manner.

Here is an example of the Iterator pattern implemented in C#. In this example, we'll create a simple collection of numbers and an iterator to traverse through the collection.

### Step-by-Step Implementation:

**Step 1: Define the Iterator Interface: This interface declares methods for traversing through a collection.**

```CS
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}
```
**Step 2: Define the Aggregate Interface: This interface declares a method to create an iterator.**

```CS
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}
```
**Step 2: Implement the Concrete Iterator: This class implements the IIterator interface and maintains the current position in the traversal of the collection.**

```CS
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
```

**Step 3: Implement the Concrete Aggregate: This class implements the IAggregate interface and provides an implementation for creating an iterator.**

```CS
public class NumberCollection : IAggregate<int>
{
    private readonly List<int> _numbers = new List<int>();

    public void Add(int number) => _numbers.Add(number);

    public int Count => _numbers.Count;

    public int this[int index] => _numbers[index];

    public IIterator<int> CreateIterator() => new NumberIterator(this);
} 
```

**Step 4: Client Code: This is where the collection is created, populated, and iterated over.**

```CS
public class Program
{
    static void Main(string[] args)
    {
        // Create the collection and add some numbers
        NumberCollection collection = new NumberCollection();

        collection.Add(1);
        collection.Add(2);
        collection.Add(3);
        collection.Add(4);
        collection.Add(5);

        // Create an iterator for the collection
        IIterator<int> iterator = collection.CreateIterator();

        // Iterate through the collection
        Console.WriteLine("Iterating through the collection:");
        while (iterator.HasNext())
        {
            int number = iterator.Next();
            Console.WriteLine(number);
        }
        // Uncomment to see the exception when there are no more elements
        // Console.WriteLine(iterator.Next());
    }
}
```