using EnterpriseWorkspaceManager.Models;

namespace EnterpriseWorkspaceManager.Services;

/// <summary>Builds a hierarchical project tree and the tasks backing each project.</summary>
public class ProjectDataService
{
    public List<ProjectNode> Hierarchy { get; }
    public List<ProjectTask> Tasks { get; }
    public IReadOnlyDictionary<string, IReadOnlyList<ProjectTask>> TasksByProject { get; }

    public ProjectDataService()
    {
        Hierarchy = new List<ProjectNode>
        {
            new()
            {
                Id = "platform",
                Name = "Platform Engineering",
                Description = "Core infrastructure & developer tooling",
                Status = "On Track",
                Progress = 78,
                IconCss = "e-icons e-folder",
                Children =
                {
                    new() { Id = "platform-iam",    Name = "Identity & Access", Description = "SSO, RBAC, audit log",  Status = "On Track", Progress = 92, IconCss = "e-icons e-folder" },
                    new() { Id = "platform-build",  Name = "Build & Release",   Description = "CI/CD pipelines",       Status = "At Risk",  Progress = 64, IconCss = "e-icons e-folder" },
                    new() { Id = "platform-obs",    Name = "Observability",     Description = "Logs, metrics, traces", Status = "On Track", Progress = 71, IconCss = "e-icons e-folder" }
                }
            },
            new()
            {
                Id = "product",
                Name = "Product Suite",
                Description = "Customer-facing applications",
                Status = "On Track",
                Progress = 58,
                IconCss = "e-icons e-folder",
                Children =
                {
                    new() { Id = "product-web",    Name = "Web Client",  Description = "React + Blazor portal", Status = "On Track", Progress = 66, IconCss = "e-icons e-folder" },
                    new() { Id = "product-mobile", Name = "Mobile Apps", Description = "iOS & Android",          Status = "On Track", Progress = 47, IconCss = "e-icons e-folder" },
                    new() { Id = "product-api",    Name = "Public API",  Description = "Versioned REST + GraphQL", Status = "On Track", Progress = 73, IconCss = "e-icons e-folder" }
                }
            },
            new()
            {
                Id = "data",
                Name = "Data Platform",
                Description = "Warehouse, ML, governance",
                Status = "Delayed",
                Progress = 42,
                IconCss = "e-icons e-folder",
                Children =
                {
                    new() { Id = "data-warehouse", Name = "Warehouse Migration", Description = "On-prem to lakehouse",        Status = "Delayed", Progress = 38, IconCss = "e-icons e-folder" },
                    new() { Id = "data-ml",        Name = "ML Platform",         Description = "Feature store, training, deploy", Status = "At Risk", Progress = 51, IconCss = "e-icons e-folder" }
                }
            },
            new()
            {
                Id = "ops",
                Name = "Operations & Security",
                Description = "Compliance, support, IT",
                Status = "On Track",
                Progress = 81,
                IconCss = "e-icons e-folder",
                Children =
                {
                    new() { Id = "ops-soc2",    Name = "SOC 2 Type II",    Description = "Annual certification", Status = "On Track", Progress = 88, IconCss = "e-icons e-folder" },
                    new() { Id = "ops-support", Name = "Customer Support", Description = "Tier 1/2/3",            Status = "On Track", Progress = 75, IconCss = "e-icons e-folder" }
                }
            }
        };

        Tasks = BuildTasks();
        TasksByProject = BucketByProject(Tasks);
    }

    private static IReadOnlyDictionary<string, IReadOnlyList<ProjectTask>> BucketByProject(List<ProjectTask> tasks)
    {
        var bucket = new Dictionary<string, List<ProjectTask>>(StringComparer.Ordinal);
        for (int i = 0; i < tasks.Count; i++)
        {
            var t = tasks[i];
            if (!bucket.TryGetValue(t.ProjectId, out var list))
            {
                list = new List<ProjectTask>(4);
                bucket[t.ProjectId] = list;
            }
            list.Add(t);
        }
        var ro = new Dictionary<string, IReadOnlyList<ProjectTask>>(bucket.Count, StringComparer.Ordinal);
        foreach (var kv in bucket) ro[kv.Key] = kv.Value;
        return ro;
    }

    private static List<ProjectTask> BuildTasks()
    {
        var rnd = new Random(7);
        var priorities = new[] { "High", "Medium", "Low" };
        var statuses = new[] { "Pending", "In Progress", "Review", "Blocked", "Done" };
        var assignees = new[]
        {
            "Ada Patel", "Brian Nguyen", "Carmen Silva", "Diego Hassan",
            "Elena Costa", "Farah Khan", "Gabriel Kowalski", "Hana Andersson"
        };

        var allProjectIds = new[] { "platform-iam", "platform-build", "platform-obs",
                                    "product-web", "product-mobile", "product-api",
                                    "data-warehouse", "data-ml",
                                    "ops-soc2", "ops-support" };

        var taskNames = new[]
        {
            "Design wireframes", "Set up CI pipeline", "Write integration tests",
            "Refactor authentication flow", "Update API documentation",
            "Performance benchmarking", "Security review", "Roll out to staging",
            "Customer feedback analysis", "Migrate to new SDK", "On-call rotation update",
            "Quarterly OKR review", "Spike on caching layer", "Penetration test follow-up"
        };

        var list = new List<ProjectTask>();
        int id = 1;
        foreach (var pid in allProjectIds)
        {
            int n = rnd.Next(4, 8);
            for (int i = 0; i < n; i++)
            {
                list.Add(new ProjectTask
                {
                    Id = id++,
                    ProjectId = pid,
                    TaskName = taskNames[rnd.Next(taskNames.Length)],
                    Assignee = assignees[rnd.Next(assignees.Length)],
                    DueDate = DateTime.Today.AddDays(rnd.Next(-5, 60)),
                    Priority = priorities[rnd.Next(priorities.Length)],
                    Status = statuses[rnd.Next(statuses.Length)],
                    Progress = rnd.Next(0, 101)
                });
            }
        }
        return list;
    }
}
