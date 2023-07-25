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
    /// Lógica de interacción para ViewBooking.xaml
    /// </summary>
    public partial class ViewBooking : Window
    {
        BookingsServices bookingsServices = new BookingsServices();
        public ViewBooking()
        {
            InitializeComponent();
            GetReservation();
        }

        public void GetReservation()
        {
            BookingTable.ItemsSource = bookingsServices.GetBookings();
        }
        public void BTN_Delete_Click(object sender, EventArgs e)
        {
            Count count = new Count();

            count = (sender as FrameworkElement).DataContext as Count;

            int DeletePk = int.Parse(count.PkCount.ToString());
            

            GetReservation();
        }

    }
}
