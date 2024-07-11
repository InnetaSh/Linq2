
//Напишите LINQ-запрос, который отбирает всех сотрудников, у которых есть хотя бы один проект с длительностью более 6 месяцев.
//Для этих сотрудников создайте новый список объектов, содержащих имя сотрудника, общее количество его проектов и список названий всех проектов,
//длительностью более 6 месяцев.

var EmployeeList = new List<Employee>
{
    new Employee("Alex",23000,"IT",new Dictionary<string, int>
                {
                    {"Проект1", 14},
                    {"Проект2", 4}
                }),
    new Employee("Tom",80000,"IT",new Dictionary<string, int>
                {
                    {"Проект1", 3},
                    {"Проект2", 7}
                }),
    new Employee("Sam",12000,"Marketing",new Dictionary<string, int>
                {
                    {"Проект1", 7}
                }),
    new Employee("Bob",141000,"IT",new Dictionary<string, int>
                {
                    {"Проект1", 2},
                }),
    new Employee("Anna",100000,"Marketing",new Dictionary<string, int>
                {
                    {"Проект1", 1},
                    {"Проект2", 7},
                    {"Проект3", 14}
                }),
};



var EmployeeListNew = EmployeeList.Where(emp => emp.Projects.Any(project => project.Value > 6)).
    Select(employee => new 
    {
                employee.Name,
                employee.Salary,
                employee.Department,
                TotalProjects = employee.Projects.Count,
                Projects = employee.Projects
                                        .Where(project => project.Value > 6)
                                        .ToDictionary(project => project.Key, project => project.Value)
            }).ToList();

foreach (var emp in EmployeeListNew)
{
    Console.WriteLine($"Сотрудник: {emp.Name}");
    foreach (var project in emp.Projects)
    {
        Console.WriteLine($"Проект: {project.Key},общее количество -{emp.Projects.Count}, длительность - {project.Value} месяцев");
    }
    Console.WriteLine();
}


public class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
    public string Department { get; set; }
    public Dictionary<string, int> Projects;

    public Employee(string name, int salary, string department, Dictionary<string, int> projects)
    {
        Name = name;
        Salary = salary;
        Department = department;
        Projects = projects;
    }
}