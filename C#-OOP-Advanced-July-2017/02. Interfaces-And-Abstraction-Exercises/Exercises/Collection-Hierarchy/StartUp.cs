using System;

public class StartUp
{
    public static void Main()
    {
        IAddCollection addCollection = new AddCollection();
        IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        IMyList myList = new MyList();
        var input = Console.ReadLine().Split(' ');
        var removeCount = int.Parse(Console.ReadLine());
        var addCollectionResult = string.Empty;
        var addRemoveCollectionResult = string.Empty;
        var myListResult = string.Empty;
        foreach (var str in input)
        {
            addCollectionResult += addCollection.Add(str) + " ";
            addRemoveCollectionResult += addRemoveCollection.Add(str) + " ";
            myListResult += myList.Add(str) + " ";
        }

        Console.WriteLine(addCollectionResult);
        Console.WriteLine(addRemoveCollectionResult);
        Console.WriteLine(myListResult);
        addCollectionResult = string.Empty;
        addRemoveCollectionResult = string.Empty;
        myListResult = string.Empty;
        for (var i = 0; i < removeCount; i++)
        {
            addRemoveCollectionResult += addRemoveCollection.Remove() + " ";
            myListResult += myList.Remove() + " ";
        }

        Console.WriteLine(addRemoveCollectionResult);
        Console.WriteLine(myListResult);
    }
}