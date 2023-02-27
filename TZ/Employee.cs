using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{
    internal class Employee
    {
        string secondName;
        string name;
        public Employee()
        { }
        public Employee(string secondName, string name)
        {
            this.secondName = secondName;
            this.name = name;
        }
        public void ReturnInfo(Post[] workers, string position)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int count = 0;
            foreach (Post worker in workers)
            {
                if (position == "Все" || position == worker.Position)
                {
                    if(worker.Worker == null)
                    {
                        Console.WriteLine($"Должность: {worker.Position}");
                        Console.WriteLine("Имя : Уволен");
                        Console.WriteLine("Фамилия : Воровал");
                        Console.WriteLine($"Зарплата :{worker.Salary}");
                        Console.WriteLine("--------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"Должность: {worker.Position}");
                        Console.WriteLine($"Имя : {worker.Worker.name}");
                        Console.WriteLine($"Фамилия :{worker.Worker.secondName}");
                        Console.WriteLine($"Зарплата :{worker.Salary}");
                        Console.WriteLine("--------------------------");
                    }
                    count++;
                }               
                Console.WriteLine();
            }
            if (count == 0)
            {
                Console.WriteLine("Такая должность отсуствует, создайте должность или введите коректную должность");
                Console.WriteLine();
                Console.WriteLine("Список должностей:");
                int count1 = 1;
                foreach (Post worker in workers)
                {
                    Console.WriteLine($"{count1}.{worker.Position}");
                    count++;
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}