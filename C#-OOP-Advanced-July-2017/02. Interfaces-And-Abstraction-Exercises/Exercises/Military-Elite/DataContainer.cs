using System.Collections.Generic;
using System.Linq;

public static class DataContainer
{
    private static readonly Dictionary<string, ISoldier> DataSoldiers = new Dictionary<string, ISoldier>();

    public static IEnumerable<ISoldier> Soldiers => DataSoldiers.Values.AsEnumerable();

    public static void AddSoldier(string id, ISoldier soldier)
    {
        DataSoldiers.Add(id, soldier);
    }

    public static ISoldier GetSoldierById(string id)
    {
        var pair = DataSoldiers.First(soldier => soldier.Key == id);
        return pair.Value;
    }
}