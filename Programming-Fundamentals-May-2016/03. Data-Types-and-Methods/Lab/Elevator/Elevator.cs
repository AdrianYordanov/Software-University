using System;

class Elevator
{
    static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        int elevatorCapacity = int.Parse(Console.ReadLine());
        int courses = (int)Math.Ceiling((double)numberOfPeople / elevatorCapacity);
        Console.WriteLine(courses);
    }
}