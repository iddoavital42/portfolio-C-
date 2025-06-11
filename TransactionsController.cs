 using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private static readonly List<Transaction> Transactions = new List<Transaction>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Transactions);
        }

        [HttpPost]
        public IActionResult Add(Transaction transaction)
        {
            Transactions.Add(transaction);
            return CreatedAtAction(nameof(GetAll), transaction);
        }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
