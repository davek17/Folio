using DK.Folio.UI.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.Models
{
    /// <summary>
    /// Exit menu item
    /// </summary>
    class ExitMenuItem : MenuItem
    {
        /// <summary>
        /// Event aggregator
        /// </summary>
        private IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitMenuItem"/> class.
        /// </summary>
        /// <param name="menuName">Menu name</param>
        /// <param name="menuText">Menu text</param>
        /// <param name="eventAggregator">event aggregator</param>
        public ExitMenuItem(string menuName, string menuText, IEventAggregator eventAggregator)
            : base(menuName, menuText, false, 999)
        {
            this.eventAggregator = eventAggregator;
        }

        /// <summary>
        /// On exit event called, pass through event aggregator.
        /// </summary>
        public override void OnMenuItemSelected()
        {
            ExitCommand appExitCommand = this.eventAggregator.GetEvent<ExitCommand>();
            appExitCommand.Publish(true);
        }
    }
}
