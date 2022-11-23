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
    /// Логика взаимодействия для PageEditService.xaml
    /// </summary>
    public partial class PageEditService : Page
    {
        public PageEditService(Service service)
        {
            InitializeComponent();
            ServiceObj.Id = service.ID;

            TxtTitle.Text = service.Title;
            TxtCost.Text = Convert.ToString(service.Cost);
            TxtDiscount.Text = Convert.ToString(service.Discount);
            TxtImage.Text = service.MainImagePath;
            TxtDescription.Text = service.Description;
            TxtDuration.Text = Convert.ToString(service.DurationInSeconds);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Service> services = ConnectOdb.conObj.Service.Where(x => x.ID == ServiceObj.Id).
                    AsEnumerable().Select(x =>
                    {
                        x.Title = TxtTitle.Text;
                        x.Cost = Convert.ToDecimal(TxtCost.Text);
                        x.Discount = Convert.ToDouble(TxtDiscount.Text);
                        x.DurationInSeconds = Convert.ToInt32(TxtDuration.Text);

                        if (string.IsNullOrWhiteSpace(TxtDescription.Text))
                        {
                            x.Description = "";
                        }
                        else
                        {
                            x.Description = TxtDescription.Text;
                        }

                        if (string.IsNullOrWhiteSpace(TxtImage.Text))
                        {
                            x.MainImagePath = "";
                        }
                        else
                        {
                            x.MainImagePath = TxtImage.Text;
                        }
                        return x;
                    });
                foreach (Service srvc in services)
                {
                    ConnectOdb.conObj.Entry(srvc).State = System.Data.Entity.EntityState.Modified;
                }

                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные успешо изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
