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
    /// Логика взаимодействия для PageAddService.xaml
    /// </summary>
    public partial class PageAddService : Page
    {
        public PageAddService()
        {
            InitializeComponent();
           
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtDiscount.Text == "")
                {
                    TxtDiscount.Text = null;
                };
                Service service = new Service()
                {
                    Title = TxtTitle.Text,
                    Cost = Convert.ToDecimal(TxtCost.Text),
                    DurationInSeconds = Convert.ToInt32(TxtDuration.Text),
                    Description = TxtDescription.Text,
                    Discount = Convert.ToDouble(TxtDiscount.Text),
                    MainImagePath = TxtImage.Text

                };

                ConnectOdb.conObj.Service.Add(service);
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
