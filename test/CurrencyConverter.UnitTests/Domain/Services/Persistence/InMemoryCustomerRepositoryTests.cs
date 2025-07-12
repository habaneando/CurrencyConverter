namespace CurrencyConverter.UnitTests;

public class InMemoryCustomerRepositoryTests : BaseDomainTests<BaseDomainTestsFixture>
{
    public InMemoryCustomerRepositoryTests(BaseDomainTestsFixture fixture) : base(fixture){}

    [Theory]
    [MemberData(nameof(InMemoryCustomerRepositoryData.CustomerRepoGetById_GivenValidId_ShouldBeSuccess), MemberType = typeof(InMemoryCustomerRepositoryData))]
    public void CustomerRepoGetById_GivenValidId_ShouldBeSuccess(int customerId)
    {
        var customer = CustomerRepository.GetById(customerId);

        customer.ShouldNotBeNull();

        customer.Id.ShouldBe(customerId);
    }
}
