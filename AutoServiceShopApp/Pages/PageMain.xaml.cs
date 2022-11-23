using AutoServiceShopApp.AppDataFile;
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

namespace AutoServiceShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }
        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageService());
        }
        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageProduct());
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageAddProduct());
        }
    }
}
