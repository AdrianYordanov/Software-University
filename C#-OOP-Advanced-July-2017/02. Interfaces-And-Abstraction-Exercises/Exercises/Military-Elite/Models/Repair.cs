public class Repair : IRepair
{
    private string partName;
    private int workedHours;

    public Repair(string partName, int workedHours)
    {
        this.PartName = partName;
        this.WorkedHourse = workedHours;
    }

    public string PartName
    {
        get => this.partName;
        private set => this.partName = value;
    }

    public int WorkedHourse
    {
        get => this.workedHours;
        private set => this.workedHours = value;
    }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.WorkedHourse}";
    }
}