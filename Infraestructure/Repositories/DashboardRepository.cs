using ApiPruebaAudi.Application.Interfaces;
using ApiPruebaAudi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _context;

    public DashboardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> GetTotalStudentsAsync()
    {
        return await _context.Students.CountAsync();
    }

    public async Task<int> GetTotalTeachersAsync()
    {
        return await _context.Teachers.CountAsync();
    }

    public async Task<int> GetTotalNotesAsync()
    {
        return await _context.Notes.CountAsync();
    }

    public async Task<decimal> GetAverageNoteAsync()
    {
        return await _context.Notes
            .Select(x => (decimal?)x.Value)
            .AverageAsync() ?? 0;
    }
}