using DK.Folio.UI.Commands;
using DK.Folio.UI.Interfaces;
using DK.Folio.UI.Models;
using DK.Folio.UI.Views;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.ViewModels
{
    public class ShellViewModel
    {
         /// <summary>
        /// Application name
        /// </summary>
        private string productName;

        /// <summary>
        /// Application version
        /// </summary>
        private string productVersion;

        /// <summary>
        /// Event aggregator
        /// </summary>
        private IEventAggregator eventAggregator;

        /// <summary>
        /// Region manager
        /// </summary>
        private IRegionManager regionManager;

        /// <summary>
        /// Menu service
        /// </summary>
        private IMenuService menuService;

        /// <summary>
        /// Cursor service
        /// </summary>
        private ICursorService cursorService;

        /// <summary>
        /// Service to display about view
        /// </summary>
        //private IDisplayViewService displayAboutView;

        /// <summary>
        /// Module catalog
        /// </summary>
        private IModuleCatalog catalog;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">Event aggregator</param>
        /// <param name="regionManager">Region Manager</param>
        /// <param name="menuService">Menu service</param>
        /// <param name="cursorService">Cursor service</param>
        /// <param name="catalog">Module catalog</param>
        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMenuService menuService, ICursorService cursorService, IModuleCatalog catalog)
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            if (AssemblyTitleAttribute.IsDefined(assembly, typeof(AssemblyTitleAttribute)))
            {
                AssemblyTitleAttribute assemblyTitle = (AssemblyTitleAttribute)AssemblyTitleAttribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute));
                this.productName = assemblyTitle.Title;
            }

            if (AssemblyFileVersionAttribute.IsDefined(assembly, typeof(AssemblyFileVersionAttribute)))
            {
                AssemblyFileVersionAttribute assemblyVersion = (AssemblyFileVersionAttribute)AssemblyFileVersionAttribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute));
                this.productVersion = assemblyVersion.Version.Split('.')[0] + "." + assemblyVersion.Version.Split('.')[1];
            }

            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.menuService = menuService;
            this.cursorService = cursorService;
            this.catalog = catalog;
            //this.displayAboutView = new DisplayAboutViewService(this.catalog);

            ExitCommand exitCommand = this.eventAggregator.GetEvent<ExitCommand>();
            exitCommand.Subscribe(this.OnExitCommandReceived);

            // Set up menu headers
            FileMenu fileMenu = new FileMenu("File", "_File");
            AboutMenuItem aboutMenu = new AboutMenuItem("About", "_About");

            // Create menu items
            ExitMenuItem exitMenuItem = new ExitMenuItem("Exit", "E_xit", this.eventAggregator);
            //AboutSubMenuItem aboutMenuItem = new AboutSubMenuItem("AboutItem", "A_bout", this.displayAboutView);

            // Add top level menus
            menuService.AddParentMenuItem(fileMenu);
            menuService.AddParentMenuItem(aboutMenu);

            // Add child menu items
            menuService.AddChildMenuItem(exitMenuItem, "File");
            //menuService.AddChildMenuItem(aboutMenuItem, "About");

            // Navigate to region
            this.regionManager.RegisterViewWithRegion("MenubarRegion", typeof(MenuBar));
            this.regionManager.RegisterViewWithRegion("StatusbarRegion", typeof(StatusBar));
            this.regionManager.RegisterViewWithRegion("ToolBarRegion", typeof(ToolBar));
            //this.regionManager.RegisterViewWithRegion("ShellContentRegion", typeof(ConnectionView));

            this.eventAggregator.GetEvent<DisplayWaitCursorCommand>().Subscribe(this.ShowWaitCursor, true);
            this.eventAggregator.GetEvent<ClearScreenCommand>().Subscribe(this.ClearScreen, true);
        }
        
        /// <summary>
        /// Gets the application title
        /// </summary>
        public string Title
        {
            get
            {
                return this.productName + " " + this.productVersion;
            }
        }

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="exit">not used</param>
        public void OnExitCommandReceived(bool exit)
        {
            if (exit)
            {
                App.Current.Shutdown();
            }
        }

        /// <summary>
        /// Deactivate currently displayed views.
        /// </summary>
        /// <param name="clearScreen">Boolean not required</param>
        public void ClearScreen(bool clearScreen)
        {
            IRegion shellContentRegion = this.regionManager.Regions["ShellContentRegion"];

            foreach (object view in shellContentRegion.Views)
            {
                shellContentRegion.Deactivate(view);
            }
        }

        /// <summary>
        /// Show or reset wait cursor
        /// </summary>
        /// <param name="show">True to show, false to reset</param>
        private void ShowWaitCursor(bool show)
        {
            if (show)
            {
                this.cursorService.ShowWaitCursor();
            }
            else
            {
                this.cursorService.ResetCursor();
            }
        }
    }    
}
