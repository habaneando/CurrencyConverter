namespace CurrencyConverter.Domain;

public interface IPaymentCalculatorService
{
    Task<Money> CalculateMonthlyPaymentAsync(Loan loan);
}
