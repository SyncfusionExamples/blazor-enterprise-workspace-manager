# Enterprise Workspace Manager

A production-style **Blazor WebAssembly** sample that mimics a Windows MDI (Multiple Document Interface) shell, wired up end-to-end with the **Syncfusion Blazor 34.2.5** control suite on **.NET 10**.

It demonstrates how a real enterprise app composes 10+ Syncfusion controls in a single shell: tabbed MDI workspace, treeview navigation, command bar, dashboard, grid, chart, kanban-ready projects explorer, spreadsheet, PDF viewer, and analytics — all sharing one Fluent 2 themed layout, one state service, and one routing model.

---

## Quick start

```powershell
# 1. Restore + run
dotnet restore
dotnet run --project EnterpriseWorkspaceManager.csproj

# 2. Open the URL the launcher prints (usually https://localhost:5001)
```

Then, in the left **TreeView**:

1. Click `Start` — opens the home tab (non-closable).
2. Click `Modules ▸ Dashboard` — opens the SfDashboardLayout demo.
3. Click `Modules ▸ Employees` — opens the SfGrid with sort/filter/group/export.
4. Click `Modules ▸ Spreadsheet` — opens SfSpreadsheet with the full ribbon.
5. Click any other module — the existing tab is focused, not duplicated.

Or stay on the **Start** tab and click any of the `Open Dashboard` / `Employees` / `Analytics` quick-action buttons, or any of the six module tiles in the grid below. Both paths go through the same code path (`Workspace.OpenModule`) and the same spinner overlay.

---

## Project layout

```
EnterpriseWorkspaceManager/
├── App.razor                       ← router + Syncfusion theme <link>
├── Program.cs                      ← WASM host, DI, Syncfusion license
├── _Imports.razor                  ← global Syncfusion + project usings
├── EnterpriseWorkspaceManager.csproj
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor        ← grid shell, toast host, about dialog
│   │   ├── MainLayout.razor.css
│   │   ├── Sidebar.razor           ← SfTreeView navigation
│   │   ├── Sidebar.razor.css
│   │   ├── TopBar.razor            ← SfMenu command bar
│   │   ├── TopBar.razor.css
│   │   └── WorkspaceHost.razor     ← @page "/", SfTab MDI host + SfSpinner overlay
│   ├── Modules/
│   │   ├── DashboardModule.razor   ← SfDashboardLayout + SfAccumulationChart + SfChart + SfGrid
│   │   ├── EmployeesModule.razor   ← SfGrid (sort/filter/group/export/column chooser)
│   │   ├── DocumentsModule.razor   ← SfPdfViewer2
│   │   ├── SpreadsheetModule.razor ← SfSpreadsheet + SpreadsheetRibbon
│   │   ├── AnalyticsModule.razor   ← SfAccumulationChart + SfChart (column/spline)
│   │   └── ProjectsModule.razor    ← SfTreeView + SfGrid + SfProgressBar
│   └── Shared/
│       ├── StartPage.razor         ← home tab content (hero + 6 module tiles)
│       └── StartPage.razor.css
├── Models/Models.cs                ← Employee, ProjectNode, ProjectTask, MdiTab, NavNode, …
├── Services/
│   ├── WorkspaceStateService.cs    ← open tabs + active index + spinner hook
│   ├── EmployeeDataService.cs      ← 48-row deterministic mock dataset
│   ├── ProjectDataService.cs       ← project hierarchy + tasks
│   ├── AnalyticsDataService.cs     ← revenue / quarterly / growth series
│   ├── ActivityDataService.cs      ← dashboard KPIs / goals / activity feed
│   ├── NavigationDataService.cs    ← left TreeView data
│   └── ToastService.cs             ← shared toast event bus
└── wwwroot/
    ├── index.html                  ← Syncfusion theme <link> + CSS vars
    ├── favicon.png
    └── css/{app.css, tokens.css}
```

---


## Syncfusion controls in use

| Module | Controls |
|---|---|
| Shell | `SfTab`, `SfTreeView`, `SfMenu`, `SfToast`, `SfDialog`, **`SfSpinner`** |
| Dashboard | `SfDashboardLayout`, `SfAccumulationChart`, `SfChart`, `SfGrid` |
| Employees | `SfGrid` (sort, filter, group, export, column chooser) |
| Documents | `SfPdfViewer2` |
| Spreadsheet | `SfSpreadsheet` + `SpreadsheetRibbon` |
| Analytics | `SfAccumulationChart` + `SfChart` (column / spline / dual axis) |
| Projects | `SfTreeView` + `SfGrid` + `SfProgressBar` |

### NuGet package set (matched to actual usage)

The `.csproj` references **only** the Syncfusion packages the modules actually consume — Calendars / Lists / Sparkline are intentionally not pulled in:

- `Syncfusion.Blazor.Buttons`
- `Syncfusion.Blazor.Cards`
- `Syncfusion.Blazor.Charts`
- `Syncfusion.Blazor.Grid`
- `Syncfusion.Blazor.Layouts`
- `Syncfusion.Blazor.Navigations`
- `Syncfusion.Blazor.Notifications`
- `Syncfusion.Blazor.Popups`
- `Syncfusion.Blazor.ProgressBar`
- `Syncfusion.Blazor.SfPdfViewer`
- `Syncfusion.Blazor.Spreadsheet`
- `Syncfusion.Blazor.Themes`

---

## Prerequisites

- **.NET 10 SDK** (10.0.100+)
- **Visual Studio 2022 17.13+** or **VS Code** with the C# Dev Kit extension
- **Syncfusion Blazor license key** — set in `Program.cs` via `Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("...")` or an env var.

---

## Build & test

```powershell
dotnet build -c Release
dotnet run -c Release
```

There are no unit tests in this sample — the project is a UI showcase. Add `bUnit` tests under `EnterpriseWorkspaceManager.Tests/` if you want to assert on tab lifecycle / state transitions.

---

## License

Syncfusion Blazor is commercial software; use of the controls in this sample is governed by the Syncfusion Community License included with a qualifying individual / small-business subscription, or a paid Syncfusion license. The sample code in this repository is MIT-licensed — see [LICENSE](LICENSE) for the full text.

© 2026 Syncfusion, Inc. — All rights reserved.
