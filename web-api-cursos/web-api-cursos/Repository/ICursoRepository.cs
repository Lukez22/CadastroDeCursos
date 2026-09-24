using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_api_cursos.Repository
{
    internal interface ICursoRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> ReadAsync();
        Task<T> ReadAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
