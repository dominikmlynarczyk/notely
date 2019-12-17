using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

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
            builder.RegisterDbContext();
            builder.RegisterCommandHandlers();
            builder.RegisterRepositories();
            builder.RegisterServices();
            builder.RegisterMapper();

            var container = builder.Build();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}


