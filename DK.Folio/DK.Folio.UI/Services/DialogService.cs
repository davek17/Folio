using DK.Folio.UI.Interfaces;
using DK.Folio.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DK.Folio.UI.Services
{
    class DialogService : IDialogService
    {
        /// <summary>
        /// Show a question dialog and return the answer
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        /// <returns>True is yes</returns>
        public bool ShowQuestionDialog(string title, string message)
        {
            if (MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Show a information dialog and return the answer
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        /// <returns>True is yes</returns>
        public bool ShowInformationDialog(string title, string message)
        {
            if (MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Show error dialog box
        /// </summary>
        /// <param name="title">Dialog box title</param>
        /// <param name="message">Dialog box message</param>
        public void ShowErrorDialog(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Get text entered by user
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="message">Dialog message</param>
        /// <returns>User entered value, null on cancel</returns>
        public string GetUserEnteredValueDialog(string title, string message)
        {
            //UserInputDialogViewModel vm = new UserInputDialogViewModel(title, message);
            //UserInputDialog dialog = new UserInputDialog(vm);

            //if (dialog.ShowDialog() == true)
            //{
            //    return vm.UserText;
            //}

            return null;
        }

        /// <summary>
        /// Show exception and details in a dialog
        /// </summary>
        /// <param name="title">Exception box title</param>
        /// <param name="ex">Exception to display</param>
        public void ShowDetailedExceptionDialog(string title, Exception ex)
        {
            string message;

            if (ex.InnerException != null)
            {
                message = string.Format("Error: {0}. {1}{1}More Details:{1}{2}", ex.Message, Environment.NewLine, ex.InnerException.Message);
            }
            else
            {
                message = string.Format("Error: {0}.", ex.Message);
            }

            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }


        /// <summary>
        /// Displays the window as dialog.
        /// </summary>
        /// <typeparam name="T">View model object</typeparam>
        /// <typeparam name="U">Window type</typeparam>
        /// <param name="viewModel">The view model.</param>
        /// <returns>The view model once dialog has been closed.</returns>
        /// <remarks>Displays exception message on error and then returns null.</remarks>
        public T DisplayWindowAsDialog<T, U>(T viewModel) 
            where T : ViewModel
            where U : Window
        {
            try
            {
                U window = (U)Activator.CreateInstance(typeof(U), viewModel);

                window.ShowDialog();

                return (T)viewModel;
            }
            catch (Exception ex)
            {
                this.ShowDetailedExceptionDialog("Unable to create view.", ex);
            }

            return null;
        }
    }
}
