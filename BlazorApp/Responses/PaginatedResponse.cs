namespace BlazorApp.Responses;
public class PaginatedResponse : BaseResponse
{
	public int page { get; set; } = 1;
	public int pageSize { get; set; } = 10;
	public int total { get; set; }
}