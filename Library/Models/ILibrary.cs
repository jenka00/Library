using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public interface ILibrary<T>
    {
        IEnumerable<T> GetAll { get; }
        T GetSingle(int id);
        T Add(T newEntity);
        T Update(T Entity);
        T Delete(int id);
    }
}
