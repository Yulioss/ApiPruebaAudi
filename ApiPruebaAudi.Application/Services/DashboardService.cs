using ApiPruebaAudi.Application.Interfaces;
using ApiPruebaAudi.Domain.DTOs.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _repository;

    public DashboardService(
        IDashboardRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardDTO> GetDashboard()
    {
        var totalStudents =
            await _repository.GetTotalStudentsAsync();

        var totalTeachers =
            await _repository.GetTotalTeachersAsync();

        var totalNotes =
            await _repository.GetTotalNotesAsync();

        var averageNote =
            await _repository.GetAverageNoteAsync();

        return new DashboardDTO
        {
            TotalStudents = totalStudents,
            TotalTeachers = totalTeachers,
            TotalNotes = totalNotes,
            AverageNote = Math.Round(averageNote, 2)
        };
    }
}