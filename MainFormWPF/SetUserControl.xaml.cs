using CommonActions.Classes;
using CommonActions.Interfaces;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainFormWPF
{
    /// <summary>
    /// Lógica de interacción para SetUserControl.xaml
    /// </summary>
    public partial class SetUserControl : UserControl
    {
        public SetUserControl()
        {
            InitializeComponent();
            LoadConfigValues();
        }

        /// <summary>
        /// Loads values from config json DB sets
        /// </summary>
        private void LoadConfigValues()
        {
            IReadLocalPath ReadLocalPath = new ReadLocalPath();
            locPathTxt.Text = ReadLocalPath.GetLocalPathValue();
        }

        /// <summary>
        /// Updates values of a config set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            if (locPathTxt.Text != String.Empty)
            {
                IUpdateLocalPath UpdateLocal = new UpdateLocalPath();
                UpdateLocal.UpdateLocalPath(locPathTxt.Text);
            }
        }

        /// <summary>
        /// Close the form dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExit_Click(object sender, RoutedEventArgs e)
        {
            SecondGrid.Visibility = Visibility.Collapsed;
        }
    }
}
