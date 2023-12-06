using Project.Services;

namespace Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MysqlDataStore>();
            MainPage = new AppShell();
            
        }
    }
}
