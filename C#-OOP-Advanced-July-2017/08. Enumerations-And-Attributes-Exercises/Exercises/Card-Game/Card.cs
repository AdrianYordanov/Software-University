using System;

public class Card : IComparable<Card>
{
    private readonly Rank rank;
    private readonly Suit suit;

    public Card(string rank, string suit)
    {
        Enum.TryParse(rank, out this.rank);
        Enum.TryParse(suit, out this.suit);
    }

    public int CardPower => (int)this.rank + (int)this.suit;

    public Rank Rank => this.rank;

    public Suit Suit => this.suit;

    public int CompareTo(Card other)
    {
        return this.CardPower.CompareTo(other.CardPower);
    }

    public override string ToString()
    {
        return $"Card name: {this.rank} of {this.suit}; Card power: {this.CardPower}";
    }
}