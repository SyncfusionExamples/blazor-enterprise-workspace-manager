using EnterpriseWorkspaceManager.Models;

namespace EnterpriseWorkspaceManager.Services;

/// <summary>Generates a deterministic mock employee dataset for the SfGrid demo.</summary>
public class EmployeeDataService
{
    public List<Employee> Employees { get; } = Build();

    public static List<Employee> Build()
    {
        var firstNames = new[]
        {
            "Ada", "Brian", "Carmen", "Diego", "Elena", "Farah", "Gabriel", "Hana",
            "Ishaan", "Júlia", "Kenji", "Lara", "Mateus", "Noor", "Omar", "Priya",
            "Quentin", "Riya", "Samuel", "Tomas", "Uma", "Victor", "Wei", "Xiomara",
            "Yara", "Zane", "Alina", "Bashir", "Chiamaka", "Dmitri"
        };
        var lastNames = new[]
        {
            "Patel", "Nguyen", "Khan", "Silva", "Hassan", "Costa", "Kowalski", "Andersson",
            "Tanaka", "Okafor", "Hernandez", "Schmidt", "Rossi", "Becker", "Lopez", "Müller",
            "Cohen", "Park", "Wong", "Reyes", "Ali", "Mendes", "Petrov", "Bianchi"
        };
        var titles = new[]
        {
            "Software Engineer", "Senior Software Engineer", "Product Manager", "UX Designer",
            "Data Analyst", "DevOps Engineer", "QA Lead", "Engineering Manager",
            "Solutions Architect", "Account Executive", "Marketing Lead", "Business Analyst"
        };
        var departments = new[]
        {
            "Engineering", "Product", "Design", "Data & Analytics", "Sales",
            "Marketing", "Customer Success", "Operations"
        };
        var locations = new[]
        {
            "New York, USA", "London, UK", "Berlin, DE", "Bengaluru, IN",
            "Tokyo, JP", "São Paulo, BR", "Sydney, AU", "Toronto, CA"
        };
        var statuses = new[] { "Active", "Active", "Active", "On Leave", "Active" };

        var list = new List<Employee>();
        var rnd = new Random(2026);
        for (int i = 1; i <= 48; i++)
        {
            var fn = firstNames[rnd.Next(firstNames.Length)];
            var ln = lastNames[rnd.Next(lastNames.Length)];
            list.Add(new Employee
            {
                Id = 1000 + i,
                FirstName = fn,
                LastName = ln,
                Title = titles[rnd.Next(titles.Length)],
                Department = departments[rnd.Next(departments.Length)],
                Email = $"{fn.ToLowerInvariant()}.{ln.ToLowerInvariant()}@enterprise.io",
                Phone = $"+1 (555) {rnd.Next(200, 999)}-{rnd.Next(1000, 9999)}",
                Location = locations[rnd.Next(locations.Length)],
                HireDate = DateTime.Today.AddDays(-rnd.Next(120, 3650)),
                Salary = Math.Round(55000m + (decimal)rnd.Next(0, 145000), 0),
                Status = statuses[rnd.Next(statuses.Length)],
                PerformanceRating = rnd.Next(2, 6)
            });
        }
        return list;
    }
}
