using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class EmployeeBock
    {
        private List<Employee> employees = new()
        {
            new Employee("Погорелов Артём Денисович", 1, 46430.42),
            new Employee("Монтус Михаил Иванович", 2, 25335.42),
            new Employee("Дугин Даниил Романович", 2, 15355.42),
            new Employee("Реброва Светлана Вадимовна", 3, 25353.42),
            new Employee("Плетнёва Елизавета Дмитриевна", 3, 46362.42),
            new Employee("Клима Екатерина Михайловна", 1, 46346.42),
            new Employee("Ламтюгина Олеся Ивановна", 4, 36643.42),
            new Employee("Косых Иван Андреевич", 5, 25355.42),
            new Employee("Орехов Владислав Владиславович", 4, 23635.42),
            new Employee("Нерсесян Артур Родионович", 5, 23655.42)
        };
        public void EmployeeInfo() //1 - Получить список всех сотрудников со всеми имеющимся по ним данным
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio}, работающий в отделе " +
                    $"{emp.Department} получает зарплату в размере" +
                    $" {emp.Salary}");
            }
        }
        public void SalarySum() //2 - Посчитать сумму затрат на зарплаты в месяц
        {
            double sum = 0;
            foreach (Employee emp in employees)
            {
                sum += emp.Salary;
            }
            Console.WriteLine($"Сумма затрат на зарплаты в месяц: {sum}");

        }
        public void EmployeerMinSalary() //3 - Найти сотрудника с минимальной зарплатой
        {
            Console.WriteLine($"Человек с самой минимальной зарплатой {employees.Min(e => e.Salary + "рублей: " + e.Fio)} ");
        }
        public void EmployeerMaxSalary() //4 - Найти сотрудника с максимальной зарплатой
        {
            Console.WriteLine($"Человек с самой максимальной зарплатой {employees.Max(e => e.Salary + "рублей: " + e.Fio)} ");
        }
        public void SalaryAverage() //5 - Подсчитать среднее значение зарплат
        {
            Console.WriteLine($"Среднее значение зарплат: {employees.Average(e => e.Salary)}");
        }
        public void EmployeesFIO() //6 - Получить ФИО всех сотрудников
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ФИО сотрудника: {emp._id} {emp.Fio}");
            }

        }
        public void SalaryIndex() //7 - Проиндексировать зарплату
        {
            Console.WriteLine("Введите процент на который увеличится зарплата работников: ");
            double percent = double.Parse(Console.ReadLine());

            double salary;
            foreach (var emp in employees)
            {
                salary = emp.Salary + (emp.Salary / percent);

                Console.WriteLine($"Теперь зарплата сотрудника {emp.Fio} составляет: {salary} рублей");
            }

        }
        public void MinSalaryDeparment() //8 - Найти сотрудника с минимальной зарплатой в отделе
        {
            Console.WriteLine("Введите номер отдела: ");
            double dep_choice = Double.Parse(Console.ReadLine());

            var emp_in_dep = employees.Where(e => e.Department == dep_choice);
            if (emp_in_dep.Any())
            {
                var minsalary = emp_in_dep.OrderBy(e => e.Salary).First();
                Console.WriteLine($"В отделе номер {dep_choice} минимальная зп равна {minsalary.Salary} у сотрудника {minsalary.Fio}");
            }

        }

        public void MaxSalaryDepartment() //9 - Найти сотрудника с максимальной зарплатой в отделе
        {
            Console.WriteLine("Введите номер отдела: ");
            double dep_choice = Double.Parse(Console.ReadLine());

            var emp_in_dep = employees.Where(e => e.Department == dep_choice);
            if (emp_in_dep.Any())
            {
                var maxsalary = emp_in_dep.OrderBy(e => e.Salary).Last();

                Console.WriteLine($"В отделе номер {dep_choice} максимальная зп равна {maxsalary.Salary} у сотрудника {maxsalary.Fio}");
            }
        }
        public void AverageSalaryDepartment() // 10 - Средняя зарплата по отделу
        {
            Console.WriteLine("Введите номер отдела: ");
            double dep_choice = Double.Parse(Console.ReadLine());

            var emp_in_dep = employees.Where(e => e.Department == dep_choice);
            if (emp_in_dep.Any())
            {
                var averagesalary = emp_in_dep.Average(e => e.Salary);

                Console.WriteLine($"В отделе номер {dep_choice} средняя зп равна {averagesalary}");
            }
        }
        public void IndexSalaryDepartment() //11 - Проиндексировать зарплату сотрудников в отделе 
        {
            Console.WriteLine("Введите номер отдела: ");
            int dep_choice = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите процент, на который увеличится зарплата: ");
            int index = Int32.Parse(Console.ReadLine());
            foreach (var emp in employees)
            {
                if (emp.Department == dep_choice)
                {
                    emp.Salary += (emp.Salary / index);
                    Console.WriteLine($"Новая зарплата сотрудника - {emp.Fio} составляет: {emp.Salary} рублей");
                }
            }
        }
        public void EmployeesDepartmentINFO() //12 - Все сотрудники отдела 
        {
            Console.WriteLine("Введите номер отдела: ");
            int dep_choice = Int32.Parse(Console.ReadLine());
            foreach (var emp in employees)
            {
                if (emp.Department == dep_choice)
                {
                    Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio} получает зарплату в размере {emp.Salary}");
                }
            }
        }
        public void SalaryLessThanNumber() //13 - Все сотрудники отдела с зарплатой меньше числа
        {
            Console.WriteLine("Введите число:");
            double expected_salary = double.Parse(Console.ReadLine());

            foreach (var emp in employees)
            {
                if (emp.Salary < expected_salary)
                    Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio}, работающий в отделе " +
                        $"{emp.Department} получает зарплату в размере" +
                        $" {emp.Salary}");
            }
        }
        public void SalaryMoreThanNumber() //14 - Все сотрудники с зарплатой больше числа
        {
            Console.WriteLine("Введите число:");
            double expected_salary = double.Parse(Console.ReadLine());

            foreach (var emp in employees)
            {
                if (emp.Salary >= expected_salary)
                    Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio}, работающий в отделе " +
                        $"{emp.Department} получает зарплату в размере" +
                        $" {emp.Salary}");
            }
        }
        public void NewEmployee()
        {
            Console.WriteLine("Добавьте сотруднику ФИО: ");
            string FIO = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Добавьте сотруднику отдел: ");
            int DEP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Добавьте сотруднику зарплату: ");
            double SAL = Convert.ToDouble(Console.ReadLine());

            employees.Add(new Employee(fio: FIO, department: DEP, salary: SAL));
            Console.WriteLine($"Добавлен сотрудник - {FIO} в отдел {DEP} с зарплатой {SAL}");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Fio} {emp.Department} {emp.Salary}");
            }
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Выберите ID человека, которого хотите удалить: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            foreach (Employee emp in employees)
            {
                if (emp._id == ID)
                {
                    employees.Remove(emp);
                    break;
                }
            }

            if (employees.Count > 0)
            {
                Console.WriteLine("Список сотрудников после удаления:");
                foreach (Employee emp in employees)
                {
                    Console.WriteLine($"{emp._id}. {emp.Fio}, {emp.Department}, {emp.Salary} руб.");
                }
            }
            else
            {
                Console.WriteLine("Список сотрудников пуст.");
            }
        }
        public void NewSalaryAndDepartment()
        {
            Console.WriteLine("Выберите ID человека, которого хотите изменить: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите отдел, в котором будет работать этот человек");
            int newDep = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите зарплату, которую будет получать этот человек");
            double newSAl = Convert.ToDouble(Console.ReadLine());
            foreach (Employee emp in employees)
            {
                if (emp._id == ID)
                {
                    emp.Department = newDep;
                    emp.Salary = newSAl;
                    break;
                }
            }
            Console.WriteLine("Список сотрудников после изменения:");
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"{emp._id}. {emp.Fio}, {emp.Department}, {emp.Salary} руб.");
            }
        }
        public void EmployeesInDepartments()
        {
            var employeesByDepartment = employees.OrderBy(e => e.Department);
            foreach(var emp in employeesByDepartment)
            {
                Console.WriteLine($"Сотрудник из отдела {emp.Department} - {emp.Fio}");
            }
            
        }
    }
}
