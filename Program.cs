using ItratorPattern.Iterator.Interface;
using ItratorPattern.Iterator;

namespace ItratorPattern
{
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
}
