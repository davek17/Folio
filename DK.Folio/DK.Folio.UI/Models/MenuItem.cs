
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Models
{
    /// <summary>
    /// Menu Item Object
    /// </summary>
    public abstract class MenuItem
    {
        /// <summary>
        /// Menu ID
        /// </summary>
        private int menuID;

        /// <summary>
        /// Menu name
        /// </summary>
        private string menuName;

        /// <summary>
        /// Text to display
        /// </summary>
        private string menuText;

        /// <summary>
        /// Menu parent ID
        /// </summary>
        private int menuParentID;

        /// <summary>
        /// Menu sort order
        /// </summary>
        private int sortOrder;

        /// <summary>
        /// Menu icon path
        /// </summary>
        private string iconPath;

        /// <summary>
        /// Is the menu item a separator?
        /// </summary>
        private bool isSeparator;

        /// <summary>
        /// List of associated sub items.
        /// </summary>
        private List<MenuItem> subItems;

        /// <summary>
        /// Command to execute when selected.
        /// </summary>
        private DelegateCommand onSelected;

        /// <summary>
        /// Is the menu item checkable
        /// </summary>
        private bool isCheckable;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="menuName">Menu name and title</param>
        /// <param name="menuText">Text to display on menu.</param>
        /// <param name="isSeparator">Is the menu item a separator</param>
        /// <param name="sortOrder">Sort order - if not important leave at 99</param>
        /// <param name="iconPath">Menu icon path if required</param>
        /// <param name="isCheckable">Is menu item checkable</param>
        public MenuItem(string menuName, string menuText, bool isSeparator = false, int sortOrder = 99, string iconPath = "", bool isCheckable = false)
        {
            this.menuName = menuName;
            this.menuText = menuText;
            this.isSeparator = isSeparator;
            this.sortOrder = sortOrder;
            this.iconPath = iconPath;
            this.isCheckable = isCheckable;

            this.subItems = new List<MenuItem>();
        }

        /// <summary>
        /// Gets the menu item name.
        /// </summary>
        public string MenuName
        {
            get
            {
                return this.menuName;
            }
        }

        /// <summary>
        /// Gets or sets the menu ID.  
        /// Set by the menu service.
        /// </summary>
        public int MenuID
        {
            get
            {
                return this.menuID;
            }

            set
            {
                this.menuID = value;
            }
        }

        /// <summary>
        /// Gets or sets the menu parent ID
        /// Set by the menu service.
        /// </summary>
        public int MenuParentID
        {
            get
            {
                return this.menuParentID;
            }

            set
            {
                this.menuParentID = value;
            }
        }

        /// <summary>
        /// Gets the text to display
        /// </summary>
        public string MenuText
        {
            get
            {
                return this.menuText;
            }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public int SortOrder
        {
            get
            {
                return this.sortOrder;
            }

            set
            {
                this.sortOrder = value;
            }
        }

        /// <summary>
        /// Gets the icon path
        /// </summary>
        public string IconPath
        {
            get
            {
                return this.iconPath;
            }
        }

        /// <summary>
        /// Gets the Sub Items
        /// </summary>
        /// <returns>Sub Items</returns>
        public List<MenuItem> SubItems
        {
            get
            {
                IEnumerable<MenuItem> sortedMenuItems =
                    from MenuItem in this.subItems
                    orderby MenuItem.SortOrder
                    select MenuItem;

                return sortedMenuItems.ToList();
            }
        }

        /// <summary>
        /// Gets the command to execute when menu item selected.
        /// </summary>
        public DelegateCommand OnSelected
        {
            get
            {
                if (this.onSelected == null)
                {
                    this.onSelected = new DelegateCommand(this.OnMenuItemSelected, this.CanSelect);
                }

                return this.onSelected;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this menu item is a separator
        /// </summary>
        public bool IsSeparator
        {
            get
            {
                return this.isSeparator;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the menu item is checkable
        /// </summary>
        public bool IsCheckable
        {
            get
            {
                return this.isCheckable;
            }
        }

        /// <summary>
        /// Add subItem
        /// </summary>
        /// <param name="subItem">MenuItem sub-item</param>
        public void AddSubItem(MenuItem subItem)
        {
            this.subItems.Add(subItem);
        }

        /// <summary>
        /// Code to run when selected.
        /// </summary>
        public abstract void OnMenuItemSelected();

        /// <summary>
        /// Returns whether we can select this item on the menu.
        /// Can be overridden
        /// </summary>
        /// <returns>True if enabled</returns>
        public virtual bool CanSelect()
        {
            return true;
        }
    }
}
