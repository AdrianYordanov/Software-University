using System;
using System.Linq;

[Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    private int agility;
    private int maxDamage;
    private int minDamage;
    private Rarity rarity;
    private IBaseGem[] sockets;
    private int strength;
    private int vitality;
    private string weaponName;
    private WeaponType weaponType;

    protected Weapon(string weaponType, string rarity, string name)
    {
        this.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
        this.Rarity = (Rarity)Enum.Parse(typeof(Rarity), rarity);
        this.WeaponName = name;
    }

    public int Agility
    {
        get => this.agility;
        protected set => this.agility = value;
    }

    public int MaxDamage
    {
        get => this.maxDamage;
        protected set => this.maxDamage = value;
    }

    public int MinDamage
    {
        get => this.minDamage;
        protected set => this.minDamage = value;
    }

    public Rarity Rarity
    {
        get => this.rarity;
        protected set => this.rarity = value;
    }

    public IBaseGem[] Sockets
    {
        get => this.sockets;
        protected set => this.sockets = value;
    }

    public int Strength
    {
        get => this.strength;
        protected set => this.strength = value;
    }

    public int Vitality
    {
        get => this.vitality;
        protected set => this.vitality = value;
    }

    public string WeaponName
    {
        get => this.weaponName;
        protected set => this.weaponName = value;
    }

    public WeaponType WeaponType
    {
        get => this.weaponType;
        protected set => this.weaponType = value;
    }

    public void AddGem(int socketIndex, IBaseGem gem)
    {
        if (this.SocketExists(socketIndex))
        {
            this.Sockets[socketIndex] = gem;
        }
    }

    public void AddRarityBonuses()
    {
        this.MinDamage = (int)this.Rarity * this.MinDamage;
        this.MaxDamage = (int)this.Rarity * this.MaxDamage;
    }

    public void RemoveGem(int socketIndex)
    {
        if (this.SocketExists(socketIndex))
        {
            if (!this.SocketIsFree(socketIndex))
            {
                this.Sockets[socketIndex] = null;
            }
        }
    }

    public override string ToString()
    {
        var minimumDamage = this.MinDamage;
        var maximumDamage = this.MaxDamage;
        var strBonus = 0;
        var agiBonus = 0;
        var vitBonus = 0;
        foreach (var gem in this.Sockets.Where(s => s != null))
        {
            var bonus = gem.CalculateDamageBoost();
            minimumDamage += bonus.MinDamageBoost;
            maximumDamage += bonus.MaxDamageBoost;
            strBonus += gem.StrengthBonus;
            agiBonus += gem.AgilityBonus;
            vitBonus += gem.VitalityBonus;
        }

        return
            $"{this.WeaponName}: {minimumDamage}-{maximumDamage} Damage, +{strBonus} Strength, +{agiBonus} Agility, +{vitBonus} Vitality";
    }

    private bool SocketExists(int socketIndex)
    {
        if (socketIndex < 0 ||
            socketIndex > this.Sockets.Length - 1)
        {
            return false;
        }

        return true;
    }

    private bool SocketIsFree(int socketIndex)
    {
        return this.Sockets[socketIndex] is null;
    }
}