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
using System.Windows.Shapes;

namespace Proyecto_HotelABC.Views.GuestViews
{
    /// <summary>
    /// Lógica de interacción para GuestMenu.xaml
    /// </summary>
    public partial class GuestMenu : Window
    {
        public GuestMenu()
        {
            InitializeComponent();
        }

        private void BtnReserve(object sender, RoutedEventArgs e)
        {
            BookingView bookingView = new BookingView();
            this.Close();
            bookingView.Show();
            
        }

        private void BtnVerReserva(object sender, RoutedEventArgs e)
        {
            ViewBooking viewBooking = new ViewBooking();

            this.Close();
            viewBooking.Show();
        }
    }
}
