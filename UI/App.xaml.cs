using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UI.Factories;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider? _serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceProvider = ServiceCollectionSingleton.GetInstance();

            var db = _serviceProvider.GetRequiredService<DddInPracticeContext>();

            db.Database.Migrate();       
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (_serviceProvider is not null) 
            {
                _serviceProvider.Dispose();
            }
        }
    }
}
