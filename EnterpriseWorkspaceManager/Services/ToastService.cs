namespace EnterpriseWorkspaceManager.Services;

/// <summary>Single shared event-bus for toast notifications across components.</summary>
public class ToastService
{
    public event Action<ToastEvent>? OnShow;

    public void Show(string message,
                     string cssClass = "e-toast-info",
                     string iconCss = "e-info toast-icons")
        => OnShow?.Invoke(new ToastEvent(message, cssClass, iconCss));

    public void Success(string message)
        => Show(message, "e-toast-success", "e-success toast-icons");
    public void Info(string message)
        => Show(message, "e-toast-info", "e-info toast-icons");
    public void Warning(string message)
        => Show(message, "e-toast-warning", "e-warning toast-icons");
    public void Error(string message)
        => Show(message, "e-toast-danger", "e-error toast-icons");
}

public record ToastEvent(string Message, string CssClass, string IconCss);
