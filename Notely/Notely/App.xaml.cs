using System;
using System.Configuration;
using System.Resources;
using System.Windows;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Notely.Infrastructure;
using Notely.SharedKernel.Exceptions;

namespace Notely
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public App()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["lang"]);
        }
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
            if (e.Exception is BusinessLogicException)
            {
                var resourceManager = new ResourceManager(new Notely.Properties.Resources().GetType());
                MessageBox.Show(resourceManager.GetString(e.Exception.Message), Notely.Properties.Resources.ErrorCaptionMessage, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(Notely.Properties.Resources.BaseErrorMessage, Notely.Properties.Resources.ErrorCaptionMessage, MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            e.Handled = true;
        }
    }
}


