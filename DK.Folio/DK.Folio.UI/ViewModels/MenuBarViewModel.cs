using DK.Folio.UI.Interfaces;
using DK.Folio.UI.Models;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.ViewModels
{
    /// <summary>
    /// View model for menu bar
    /// </summary>
    public class MenuBarViewModel : ViewModel
    {
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
        /// Initializes a new instance of the <see cref="MenuBarViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">Event aggregator</param>
        /// <param name="regionManager">Region manager</param>
        /// <param name="menuService">Menu service</param>
        public MenuBarViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMenuService menuService)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.menuService = menuService;
        }

        /// <summary>
        /// Gets a list of parent menu items.
        /// </summary>
        public ObservableCollection<MenuItem> ParentMenuItems
        {
            get
            {
                return this.menuService.GetParentMenuItems();
            }
        }
    }
}
