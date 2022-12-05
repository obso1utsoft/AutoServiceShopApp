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

        /// <summary>
        /// Обновление данных в реальном времени и логика поиска
        /// </summary>
        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectOdb.conObj.Product.ToList();
            ListProduct.ItemsSource = HistoryProduct;

            ListProduct.ItemsSource = ConnectOdb.conObj.Product.Where(x => x.Title.ToLower().Contains(TxtSearch.Text) |
            x.Description.ToLower().Contains(TxtSearch.Text) |
            x.Manufacturer.Name.ToLower().Contains(TxtSearch.Text)).ToList();
        }

        /// <summary>
        /// Логика работы скролла при наведении на товар
        /// </summary>
        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            eventArg.RoutedEvent = UIElement.MouseWheelEvent;
            eventArg.Source = sender;
            var parent = ((ListBox)sender).Parent as UIElement;
            parent.RaiseEvent(eventArg);
        }

        /// <summary>
        /// Переключения на страницу PageEditNew.xaml
        /// </summary>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageEditNew((sender as Button).DataContext as Product));
        }

        /// <summary>
        /// Переключения на страницу PageSaleHistory.xaml
        /// </summary>
        private void BtnSalehistory_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageSaleHistory((sender as Button).DataContext as Product));
        }

        /// <summary>
        /// Переключения на страницу PageAddProduct.xaml
        /// </summary>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageAddProduct());
        }

        /// <summary>
        /// Логика печати
        /// </summary>
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                gridPanelListProduct.Measure(pageSize);
                gridPanelListProduct.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(gridPanelListProduct, Title);
            }
        }
    }
}
