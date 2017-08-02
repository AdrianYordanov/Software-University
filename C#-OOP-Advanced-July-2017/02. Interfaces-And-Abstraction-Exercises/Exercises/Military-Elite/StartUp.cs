using System;

public class StartUp
{
    private static void Main()
    {
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(' ');
            var commandName = tokens[0];
            var id = tokens[1];
            var firstName = tokens[2];
            var lastName = tokens[3];
            switch (commandName)
            {
                case "Private":
                {
                    var salary = double.Parse(tokens[4]);
                    DataContainer.AddSoldier(id, new Private(id, firstName, lastName, salary));
                    break;
                }

                case "LeutenantGeneral":
                {
                    var salary = double.Parse(tokens[4]);
                    var soldier = new LeutenantGeneral(id, firstName, lastName, salary);
                    for (var i = 5; i < tokens.Length; i++)
                    {
                        soldier.Privates.Add(tokens[i]);
                    }

                    DataContainer.AddSoldier(id, soldier);
                    break;
                }

                case "Engineer":
                {
                    var salary = double.Parse(tokens[4]);
                    var corps = tokens[5];
                    try
                    {
                        var soldier = new Engineer(id, firstName, lastName, salary, corps);
                        for (var i = 6; i < tokens.Length; i++)
                        {
                            var partName = tokens[i];
                            var workedHours = int.Parse(tokens[++i]);
                            soldier.Repairs.Add(new Repair(partName, workedHours));
                        }

                        DataContainer.AddSoldier(id, soldier);
                    }
                    catch (ArgumentException)
                    {
                        // Skip the command.
                    }

                    break;
                }

                case "Commando":
                {
                    var salary = double.Parse(tokens[4]);
                    var corps = tokens[5];
                    try
                    {
                        var soldier = new Commando(id, firstName, lastName, salary, corps);
                        for (var i = 6; i < tokens.Length; i++)
                        {
                            var codeName = tokens[i];
                            var missionState = tokens[++i];
                            if (missionState == "inProgress" || missionState == "Finished")
                            {
                                soldier.Missions.Add(new Mission(codeName, missionState));
                            }
                        }

                        DataContainer.AddSoldier(id, soldier);
                    }
                    catch (ArgumentException)
                    {
                        // Skip the command.
                    }

                    break;
                }

                case "Spy":
                {
                    var codeNumber = int.Parse(tokens[4]);
                    DataContainer.AddSoldier(id, new Spy(id, firstName, lastName, codeNumber));
                    break;
                }
            }
        }

        foreach (var soldier in DataContainer.Soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}