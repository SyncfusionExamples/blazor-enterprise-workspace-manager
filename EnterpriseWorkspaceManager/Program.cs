using EnterpriseWorkspaceManager;
using EnterpriseWorkspaceManager.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Register Syncfusion Blazor service
builder.Services.AddSyncfusionBlazor();

// Memory cache is required by Syncfusion Blazor PDF Viewer in WebAssembly
builder.Services.AddMemoryCache();

// Application services (mock data + UI state)
builder.Services.AddSingleton<WorkspaceStateService>();
builder.Services.AddSingleton<EmployeeDataService>();
builder.Services.AddSingleton<ProjectDataService>();
builder.Services.AddSingleton<AnalyticsDataService>();
builder.Services.AddSingleton<ActivityDataService>();
builder.Services.AddSingleton<NavigationDataService>();
builder.Services.AddSingleton<ToastService>();
await builder.Build().RunAsync();
