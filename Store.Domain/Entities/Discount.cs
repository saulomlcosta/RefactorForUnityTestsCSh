﻿namespace Store.Domain.Entities;
public class Discount : Entity
{
    public decimal Amount { get; private set; }
    public DateTime ExpireDate { get; private set; }

    public bool Valid()
    {
        return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
    }

    public decimal Value()
    {
        if (Valid())
            return Amount;
        else
            return 0;
    }
}
