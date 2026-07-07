using System;

public enum Currency
{
    USD,
    EUR,
    GBP
}

public interface IPlayer
{
    int Id { get; }
    string Name { get; }
    int Score { get; }
}


public class Wallet
{

    public decimal Balance { get; private set; }
    public Currency Currency { get; }
    public bool IsBlocked { get; private set; }

    public Wallet(decimal balance, Currency currency)
	{
        if (Balance< 0)
        {
            throw new ArgumentException("Balance cannot be negative.");
        }
        
        isBlocked = false;
        Currency = currency;
        Balance = initialBalance;
	}
}

