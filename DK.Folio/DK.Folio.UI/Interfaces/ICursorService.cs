using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Interfaces
{
    public interface ICursorService
    {
        /// <summary>
        /// Show wait cursor
        /// </summary>
        void ShowWaitCursor();

        /// <summary>
        /// Reset cursor
        /// </summary>
        void ResetCursor();
    }
}
