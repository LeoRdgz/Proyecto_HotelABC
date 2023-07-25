using Proyecto_HotelABC.Entities;
using Proyecto_HotelABC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_HotelABC.Views.GuestViews
{
    /// <summary>
    /// Lógica de interacción para BookingView.xaml
    /// </summary>
    public partial class BookingView : Window
    {
        BookingsServices bookingsServices = new BookingsServices();
        public BookingView()
        {
           InitializeComponent();
           GetSuites();
        }

        

        public void GetSuites()
        {
            SelectSuites.ItemsSource = bookingsServices.GetSuites();
            SelectSuites.DisplayMemberPath = "NameS";
            SelectSuites.SelectedValuePath = "PkName";
        }

        private void Button_Reserve(object sender, RoutedEventArgs e)
        {
            GuestMenu ventana = new GuestMenu();
            try
            {
               
                int days = int.Parse(txtDays.Text);
                int amountPerson = int.Parse(txtAmount.Text);
                int selectedSuiteId = int.Parse(SelectSuites.SelectedValue.ToString());



                Booking newBooking = new Booking
                {
                    Days = days,
                    AmountPerson = amountPerson,
                    Suite= selectedSuiteId
                    
                };

               
                string userEmail = txtMail.Text;

                MessageBox.Show("Reservación creada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

              

                bookingsServices.CreateBookingWithAccount(newBooking, userEmail);

                this.Close();

                ventana.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reservación: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
