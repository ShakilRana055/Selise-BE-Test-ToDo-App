using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDomain.Model;

namespace ToDoAppDataAccess.IServices
{
    public interface ITodoItemService : IBaseService<ToDoItem>
    {
        Task<List<ToDoItem>> GetTaskByUserId(int userId);
        Task<List<ToDoItem>> GetCompleteUncompleteStatus(bool hasDone);
    }
}
