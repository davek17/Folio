using DK.Folio.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Interfaces
{
    /// <summary>
    /// Menu service interface
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// Add a new top level menu item.
        /// </summary>
        /// <param name="menuItem">Menu item to add.</param>
        void AddParentMenuItem(MenuItem menuItem);

        /// <summary>
        /// Add a new lower level parent item.
        /// </summary>
        /// <param name="menuItem">Menu item to add.</param>
        /// <param name="parentName">Parent name for menu item.</param>
        void AddChildMenuItem(MenuItem menuItem, string parentName);

        /// <summary>
        /// Get the parent items
        /// </summary>
        /// <returns>Collection of menu items</returns>
        ObservableCollection<MenuItem> GetParentMenuItems();
    }
}
