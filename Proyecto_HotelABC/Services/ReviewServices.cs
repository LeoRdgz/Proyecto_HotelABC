using System;
using Proyecto_HotelABC.Entities;
using Proyecto_HotelABC.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Proyecto_HotelABC.Services
{
    public class ReviewServices
    {
        public void AddReview(Review request)
        {
            using (var _context = new ApplicationDbContext())
            {
                Review review = new Review();
                review.Text = request.Text;
                review.ReviewDate = request.ReviewDate;
                review.Rating = request.Rating;

                _context.Reviews.Add(review);
                _context.SaveChanges();
            }
        }

        public void DeleteReview(string reviewId)
        {
            using(var _context = new ApplicationDbContext())
            {
                Review review = _context.Reviews.Find(reviewId);

                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
    }
}
