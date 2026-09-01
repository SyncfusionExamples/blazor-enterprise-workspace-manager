using EnterpriseWorkspaceManager.Models;

namespace EnterpriseWorkspaceManager.Services;

/// <summary>Recent activity feed for the dashboard widget.</summary>
public class ActivityDataService
{
    public List<ActivityItem> Recent { get; } = new()
    {
        new() { Id = "1", User = "Ada Patel",      Action = "closed deal",       Target = "Northwind Industries ($84k)", TimeAgo = "2 min ago",  IconCss = "e-icons e-check",        Accent = "success" },
        new() { Id = "2", User = "Diego Hassan",   Action = "opened ticket",     Target = "Spreadsheet export failing on Chrome", TimeAgo = "14 min ago", IconCss = "e-icons e-info",         Accent = "info" },
        new() { Id = "3", User = "Carmen Silva",   Action = "uploaded report",   Target = "Q4 Marketing Performance.pdf", TimeAgo = "37 min ago",  IconCss = "e-icons e-upload",       Accent = "primary" },
        new() { Id = "4", User = "Brian Nguyen",   Action = "merged PR #842",    Target = "Refactor auth flow → main", TimeAgo = "1 h ago",   IconCss = "e-icons e-branch",       Accent = "primary" },
        new() { Id = "5", User = "Elena Costa",    Action = "approved budget",   Target = "Data Platform FY26", TimeAgo = "2 h ago",            IconCss = "e-icons e-check",        Accent = "success" },
        new() { Id = "6", User = "System",         Action = "scheduled maintenance", Target = "Warehouse nodes · Sun 02:00 UTC", TimeAgo = "3 h ago",   IconCss = "e-icons e-clock",        Accent = "warning" },
        new() { Id = "7", User = "Farah Khan",     Action = "flagged risk",      Target = "ML Platform training pipeline", TimeAgo = "5 h ago",  IconCss = "e-icons e-warning",      Accent = "danger" },
        new() { Id = "8", User = "Hana Andersson", Action = "completed review",  Target = "iOS 4.2 release candidate", TimeAgo = "Yesterday",    IconCss = "e-icons e-check",        Accent = "success" }
    };

    public List<ProgressGoal> Goals { get; } = new()
    {
        new() { Label = "Quarterly Revenue", Value = 82, Color = "#0066CC", Unit = "%" },
        new() { Label = "Customer Satisfaction", Value = 94, Color = "#107C10", Unit = "%" },
        new() { Label = "Product Adoption",   Value = 67, Color = "#9A5C00", Unit = "%" },
        new() { Label = "Employee Engagement", Value = 73, Color = "#5C2D91", Unit = "%" }
    };

    public List<KpiMetric> Kpis { get; } = new()
    {
        new() { Id = "rev",  Title = "Revenue (YTD)",      Value = "2.84M",  Unit = "USD",  Change = "+18.4%", IsPositive = true,  IconCss = "e-icons e-dollar",        AccentColor = "primary", SparklineData = new() { 142,156,171,168,192,211,198,224,232,251,268,285 } },
        new() { Id = "cst",  Title = "Active Customers",   Value = "1,284",  Unit = "",     Change = "+6.2%",  IsPositive = true,  IconCss = "e-icons e-people",        AccentColor = "success", SparklineData = new() { 980,1010,1052,1089,1132,1170,1198,1224,1248,1262,1273,1284 } },
        new() { Id = "deal", Title = "Open Deals",         Value = "47",     Unit = "",     Change = "-3",     IsPositive = false, IconCss = "e-icons e-briefcase",     AccentColor = "warning", SparklineData = new() { 52,55,53,50,49,48,50,52,51,49,48,47 } },
        new() { Id = "sup",  Title = "Support Tickets",    Value = "12",     Unit = "open", Change = "-8",     IsPositive = true,  IconCss = "e-icons e-ticket",       AccentColor = "info",    SparklineData = new() { 28,31,26,24,22,19,21,18,17,15,14,12 } }
    };
}
