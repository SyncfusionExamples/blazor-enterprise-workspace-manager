using EnterpriseWorkspaceManager.Models;

namespace EnterpriseWorkspaceManager.Services;

/// <summary>Left navigation tree data.</summary>
public class NavigationDataService
{
    public List<NavNode> Tree { get; } = new()
    {
        new() { Id = "home",       Text = "Start",            IconCss = "e-icons e-home",         ModuleKey = "home" },
        new() { Id = "dashboard",  Text = "Dashboard",        IconCss = "e-icons e-display",    ModuleKey = "dashboard" },
        new() { Id = "documents",  Text = "Documents",        IconCss = "e-icons e-folder-open",  ModuleKey = "documents",
                Children = new()
                {
                    new() { Id = "doc-pdf",     Text = "PDF Viewer",        IconCss = "e-icons e-organize-pdf",     ModuleKey = "documents" },
                    new() { Id = "doc-ss",      Text = "Spreadsheet",       IconCss = "e-icons e-table",        ModuleKey = "spreadsheet" }
                }
        },
        new() { Id = "projects",   Text = "Projects",         IconCss = "e-icons e-folder",       ModuleKey = "projects" },
        new() { Id = "employees",  Text = "Employees",        IconCss = "e-icons e-people",       ModuleKey = "employees" },
        new() { Id = "analytics",  Text = "Analytics",        IconCss = "e-icons e-chart",        ModuleKey = "analytics" }
    };
}
