using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/quotes/")]
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
    
    // POST api/quotes/
    [HttpPost]
    public IActionResult Post([FromBody] Quote quote)
    {
        var newQuote = db.Quotes.Add(quote);
        db.SaveChanges();
        return CreatedAtRoute("GetQuote", new { id = quote.Id }, quote);
    }

    // GET api/quotes/id
    [HttpGet("{id}", Name = "GetQuote")]
    public IActionResult Get(int id)
    {
        return Ok(db.Quotes.Find(id));
    }

    // PUT api/quotes/id
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Quote quote)
    {
        var newQuote = db.Quotes.Find(id);
        if (newQuote == null)
        {
            return NotFound();
        }
        newQuote = quote;
        db.SaveChanges();
        return Ok(newQuote);
    }
                        
    // DELETE api/quotes/id
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