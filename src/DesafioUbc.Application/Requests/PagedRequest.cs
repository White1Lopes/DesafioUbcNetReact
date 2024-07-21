using DesafioUbc.Application.Helper;

namespace DesafioUbc.Application.Requests;

public abstract class PagedRequest : Request
{
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
}