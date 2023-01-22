using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDataAccess.IServices;

namespace ToDoAppDataAccess
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> Save();
        IUserService User { get; }
        ITodoItemService TodoItem { get; }
    }
}
