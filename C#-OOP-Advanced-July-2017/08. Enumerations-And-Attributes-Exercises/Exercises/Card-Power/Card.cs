using System;

public class Card
{
    private readonly Rank rank;
    private readonly Suit suit;

    public Card(string rank, string suit)
    {
        Enum.TryParse(rank, out this.rank);
        Enum.TryParse(suit, out this.suit);
    }

    public int CardPower => (int)this.rank + (int)this.suit;
}