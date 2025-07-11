namespace CurrencyConverter.Domain;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
}
