namespace CurrencyConverter.Api;

public interface IPagedList<T>
    where T : class
{
    IList<T> Items { get; init; }

    int PageSize { get; init; }

    int TotalItems { get; }

    int TotalPages { get; }

    IList<T> GetItemsForPage(int pageIndex);
}
