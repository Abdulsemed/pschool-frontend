using BlazorApp.Models;

namespace BlazorApp.DTOs.StudentsDtos;
public class GetStudentDto
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public string Gender { get; set; }
	public ParentModel Parent { get; set; }
}
