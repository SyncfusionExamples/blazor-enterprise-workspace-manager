namespace EnterpriseWorkspaceManager.Models;

/// <summary>Employee record used by the SfGrid in the Employee Management module.</summary>
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string Title { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Status { get; set; } = "Active";
    public int PerformanceRating { get; set; }
}

/// <summary>Project hierarchy node used by the SfTreeView master and the SfGrid detail.</summary>
public class ProjectNode
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Active";
    public int Progress { get; set; }
    public string IconCss { get; set; } = "e-icons e-folder";
    public List<ProjectNode> Children { get; set; } = new();
}

/// <summary>Project task row used inside the detail grid.</summary>
public class ProjectTask
{
    public int Id { get; set; }
    public string ProjectId { get; set; } = string.Empty;
    public string TaskName { get; set; } = string.Empty;
    public string Assignee { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public string Priority { get; set; } = "Medium";
    public string Status { get; set; } = "Pending";
    public int Progress { get; set; }
}

/// <summary>KPI tile data for the Dashboard module.</summary>
public class KpiMetric
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string Change { get; set; } = string.Empty;
    public bool IsPositive { get; set; }
    public string IconCss { get; set; } = string.Empty;
    public string AccentColor { get; set; } = "primary";
    public List<double> SparklineData { get; set; } = new();
}

/// <summary>Revenue trend data point.</summary>
public class RevenuePoint
{
    public string Month { get; set; } = string.Empty;
    public double Revenue { get; set; }
    public double Expenses { get; set; }
    public double Profit { get; set; }
}

/// <summary>Pie/doughnut chart slice.</summary>
public class CategoryShare
{
    public string Category { get; set; } = string.Empty;
    public double Value { get; set; }
}

/// <summary>Quarterly bar chart data point.</summary>
public class QuarterlyMetric
{
    public string Quarter { get; set; } = string.Empty;
    public double Target { get; set; }
    public double Actual { get; set; }
}

/// <summary>Line chart growth series row.</summary>
public class GrowthPoint
{
    public string Year { get; set; } = string.Empty;
    public double Users { get; set; }
    public double Revenue { get; set; }
}

/// <summary>Recent activity row used by the SfListView on the dashboard.</summary>
public class ActivityItem
{
    public string Id { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public string TimeAgo { get; set; } = string.Empty;
    public string IconCss { get; set; } = string.Empty;
    public string Accent { get; set; } = "primary";
}

/// <summary>Progress goal item used on the dashboard.</summary>
public class ProgressGoal
{
    public string Label { get; set; } = string.Empty;
    public int Value { get; set; }
    public string Color { get; set; } = "#0066CC";
    public string Unit { get; set; } = "%";
}

/// <summary>Left navigation tree node.</summary>
public class NavNode
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string IconCss { get; set; } = string.Empty;
    public string ModuleKey { get; set; } = string.Empty;
    public List<NavNode> Children { get; set; } = new();
}

/// <summary>Open MDI tab descriptor.</summary>
public class MdiTab
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string IconCss { get; set; } = string.Empty;
    public bool IsHome { get; set; }
    public bool IsCloseable { get; set; } = true;
}
