using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Models
{
    class RegionNames
    {
        /// <summary>
        /// Toolbar shell region
        /// </summary>
        private static string menubarRegion = "MenubarRegion";

        /// <summary>
        /// Tab region
        /// </summary>
        private static string tabRegion = "TabRegion";

        /// <summary>
        /// Status bar shell region
        /// </summary>
        private static string statusbarRegion = "StatusbarRegion";

        /// <summary>
        /// Main content region for shell.
        /// </summary>
        private static string shellContentRegion = "ShellContentRegion";

        /// <summary>
        /// Search Bar Region
        /// </summary>
        private static string toolBarRegion = "ToolBarRegion";

        /// <summary>
        /// Gets the toolbar region name.
        /// </summary>
        public static string MenubarRegion
        {
            get
            {
                return menubarRegion;
            }
        }

        /// <summary>
        /// Gets the status bar region name.
        /// </summary>
        public static string StatusbarRegion
        {
            get
            {
                return statusbarRegion;
            }
        }

        /// <summary>
        /// Gets the shell content region name.
        /// </summary>
        public static string ShellContentRegion
        {
            get
            {
                return shellContentRegion;
            }
        }

        /// <summary>
        /// Gets the ToolBar Region region
        /// </summary>
        public static string ToolBarRegion
        {
            get
            {
                return toolBarRegion;
            }
        }

        /// <summary>
        /// Gets the tab region
        /// </summary>
        public static string TabRegion { get { return tabRegion; } }
    }
}
