namespace CurrencyConverter.Domain;

public class PaymentCalculatorService(Money.Factory moneyFactory) : IPaymentCalculatorService
{
    public Task<Money> CalculateMonthlyPaymentAsync(Loan loan)
    {
        //var monthlyRate = loan.AnnualInterestRate.MonthlyRate;
        //var numerator = loan.Principal.Amount * monthlyRate;
        //var denominator = 1 - Math.Pow(1 + (double)monthlyRate, -loan.Term.Months);
        //var monthlyPayment = (decimal)(numerator / denominator);

        return moneyFactory.Create(loan.Amount, "EUR");
    }
}
