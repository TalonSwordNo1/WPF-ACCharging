using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ACCharging.Shell.Views
{
    public class BaseWindow: Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (ShowClosingConfirmDialog())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        
        private bool ShowClosingConfirmDialog()
        {
            if(MessageBox.Show("Are you sure to close the application?","Closing Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                return true;
            }

            return false;
        }
    }
}
