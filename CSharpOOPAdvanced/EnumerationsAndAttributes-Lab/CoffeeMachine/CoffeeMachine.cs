using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private List<CoffeeType> coffeesSold;
    private int coins;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeesSold;

    public void InsertCoin(string coin)
    {
        Coin result;
        Enum.TryParse(coin, out result);

        this.coins += (int)result;
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice resultSize;
        Enum.TryParse(size, out resultSize);

        CoffeeType resultType;
        Enum.TryParse(type, out resultType);

        if (this.coins >= (int)resultSize)
        {
            this.coffeesSold.Add(resultType);
            this.coins = 0;
        }
    }
}