using System.Windows;

namespace AccountingInHousing
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Data.OpenDbContext();
            //base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            //Data.CloseDbContext();
            //base.OnExit(e);
        }
    }

}
