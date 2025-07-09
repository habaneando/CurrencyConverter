namespace CurrencyConverter.Domain;

// Stateless, complex domain rules that don’t belong to one entity
public class LoanCalculator(Money.Factory moneyFactory) : ILoanCalculator
{
    public Money CalculateMonthlyPayment(Loan loan)
    {
        //var monthlyRate = loan.AnnualInterestRate.MonthlyRate;
        //var numerator = loan.Principal.Amount * monthlyRate;
        //var denominator = 1 - Math.Pow(1 + (double)monthlyRate, -loan.Term.Months);
        //var monthlyPayment = (decimal)(numerator / denominator);

        return moneyFactory.Create(loan.Principal.Amount, "EUR");
    }
}
