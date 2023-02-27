using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{
    internal class Organization
    {
        public Post[] Workers { get; set; }
        public string NemeOrganization { get; set; }
        public decimal Budget { get; set; }
        public Organization (Post[] workers, string nemeOrganization, decimal budget)
        {
            Workers = workers;
            NemeOrganization = nemeOrganization;
            Budget = budget;
        }
        public void SalaryPayment()
        {
            foreach (Post worker in Workers)
            {
                if (worker.Worker != null)
                {
                    Budget -= worker.Salary;
                }               
            }
            Console.ForegroundColor = ConsoleColor.Red;           
            Console.WriteLine($"После начисления зарплаты Бюджет состовляет: {Budget}$");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void ProfitOrganization(ulong profit)
        {
            Budget += profit;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"После после зачисления средств Бюджет состовляет: {Budget}$");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void DismissWorker(string position)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int count = 0;
            foreach (Post worker in Workers)
            {
                if (worker.Position == position)
                {
                    worker.Worker = null;
                    new Employee().ReturnInfo(Workers, position);                   
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Такая должность отсуствует, создайте должность или введите коректную должность");
                Console.WriteLine();
                Console.WriteLine("Список должностей");
                foreach (Post worker in Workers)
                {
                    Console.WriteLine(worker.Position);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public void HireEmployee(string position, string secondName, string name)
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Post worker in Workers)
            {
                if (worker.Position == position)
                {
                    worker.Worker = new Employee(secondName, name);
                    new Employee().ReturnInfo(Workers, position);
                    Console.WriteLine("Сотрудник нанят");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Такая должность отсуствует, создайте должность или введите коректную должность");
                Console.WriteLine();
                Console.WriteLine("Список должностей");
                foreach (Post worker in Workers)
                {
                    Console.WriteLine(worker.Position);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

    }
    
}
