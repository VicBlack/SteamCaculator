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

namespace SteamCaculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _User = new SteamUser();
            this.DataContext = _User;
        }
        private SteamUser _User;

        private void LevelCaculate_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void LevelCaculate_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _User != null;
        }

        private void FriendsLimitCaculate_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void FriendsLimitCaculate_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _User != null;
        }

        private void DisplayCaseLimitCaculate_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void DisplayCaseLimitCaculate_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _User != null;
        }
    }
}
