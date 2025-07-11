﻿namespace CurrencyConverter.Domain;

public sealed record LoanTerm
{
    public int Months { get; }

    public int Years => Months / 12;

    private LoanTerm(int months)
    {
        Months = months;
    }

    public static LoanTerm Create(int months)
    {
        if (months <= 0)
            throw new LoanTermCreationException();

        return new LoanTerm(months);
    }
}
