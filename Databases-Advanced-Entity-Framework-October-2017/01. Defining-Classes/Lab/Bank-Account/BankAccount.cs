﻿public class BankAccount
{
    private int id;
    private double balance;

    // ReSharper disable once InconsistentNaming
    public int ID
    {
        get => this.id;
        set => this.id = value;
    }

    public double Balance
    {
        get => this.balance;
        set => this.balance = value;
    }
}