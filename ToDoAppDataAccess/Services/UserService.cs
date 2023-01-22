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
    public class UserService: BaseService<User>, IUserService
    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext): base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
