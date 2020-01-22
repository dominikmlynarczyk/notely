using System;
using System.Configuration;
using System.Windows;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Notely.Infrastructure;

namespace Notely
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterDomainFactories();
            builder.RegisterDbContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            builder.RegisterCommandHandlers();
            builder.RegisterQueryHandlers();
            builder.RegisterRepositories();
            builder.RegisterServices();
            builder.RegisterMapper();
            builder.RegisterSession();
            builder.RegisterUserControls();

            var container = builder.Build();
            var context = container.Resolve<NotelyDbContext>();
            context.Database.Migrate();
            var window = container.Resolve<MainWindow>();
            try
            {
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}


