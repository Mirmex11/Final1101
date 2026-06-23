using System.IO;
using System.Windows;

namespace ReadCity.Desktop;

/// <summary>
/// Логика взаимодействия для приложения «Книжный мир».
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
        {
            File.WriteAllText("crash.log", ex.ExceptionObject.ToString());
        };
        DispatcherUnhandledException += (s, ex) =>
        {
            File.WriteAllText("crash_ui.log", ex.Exception.ToString());
            ex.Handled = true;
        };
        base.OnStartup(e);
    }
}
