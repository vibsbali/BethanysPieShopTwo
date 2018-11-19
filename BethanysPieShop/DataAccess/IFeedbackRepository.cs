using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.DataAccess
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }

    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _dbContext;

        public FeedbackRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddFeedback(Feedback feedback)
        {
            _dbContext.Feedbacks.Add(feedback);
            _dbContext.SaveChanges();
        }
    }
}
