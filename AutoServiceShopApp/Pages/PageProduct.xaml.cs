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
using System.Windows.Threading;

namespace AutoServiceShopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        public PageProduct()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();

            gridListProduct.ItemsSource = ConnectOdb.conObj.Product.ToList();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectOdb.conObj.Product.ToList();
            ListProduct.ItemsSource = HistoryProduct;
            ListProduct.ItemsSource = ConnectOdb.conObj.Product.Where(x => x.Title.ToLower().Contains(TxtSearch.Text) |
            x.Description.ToLower().Contains(TxtSearch.Text) |
            x.Manufacturer.Name.ToLower().Contains(TxtSearch.Text)).ToList();
        }

        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            eventArg.RoutedEvent = UIElement.MouseWheelEvent;
            eventArg.Source = sender;
            var parent = ((ListBox)sender).Parent as UIElement;
            parent.RaiseEvent(eventArg);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageEditNew((sender as Button).DataContext as Product));
        }

        private void BtnSalehistory_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageSaleHistory((sender as Button).DataContext as Product));
        }

        private void RbUp_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           gridListProduct.ItemsSource = ConnectOdb.conObj.Product.OrderBy(x => x.Title).ToList();
        }

        private void RbDown_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            gridListProduct.ItemsSource = ConnectOdb.conObj.Product.OrderByDescending(x => x.Title).ToList();
        }
    }
}
