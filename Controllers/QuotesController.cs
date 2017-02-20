using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/quotes")] 
    public class QuoteController : Controller 
    {  
         // POST api/auto/quotes 
        [HttpPost] 
        public IActionResult Post([FromBody] Quote quote) 
        { 
            //return Created("", value); 
            return Ok(db.CreateQuote(quote));
        }  

         // GET api/auto/quotes/5 
        [HttpGet("{id}")] 
        public IActionResult Get(int id) 
        { 
            //return Ok("The id is: " + id); 
            return Ok(db.RetrieveQuote(id));
        } 

           // PUT api/auto/quotes/id 
        [HttpPut("{id}")] 
        public IActionResult Put([FromBody]Quote quote) 
        { 
            //return NoContent(); 
            return Ok(db.UpdateQuote(quote));
        }

        // DELETE api/auto/quotes/id 
        [HttpDelete("{id}")] 
        public IActionResult  Delete(int id) 
        { 
            //return Delete(id); 
            db.DeleteQuote(id);
            return Ok();
        }

        private IMemoryStore db;
        public QuoteController(IMemoryStore repo) 
        {
              db = repo;
        }

    [HttpGet]
     public IActionResult GetQuotes()
      {  
          return Ok(db.RetrieveAllQuotes);
     }

    } 