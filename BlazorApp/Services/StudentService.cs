using BlazorApp.Models;
using BlazorApp.Pages;
using BlazorApp.Responses;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
namespace BlazorApp.Services
{
	public class StudentService(HttpClient httpClient)
	{
		public async Task<HttpResponseMessage> CreateStudent(StudentModel student)
		{
			var jsonContent = new StringContent(
			   JsonConvert.SerializeObject(student),
			   Encoding.UTF8,
			   "application/json"
			);
			return await httpClient.PostAsync("Student/CreateStudent", jsonContent);
		}

		public async Task<HttpResponseMessage> EditStudent(Guid studentId, StudentModel student)
		{
			var jsonContent = new StringContent(
			   JsonConvert.SerializeObject(student),
			   Encoding.UTF8,
			   "application/json"
			);

			return await httpClient.PatchAsync($"Student/EditStudent?studentId={studentId}", jsonContent);
		}

		public async Task<HttpResponseMessage> DeleteStudent(Guid studentId)
		{
			return await httpClient.DeleteAsync($"Student/DeleteStudent?studentId={studentId}");
		}

		public async Task<PaginatedResponse> GetAllStudents(Guid? parentId, int page, int pageSize)
		{
			return await httpClient.GetFromJsonAsync<PaginatedResponse>($"Student/GetAllStudents?parentId={parentId}&page={page}&pageSize={pageSize}");
		}

		public async Task<BaseResponse> GetStudentById(Guid studentId)
		{
			return await httpClient.GetFromJsonAsync<BaseResponse>($"Student/GetStudentById?studentId={studentId}");
		}


	}
}
