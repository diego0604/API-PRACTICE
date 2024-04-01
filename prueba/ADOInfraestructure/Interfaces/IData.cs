
using System.Data;

namespace DataAccess.Interfaces
{
    public interface IData
    {
        Task<DataTable> ConsultAsync(string sql);
        
    }
}