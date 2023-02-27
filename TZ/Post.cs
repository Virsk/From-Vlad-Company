using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{
    internal class Post
    {
        public Employee Worker { get; set; }
        public string Position { get; set; }   
        public int Salary { get; set; } 

        public Post (Employee worker, string position, int salary)
        {
            Worker = worker; 
            Position = position; 
            Salary = salary;
        }
    }
}
