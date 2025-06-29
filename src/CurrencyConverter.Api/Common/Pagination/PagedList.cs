namespace CurrencyConverter.Api;

public class PagedList<T> : IPagedList<T>
    where T : class
{
    public IList<T> Items { get; init; }

    public int PageSize { get; init; }

    public int TotalItems =>
        Items.Count;

    public int TotalPages =>
        (int)Math.Ceiling(Items.Count / (double)PageSize);

    public PagedList(IList<T> items, int pageSize = 10)
    {
        Items = items;

        if(pageSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");

        PageSize = pageSize;
    }

    public IList<T> GetItemsForPage(int pageIndex) =>
        (pageIndex < TotalPages)
            ? Items.Skip((pageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToList()
            : new List<T>();
}
