using Infrastructure;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceProvider = new ServiceCollection()
                .AddInfrastructureServices("Server=localhost;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=True")
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DddInPracticeContext>();
                db.Database.Migrate();
            }
        }
    }

}
