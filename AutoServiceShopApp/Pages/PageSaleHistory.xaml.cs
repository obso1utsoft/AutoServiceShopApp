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
    /// Логика взаимодействия для PageSaleHistory.xaml
    /// </summary>
    public partial class PageSaleHistory : Page
    {
        public PageSaleHistory(Product product)
        {
            InitializeComponent();

            ProductObj.Id = product.ID;
            CmbxProduct.DisplayMemberPath = "Title";
            CmbxProduct.SelectedValuePath = "ID";
            CmbxProduct.ItemsSource = ConnectOdb.conObj.Product.ToList();

            GridSaleProduct.IsReadOnly = true;

            GridSaleProduct.ItemsSource = ConnectOdb.conObj.ProductSale.Where(x => x.ProductID == ProductObj.Id).ToList();
        }

        private void CmbxProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridSaleProduct.ItemsSource = null;
            int SelectProduct = Convert.ToInt32(CmbxProduct.SelectedValue);
            GridSaleProduct.ItemsSource = ConnectOdb.conObj.ProductSale.Where(x => x.ProductID == SelectProduct).ToList();
            GridSaleProduct.SelectedIndex = 0;
        }
    }
}
