namespace Application.Services.RequestDetailService.DTOs
{
    public class CreateRequestDetailDto
    {
        public Guid RequestId { get; set; }
        public string Location { get; set; }
        public string EmployeeNote { get; set; }
        public string? PhotoURL { get; set; }
    }
}