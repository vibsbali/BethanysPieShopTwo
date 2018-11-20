using BethanysPieShop.DataAccess;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public IActionResult Feedback()
        {
            return View(new Feedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(Feedback feedbackModel)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedbackModel);
                return RedirectToAction("Index", "Home");
            }

            return View(feedbackModel);
        }
    }
}
