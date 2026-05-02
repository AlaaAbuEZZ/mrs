namespace Application.Services.RequestDetailService.DTOs
{
    public class GetRequestDetailDto
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string Location { get; set; }
        public string EmployeeNote { get; set; }
        public string TechnicianNote { get; set; }
        public string? PhotoURL { get; set; }
    }
}