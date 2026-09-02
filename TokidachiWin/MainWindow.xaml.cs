using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using TokidachiWin.Core;

namespace TokidachiWin;

public sealed partial class MainWindow : Window
{
    public DashboardViewModel ViewModel { get; } = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Refresh_Click(object sender, RoutedEventArgs args)
    {
        ViewModel.LoadFromCollector(AppContext.BaseDirectory + "collector-output.json");
    }
}

public sealed class DashboardViewModel
{
    public ObservableCollection<ProviderCard> Providers { get; } = new();

    public void LoadFromCollector(string path)
    {
        var document = new CollectorReader().Read(path);
        Providers.Clear();
        foreach (var provider in document.Providers.Values.Where(p => p.Configured))
            Providers.Add(provider);
    }
}
