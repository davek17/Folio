using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Models
{
    /// <summary>
    /// File menu header item
    /// </summary>
    public class FileMenu : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileMenu"/> class.
        /// </summary>
        /// <param name="menuName">Menu item name</param>
        /// <param name="menuText">Menu item text</param>
        public FileMenu(string menuName, string menuText)
            : base(menuName, menuText, false, 0)
        {
        }

        /// <summary>
        /// Top level menu, do nothing
        /// </summary>
        public override void OnMenuItemSelected()
        {
        }
    }
}
