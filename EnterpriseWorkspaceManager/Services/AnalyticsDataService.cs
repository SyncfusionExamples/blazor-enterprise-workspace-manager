using EnterpriseWorkspaceManager.Models;

namespace EnterpriseWorkspaceManager.Services;

/// <summary>Mock data for the Analytics module charts.</summary>
public class AnalyticsDataService
{
    public List<RevenuePoint> Revenue { get; } = new()
    {
        new() { Month = "Jan", Revenue = 142, Expenses = 98, Profit = 44 },
        new() { Month = "Feb", Revenue = 156, Expenses = 104, Profit = 52 },
        new() { Month = "Mar", Revenue = 171, Expenses = 110, Profit = 61 },
        new() { Month = "Apr", Revenue = 168, Expenses = 116, Profit = 52 },
        new() { Month = "May", Revenue = 192, Expenses = 121, Profit = 71 },
        new() { Month = "Jun", Revenue = 211, Expenses = 130, Profit = 81 },
        new() { Month = "Jul", Revenue = 198, Expenses = 128, Profit = 70 },
        new() { Month = "Aug", Revenue = 224, Expenses = 135, Profit = 89 },
        new() { Month = "Sep", Revenue = 232, Expenses = 138, Profit = 94 },
        new() { Month = "Oct", Revenue = 251, Expenses = 142, Profit = 109 },
        new() { Month = "Nov", Revenue = 268, Expenses = 150, Profit = 118 },
        new() { Month = "Dec", Revenue = 285, Expenses = 156, Profit = 129 }
    };

    public List<CategoryShare> RevenueByCategory { get; } = new()
    {
        new() { Category = "Enterprise SaaS", Value = 38 },
        new() { Category = "Professional Services", Value = 22 },
        new() { Category = "Support & Training", Value = 14 },
        new() { Category = "Marketplace", Value = 11 },
        new() { Category = "Hardware", Value = 9 },
        new() { Category = "Other", Value = 6 }
    };

    public List<QuarterlyMetric> Quarterly { get; } = new()
    {
        new() { Quarter = "Q1", Target = 480, Actual = 469 },
        new() { Quarter = "Q2", Target = 540, Actual = 571 },
        new() { Quarter = "Q3", Target = 600, Actual = 654 },
        new() { Quarter = "Q4", Target = 660, Actual = 720 }
    };

    public List<GrowthPoint> Growth { get; } = new()
    {
        new() { Year = "2021", Users = 12, Revenue = 4.2 },
        new() { Year = "2022", Users = 24, Revenue = 9.8 },
        new() { Year = "2023", Users = 41, Revenue = 18.4 },
        new() { Year = "2024", Users = 68, Revenue = 31.2 },
        new() { Year = "2025", Users = 102, Revenue = 49.7 },
        new() { Year = "2026", Users = 148, Revenue = 78.5 }
    };
}
