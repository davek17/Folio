using DK.Folio.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DK.Folio.UI.Services
{
    class CursorService : ICursorService
    {
        /// <summary>
        /// Show wait cursor
        /// </summary>
        public void ShowWaitCursor()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        /// <summary>
        /// Reset cursor
        /// </summary>
        public void ResetCursor()
        {
            Mouse.OverrideCursor = null;
        }
    }
}
