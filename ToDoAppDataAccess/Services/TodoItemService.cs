using Microsoft.EntityFrameworkCore;
using OnsiteDataAccess.AppDataContest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDataAccess.IServices;
using ToDoAppDomain.Model;

namespace ToDoAppDataAccess.Services
{
    public class TodoItemService : BaseService<ToDoItem>, ITodoItemService
    {
        private readonly AppDbContext appDbContext;

        public TodoItemService(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<ToDoItem>> GetTaskByUserId(int userId)
        {
            try
            {
                var result = await appDbContext.ToDoItems.Where(item => item.UserId == userId).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ToDoItem>> GetCompleteUncompleteStatus(bool hasDone)
        {
            try
            {
                var result = await appDbContext.ToDoItems.Where(item => item.HasDone == hasDone).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
