using DesafioUbc.Application.Helper;

namespace DesafioUbc.Application.Responses;

public class PagedResponse<T> : Response<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }

    public PagedResponse(T? data,
                         int totalCount,
                         int currentPage = 1,
                         int pageSize = Configuration.DefaultPageSize)
        : base(data)
    {
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public PagedResponse(T? data, bool isValid, string? message = null) : base(data, isValid, message)
    {
    }
}