namespace ApiPruebaAudi.Domain.DTOs.Dashboard;

public class DashboardDTO
{
    public int TotalStudents { get; set; }
    public int TotalTeachers { get; set; }
    public int TotalNotes { get; set; }
    public decimal AverageNote { get; set; }
}