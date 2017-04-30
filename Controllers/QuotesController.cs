using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/quotes")]
    public class QuotesController : Controller
    {
        private readonly FisherContext db;

        public QuotesController(FisherContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.Quotes);

        }

        [HttpGet("{id}", Name="GetQuote")]
        public IActionResult Get(int id)
        {
            return Ok(db.Quotes.Find(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            var newQuote = db.Quotes.Add(quote);
            db.SaveChanges();

            return CreatedAtRoute("GetQuote", new { id = quote.Id }, newQuote);
            
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote newQuote)
        {
            var quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }
            quote = newQuote;
            quote.Id = id; 
            db.Update(quote);
            db.SaveChanges();
            return Ok(quote);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var quoteToDelete = db.Quotes.Find(id);
            if (quoteToDelete == null)
            {
                return NotFound();
            }

            db.Quotes.Remove(quoteToDelete);
            db.SaveChangesAsync();

            return NoContent();

        }

    }
}