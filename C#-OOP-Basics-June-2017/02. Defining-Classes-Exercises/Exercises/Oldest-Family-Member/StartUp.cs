using System;

class StartUp
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(' ');
            family.AddMember(new Person(tokens[0], int.Parse(tokens[1])));
        }

        Console.WriteLine(family.GetOldestMember());

        var oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        var addMemberMethod = typeof(Family).GetMethod("AddMember");

        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }
    }
}
