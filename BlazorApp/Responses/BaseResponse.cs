namespace BlazorApp.Responses;
public class BaseResponse
{
	public string message { get; set; }
	public bool success { get; set; }
	public int statusCode { get; set; }
	public Object? data { get; set; }
	public List<string> errors { get; set; }
}
