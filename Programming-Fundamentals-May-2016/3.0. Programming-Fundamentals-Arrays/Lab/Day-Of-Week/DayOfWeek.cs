using System;

class DayOfWeek
{
    static void Main()
    {
        var days = new string[] { 
                       "Monday", 
                       "Tuesday", 
                       "Wednesday", 
                       "Thursday", 
                       "Friday", 
                       "Saturday", 
                       "Sunday"
                   };

        var chosenDay = int.Parse(Console.ReadLine());

        if (chosenDay >= 1 && chosenDay <= 7)
        {
            Console.WriteLine(days[chosenDay - 1]);
        }
        else
        {
            Console.WriteLine("Invalid Day!");
        }
    }
}