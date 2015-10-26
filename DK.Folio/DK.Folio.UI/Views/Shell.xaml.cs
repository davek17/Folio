using DK.Folio.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DK.Folio.UI.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        /// <summary>
        /// Shell view model
        /// </summary>
        private ShellViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        /// <param name="viewModel">View model</param>
        public Shell(ShellViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.Loaded += (s, e) => { this.DataContext = viewModel; };

            this.InitializeComponent();
        }

        /// <summary>
        /// Handle window closing in View Model
        /// </summary>
        /// <param name="sender">Close button</param>
        /// <param name="e">Cancel event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.viewModel.OnExitCommandReceived(true);
        }
    }
}
