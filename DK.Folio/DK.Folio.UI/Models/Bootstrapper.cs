using DK.Folio.Application;
using DK.Folio.UI.Interfaces;
using DK.Folio.UI.Services;
using DK.Folio.UI.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DK.Folio.UI.Models
{
    /// <summary>
    /// Prism Unity Boot Strap
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Build the module catalog from app.config.
        /// </summary>
        /// <returns>Module catalog</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        /// <summary>
        /// Override create shell.
        /// </summary>
        /// <returns>Created shell</returns>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// Set the shell as the main window and display.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// Register services to container.
        /// </summary>
        protected override void ConfigureContainer()
        {
            IEventAggregator eventAggregator = new EventAggregator();
            IMenuService menuService = new MenuService();
            IDialogService dialogService = new DialogService();
            ICursorService cursorservice = new CursorService();
            IFolioApplication folioService = new FolioApplication(Properties.Settings.Default.ApplicationDataFile);

            //IApplicationPropertiesService propertiesService = new ApplicationPropertiesService();
            //propertiesService.AddProperty("connectionString", Properties.Settings.Default.connectionString);
            //Container.RegisterInstance<IApplicationPropertiesService>(propertiesService);

            Container.RegisterInstance<IFolioApplication>(folioService);
            Container.RegisterInstance<IEventAggregator>(eventAggregator);
            Container.RegisterInstance<IMenuService>(menuService);
            Container.RegisterInstance<ICursorService>(cursorservice);
            Container.RegisterInstance<IDialogService>(dialogService);

            base.ConfigureContainer();
        }
    }
}
