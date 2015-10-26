using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Models
{
    /// <summary>
    /// About Menu Item.
    /// </summary>
    class AboutMenuItem : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutMenuItem"/> class.
        /// </summary>
        /// <param name="menuName">Menu item name</param>
        /// <param name="menuText">Menu item text</param>
        public AboutMenuItem(string menuName, string menuText)
            : base(menuName, menuText, false, 100)
        {
        }

        /// <summary>
        /// Action to perform when menu item selected.
        /// Do nothing as this is top level.
        /// </summary>
        public override void OnMenuItemSelected()
        {
        }
    }
}
