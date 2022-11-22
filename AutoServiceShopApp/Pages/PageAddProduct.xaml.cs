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
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        bool logicRb = false;
        public PageAddProduct()
        {
            InitializeComponent();

            CmbxOwner.SelectedValuePath = "ID";
            CmbxOwner.DisplayMemberPath = "Name";
            CmbxOwner.ItemsSource = ConnectOdb.conObj.Manufacturer.ToList();

            if (RbActive.IsChecked != false)
            {
                logicRb = true;
            }
            else
            {
                logicRb = false;
            }
            if (RbNotActive.IsChecked != false)
            {
                logicRb = false;
            }
            else
            {
                logicRb = true;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    Title = TxtTitle.Text,
                    Cost = Convert.ToDecimal(TxtCost.Text),
                    Description = TxtDescription.Text,
                    MainImagePath = TxtImage.Text,
                    IsActive = logicRb,
                    Manufacturer = CmbxOwner.SelectedItem as Manufacturer
                };

                ConnectOdb.conObj.Product.Add(product);
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные успешо добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
