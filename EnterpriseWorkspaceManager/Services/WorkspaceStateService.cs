using EnterpriseWorkspaceManager.Models;

namespace EnterpriseWorkspaceManager.Services;

/// <summary>
/// Owns the open MDI tab list and the active tab index.
///
/// Performance contract
/// --------------------
/// 1. <see cref="OpenTabs"/> is exposed as <see cref="IReadOnlyList{MdiTab}"/> so
///    consumers cannot mutate the backing list (mutations would otherwise
///    bypass <see cref="OnChange"/> and silently desync the UI).
/// 2. <see cref="ActiveIndex"/> setter is a no-op when the value hasn't changed,
///    so the host's two-way binding to <c>SelectedItem</c> doesn't trigger a
///    full re-render on every tab click that lands on the already-active tab.
/// 3. <see cref="SnapshotTabs"/> returns a copy the host can diff against on
///    the next render — when the snapshot is reference-equal to the previous
///    one, no work is needed.
/// </summary>
public class WorkspaceStateService
{
    private readonly List<MdiTab> _tabs = new()
    {
        new MdiTab
        {
            Key = "home",
            Title = "Start",
            IconCss = "e-icons e-home",
            IsHome = true,
            IsCloseable = false
        }
    };

    private int _activeIndex;

    public IReadOnlyList<MdiTab> OpenTabs => _tabs;

    public int ActiveIndex
    {
        get => _activeIndex;
        set
        {
            if (_activeIndex == value) return;
            _activeIndex = value;
            Notify();
        }
    }

    /// <summary>
    /// Spinner hook. The MDI host registers a callback here; any code
    /// path that needs the spinner (treeview node click, etc.) calls
    /// <see cref="TriggerShow"/>. The host owns show *and* hide timing.
    /// </summary>
    public Func<Task>? ShowSpinner { get; set; }

    public Task TriggerShow() => ShowSpinner?.Invoke() ?? Task.CompletedTask;

    public event Action? OnChange;

    public void OpenModule(string key, string title, string iconCss)
    {
        // Focus if already open. O(n) but n is the number of open tabs (≤ ~10).
        var existing = IndexOfKey(key);
        if (existing >= 0)
        {
            ActiveIndex = existing;
            return;
        }

        _tabs.Add(new MdiTab
        {
            Key = key,
            Title = title,
            IconCss = iconCss
        });
        ActiveIndex = _tabs.Count - 1;
    }

    public void CloseTab(string id)
    {
        var idx = IndexOfId(id);
        if (idx < 0) return;
        var tab = _tabs[idx];
        if (!tab.IsCloseable) return;

        _tabs.RemoveAt(idx);
        if (_activeIndex >= _tabs.Count) _activeIndex = _tabs.Count - 1;
        if (_activeIndex < 0) _activeIndex = 0;
        Notify();
    }

    public void Activate(string id)
    {
        var idx = IndexOfId(id);
        if (idx >= 0) ActiveIndex = idx;
    }

    /// <summary>Snapshot the tab list for diffing in the host.</summary>
    public IReadOnlyList<MdiTab> SnapshotTabs() => _tabs.ToArray();

    private int IndexOfKey(string key)
    {
        for (int i = 0; i < _tabs.Count; i++)
            if (_tabs[i].Key == key) return i;
        return -1;
    }

    private int IndexOfId(string id)
    {
        for (int i = 0; i < _tabs.Count; i++)
            if (_tabs[i].Id == id) return i;
        return -1;
    }

    private void Notify() => OnChange?.Invoke();
}
