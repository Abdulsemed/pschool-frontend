using BlazorApp.DTOs.ParentDtos;
using BlazorApp.Models;
using BlazorApp.Responses;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorApp.Services;

public class ParentService(HttpClient httpClient)
{
	readonly string baseUrl = "https://localhost:7165/api";
	//
	public async Task<HttpResponseMessage> CreateParent(ParentModel parent)
	{
		var jsonContent = new StringContent(
		   JsonConvert.SerializeObject(parent),
		   Encoding.UTF8,
		   "application/json"
		);
		return await httpClient.PostAsync("Parent/CreateParent", jsonContent);
	}

	public async Task<HttpResponseMessage> Editparent(Guid parentId, EditParentDto parent)
	{
		var jsonContent = new StringContent(
		   JsonConvert.SerializeObject(parent),
		   Encoding.UTF8,
		   "application/json"
		);

		return await httpClient.PatchAsync($"Parent/EditParent?parentId={parentId}", jsonContent);
	}

	public async Task<HttpResponseMessage> Deleteparent(Guid parentId)
	{
		return await httpClient.DeleteAsync($"Parent/DeleteParent?parentId={parentId}");
	}

	public async Task<PaginatedResponse> GetAllparents(int page, int pageSize)
	{
		var response = await httpClient.GetFromJsonAsync<PaginatedResponse>($"Parent/GetAllParents?page={page}&pageSize={pageSize}");
		return response;

	}

	public async Task<BaseResponse> GetparentById(Guid parentId)
	{
		return await httpClient.GetFromJsonAsync<BaseResponse>($"Parent/GetParentById?parentId={parentId}");
	}
	public async Task<BaseResponse> SearchParentByName(string name)
	{
		return await httpClient.GetFromJsonAsync<BaseResponse>($"Parent/SearchParents?name={name}");
	}
}
