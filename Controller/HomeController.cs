using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace ImplementHangfire.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public string LogIn()
        {
            //fire and forgot job
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to our application"));

            return $"Job Id: {jobId}";
        }

        [HttpGet]
        [Route("productCheckout")]
        public string CheckoutProduct()
        {
            // Delay job - This job execute not immediately but after an interval of time(the second argument of Enqueue)
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You have just added one product into your cart"), TimeSpan.FromSeconds(20));

            return $"Job Id: {jobId}";
        }

        [HttpGet]
        [Route("productPurchase")]
        public string PurchaseProduct()
        {
            // Fire and forgot
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have purchase our product"));

            //This job executes only after the Execution of ParentJob
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Receipt of purchase"));

            return "you have done your payment and Receipt is sent on your Mail id";
        }

        //[HttpGet]
        //[Route("dailyOffers")]
        //public string DailyOffers()
        //{
        //    //RecurringJobOptions obj = new RecurringJobOptions();
        //    //Recurring Job - this job is executed many times on the specified cron schedule
        //    RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Hourly);

        //    return "offers Sent!";
        //}
    }
}
