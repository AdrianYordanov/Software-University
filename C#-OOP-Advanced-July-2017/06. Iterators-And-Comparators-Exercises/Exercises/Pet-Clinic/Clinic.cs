using System;
using System.Linq;

public class Clinic
{
    private readonly Room[] rooms;
    private string name;

    public Clinic(string name, int roomCount)
    {
        this.CheckRoomCount(roomCount);
        this.Name = name;
        this.rooms = new Room[roomCount];
        this.InitializeRooms();
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public bool Add(Pet pet)
    {
        var centerId = (int)Math.Ceiling(this.rooms.Length / (double)2) - 1;
        if (!this.HasEmptyRooms())
        {
            return false;
        }

        var steps = 1;
        var i = centerId;
        for (var j = 0; j < this.rooms.Length; j++)
        {
            if (this.rooms[i].SickPet is null)
            {
                this.rooms[i].SickPet = pet;
                return true;
            }

            if (i >= centerId)
            {
                i = centerId - steps;
            }
            else
            {
                i = centerId + steps;
                steps++;
            }
        }

        return false;
    }

    public bool Release()
    {
        var centerId = (int)Math.Ceiling(this.rooms.Length / (double)2) - 1;
        for (var i = centerId; i < this.rooms.Length; i++)
        {
            if (this.rooms[i].SickPet != null)
            {
                this.rooms[i].SickPet = null;
                return true;
            }
        }

        for (var i = 0; i < centerId; i++)
        {
            if (this.rooms[i].SickPet != null)
            {
                this.rooms[i].SickPet = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Any(r => r.SickPet is null);
    }

    public void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine, this.rooms.ToList()));
    }

    public void Print(int roomId)
    {
        Console.WriteLine(this.rooms[roomId - 1].ToString());
    }

    private void CheckRoomCount(int roomsCount)
    {
        if (roomsCount % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        if (roomsCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(roomsCount));
        }
    }

    private void InitializeRooms()
    {
        for (var i = 0; i < this.rooms.Length; i++)
        {
            this.rooms[i] = new Room();
        }
    }
}