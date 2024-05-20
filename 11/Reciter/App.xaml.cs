using System.Windows;

namespace Reciter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Initialize the database
        DbBootstrapper.Bootstrap();

        // Show the main window
        var mainWindow = new MainWindow();
        mainWindow.Show();
    }
}