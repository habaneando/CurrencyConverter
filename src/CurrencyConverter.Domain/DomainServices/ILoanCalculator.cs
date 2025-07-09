namespace CurrencyConverter.Domain;

public interface ILoanCalculator
{
    Money CalculateMonthlyPayment(Loan loan);
}
