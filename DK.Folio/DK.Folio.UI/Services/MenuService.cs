using DK.Folio.UI.Interfaces;
using DK.Folio.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace DK.Folio.UI.Services
{
    public class MenuService : IMenuService
    {
        /// <summary>
        /// Menu item view models to add to menu.
        /// </summary>
        private List<MenuItem> menuItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuService"/> class.
        /// </summary>
        public MenuService()
        {
            this.menuItems = new List<MenuItem>();
        }

        /// <summary>
        /// Add a new top level menu item.
        /// </summary>
        /// <param name="menuItem">Menu item to add.</param>
        public void AddParentMenuItem(MenuItem menuItem)
        {
            if (this.menuItems.FindAll(x => x.MenuName == menuItem.MenuName).Count > 0)
            {
                throw new Exception("A menu item with that name already exists");
            }

            menuItem.MenuID = this.menuItems.Count + 1;
            menuItem.MenuParentID = 0;

            // Crude way of ordering as we add.
            if (menuItem.SortOrder == 99)
            {
                menuItem.SortOrder = this.menuItems.Count + 1;
            }

            this.menuItems.Add(menuItem);
        }

        /// <summary>
        /// Add a new lower level parent item.
        /// </summary>
        /// <param name="menuItem">Menu item to add.</param>
        /// <param name="parentName">Parent name for menu item.</param>
        public void AddChildMenuItem(MenuItem menuItem, string parentName)
        {
            MenuItem parent = this.menuItems.Find(x => x.MenuName == parentName);

            if (parent == null)
            {
                throw new Exception("Parent menu item not found");
            }

            menuItem.MenuParentID = parent.MenuID;
            menuItem.MenuID = menuItem.MenuID = this.menuItems.Count + 1;
            this.menuItems.Add(menuItem);

            if (menuItem.SortOrder == 99)
            {
                menuItem.SortOrder = parent.SubItems.Count + 1;
            }

            parent.AddSubItem(menuItem);
        }

        /// <summary>
        /// Get parent items for menu.
        /// </summary>
        /// <returns>List of top level items</returns>
        public ObservableCollection<MenuItem> GetParentMenuItems()
        {
            // Sort our list so we get our items in order.
            IEnumerable<MenuItem> parentMenuItems =
                from MenuItem in this.menuItems
                where MenuItem.MenuParentID == 0
                orderby MenuItem.SortOrder ascending
                select MenuItem;

            return new ObservableCollection<MenuItem>(parentMenuItems);
        }
        
    }
}
