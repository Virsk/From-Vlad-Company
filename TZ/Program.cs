using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post[] workers = new Post[0];
            Console.WriteLine("Укажите название организации");
            string nemeOrganization = Console.ReadLine();
            Console.WriteLine("Укажите начальный бюджет");
            decimal budget = 0;
            bool budgetChack = false;
            while (budgetChack == false)
            {
                budgetChack = Decimal.TryParse(Console.ReadLine(), out Decimal var);
                if (budgetChack == false)
                {
                    Console.WriteLine("Зарплата указана не коректно введите коректную сумму зарплаты");
                }
                else
                {
                    budget = var;
                }
            }

            Organization organization = new Organization(workers, nemeOrganization, budget);

            while (true)
            {
                Console.WriteLine("Введите операцию которую хотите совершить:");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Создать должность введите    'Создать'");
                Console.WriteLine("2. Получить информацию          'Информация'");
                Console.WriteLine("3. Начислить зарплату введите   'Зарплата'");
                Console.WriteLine("4. Внести средства за проэкт    'Средства'");
                Console.WriteLine("5. Уволить сотрудника           'Уволить'");
                Console.WriteLine("6. Нанять сотрудника            'Нанять'");
                Console.ResetColor();
                string operationSelection = Console.ReadLine();
                Console.WriteLine();

                if (operationSelection == "Создать")
                {
                    Console.WriteLine("Укажите имя нового сотрудника");
                    string name = Console.ReadLine();
                    Console.WriteLine("Укажите Фамилию нового сотрудника");
                    string secondName = Console.ReadLine();
                    Employee employee = new Employee(secondName, name);
                    Console.WriteLine("Укажите должность нового сотрудника");
                    string position = Console.ReadLine();
                    Console.WriteLine("Укажите зарплату нового сотрудника");

                    bool chackSalery = false;
                    int salery = 0;

                    while (chackSalery == false)
                    {
                        chackSalery = Int32.TryParse(Console.ReadLine(), out Int32 var);
                        if (chackSalery == false)
                        {
                            Console.WriteLine("Зарплата указана не коректно введите коректную сумму зарплаты");
                        }
                        else
                        {
                            salery = var;
                        }
                    }
                    Post post = new Post(employee, position, salery);
                    Post[] workers1 = new Post[workers.Length + 1];
                    for (int i = 0; i < workers.Length; i++)
                    {
                        workers1[i] = workers[i];
                    }
                    workers = workers1;
                    workers[workers.Length - 1] = post;
                    organization.Workers = workers;
                    Console.WriteLine();
                    Console.WriteLine($"Количество должностей в компании: {workers.Length}");
                    Console.WriteLine();
                    int count = 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (Post worker in workers)
                    {
                        Console.WriteLine($"{count}.{worker.Position}");
                        count++;
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }

                else if (operationSelection == "Информация")
                {
                    Console.WriteLine("Вывести информацию о конкретном сотруднике введите его должность");
                    Console.WriteLine();
                    Console.WriteLine("Вывести информацию о всех сотрудниках введите 'Все'");
                    string info = Console.ReadLine();
                    Console.WriteLine();
                    if(workers.Length > 0)
                    {
                        new Employee().ReturnInfo(workers, info);
                    }
                    else
                    {
                        Console.WriteLine("В вашей компании еще нет должностей создайте хотябы одну должность");
                    }
                    Console.WriteLine();

                }

                else if (operationSelection == "Зарплата")
                {
                    organization.SalaryPayment();
                }

                else if (operationSelection == "Средства")
                {
                    Console.WriteLine("Укважите сумму дохода с проэкта");
                    bool chackProfit = false;
                    ulong profit = 0;

                    while (chackProfit == false)
                    {
                        chackProfit = UInt64.TryParse(Console.ReadLine(), out UInt64 var);
                        if (chackProfit == false)
                        {
                            Console.WriteLine("Зарплата указана не коректно введите коректную сумму зарплаты");
                        }
                        else
                        {
                            profit = var;
                        }
                    }

                    organization.ProfitOrganization(profit);
                }
                else if (operationSelection == "Уволить")
                {
                    Console.WriteLine("Укажите должность сотрудника которого хотите уволить");
                    string dismissWorker = Console.ReadLine();
                    organization.DismissWorker(dismissWorker);
                }
                else if (operationSelection == "Нанять")
                {
                    Console.WriteLine("Укажите должности на которую хотите нанять сотрудника");
                    string hireEmployee = Console.ReadLine();
                    Console.WriteLine("Укажите имя сотрудника которого хотите нанять");
                    string name = Console.ReadLine();
                    Console.WriteLine("Укажите Фамилию сотрудника которого хотите нанять");
                    string secondame = Console.ReadLine();
                    organization.HireEmployee(hireEmployee, secondame, name);
                }
            }                           
        }
    }
}
