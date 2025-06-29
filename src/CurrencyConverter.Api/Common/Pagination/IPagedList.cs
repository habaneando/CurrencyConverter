namespace CurrencyConverter.Api;

public interface IPagedList<T>
{
    IList<T> Items { get; init; }

    int PageSize { get; init; }

    int TotalItems { get; }

    int TotalPages { get; }

    IList<T> GetItemsForPage(int pageIndex);
}
