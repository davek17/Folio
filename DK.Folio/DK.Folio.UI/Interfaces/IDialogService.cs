using DK.Folio.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DK.Folio.UI.Interfaces
{
    public interface IDialogService
    {
        /// <summary>
        /// Show a question dialog and return the answer
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        /// <returns>True is yes</returns>
        bool ShowQuestionDialog(string title, string message);

        /// <summary>
        /// Show a information dialog and return the answer
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        /// <returns>True is yes</returns>
        bool ShowInformationDialog(string title, string message);

        /// <summary>
        /// Show error dialog box
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        void ShowErrorDialog(string title, string message);

        /// <summary>
        /// Gets value entered by user
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        /// <returns>User entered value</returns>
        string GetUserEnteredValueDialog(string title, string message);

        /// <summary>
        /// Show exception and details in a dialog
        /// </summary>
        /// <param name="title">Exception box title</param>
        /// <param name="ex">Exception to display</param>
        void ShowDetailedExceptionDialog(string title, Exception ex);

        /// <summary>
        /// Displays the window as dialog.
        /// </summary>
        /// <typeparam name="T">View model object</typeparam>
        /// <typeparam name="U">Window type</typeparam>
        /// <param name="viewModel">The view model.</param>
        /// <returns>The view model once dialog has been closed.</returns>
        /// <remarks>Displays exception message on error and then returns null.</remarks>
        T DisplayWindowAsDialog<T, U>(T viewModel)
            where T : ViewModel
            where U : Window;
    }
}
