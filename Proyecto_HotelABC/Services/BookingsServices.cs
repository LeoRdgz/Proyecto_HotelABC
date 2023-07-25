using Proyecto_HotelABC.Context;
using Proyecto_HotelABC.Entities;
using Proyecto_HotelABC.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_HotelABC.Services
{
    public class BookingsServices
    {

        public void CreateBookingWithAccount(Booking newBooking, string userEmail)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    
                    var existingUser = _context.Counts.FirstOrDefault(c => c.Mail == userEmail);
                    if (existingUser == null)
                    {
                        throw new Exception("No se encontró la cuenta de correo en la base de datos.");
                    }

                   
                    newBooking.CountId = existingUser.PkCount;

                   
                    _context.Bookings.Add(newBooking);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (CreateBookingWithAccount): " + ex.Message);
            }
        }


        public List<Booking> GetBookings()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Booking> bookings = _context.Bookings.ToList();
                    return bookings;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetBookings)" + ex.Message);
            }
        }

        public void GenerateSuites()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    bool BasicSuite = _context.SuiteNames.Any(role => role.NameS == "Basic");
                    bool PlusSuite = _context.SuiteNames.Any(role => role.NameS == "Plus");
                    bool PremiumSuite = _context.SuiteNames.Any(role => role.NameS == "Premium");
                    bool DeluxeSuite = _context.SuiteNames.Any(role => role.NameS == "DeluxeSuite");



                    if (!BasicSuite)
                    {
                        var Basic = new SuiteNames
                        {
                            NameS = "Basic"
                        };

                        _context.SuiteNames.Add(Basic);
                        _context.SaveChanges();
                    }

                    if (!PlusSuite)
                    {
                        var Plus = new SuiteNames
                        {
                            NameS = "Plus"
                        };

                        _context.SuiteNames.Add(Plus);
                        _context.SaveChanges();
                    }

                    if (!PremiumSuite)
                    {
                        var Premium = new SuiteNames
                        {
                            NameS = "Premium"
                        };

                        _context.SuiteNames.Add(Premium);
                        _context.SaveChanges();
                    }
                    if (!DeluxeSuite)
                    {
                        var Deluxe = new SuiteNames
                        {
                            NameS = "DeluxeSuite"
                        };

                        _context.SuiteNames.Add(Deluxe);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GenerateSuites) " + ex.Message);
            }

        }

        public List<SuiteNames> GetSuites()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<SuiteNames> suites = _context.SuiteNames.ToList();
                    return suites;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetSuites)" + ex.Message);
            }
        }

    }
}
