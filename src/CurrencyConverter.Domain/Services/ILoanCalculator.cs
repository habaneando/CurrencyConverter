namespace CurrencyConverter.Domain;

public interface ILoanCalculator
{
    Task<Money> CalculateMonthlyPayment(Loan loan);
}
