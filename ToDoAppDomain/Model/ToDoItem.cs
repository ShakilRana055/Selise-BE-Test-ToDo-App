using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppDomain.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int UserId { get; set; }
        public bool HasDone { get; set; }
    }
}
