using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DK.Folio.UI.Models
{
    /// <summary>
    /// Menu Item Style Selector
    /// </summary>
    class MenuItemStyleSelector : StyleSelector
    {
        /// <summary>
        /// Style selector
        /// </summary>
        /// <param name="item">Item to select style for</param>
        /// <param name="container">Container in which the styles are stored</param>
        /// <returns>Style to use</returns>
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (((MenuItem)item).IsSeparator)
            {
                return (Style)((FrameworkElement)container).FindResource("menuSeparatorStyle");
            }
            else
            {
                return (Style)((FrameworkElement)container).FindResource("menuBarItem");
            }
        }
    }
}
