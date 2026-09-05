using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalStudentsAsync();
        Task<int> GetTotalTeachersAsync();
        Task<int> GetTotalNotesAsync();
        Task<decimal> GetAverageNoteAsync();
    }
}
