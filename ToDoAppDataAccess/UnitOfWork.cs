using OnsiteDataAccess;
using OnsiteDataAccess.AppDataContest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDataAccess.IServices;
using ToDoAppDataAccess.Services;

namespace ToDoAppDataAccess
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            context = appDbContext;
            User = new UserService(appDbContext);
            TodoItem = new TodoItemService(appDbContext);
        }

        #region Base Method
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.DisposeAsync();
        }

        #region Implementation
        public IUserService User { get; private set; }
        public ITodoItemService TodoItem { get; private set; }
        #endregion

        #endregion
    }
}
