using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Folio.UI.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// view model ID;
        /// </summary>
        private Guid viewModelID;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="property">The property.</param>
        protected void NotifyPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Intiialize a new view model
        /// </summary>
        public ViewModel()
        {
            this.viewModelID = Guid.NewGuid();
        }

        /// <summary>
        /// Gets a GUID for the view model.  Useful for closing the View.
        /// </summary>
        public Guid VMID
        {
            get
            {
                return this.viewModelID;
            }
        }

        /// <summary>
        /// Override to set a title - mostly for Tab Controls
        /// </summary>
        public virtual string Title
        {
            get
            {
                return "No Title Set";
            }
        }
    }
}
