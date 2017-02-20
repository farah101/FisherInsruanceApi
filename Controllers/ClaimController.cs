using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/claims")] 
    public class ClaimController : Controller
    {  
         // POST api/claims

        [HttpGet]
         public IActionResult GetCaims()
          {  
           return Ok(db.RetrieveAllClaims);
         }

        [HttpPost] 
        public IActionResult Post([FromBody] Claim claim) 
        { 
            //return Created("", value); 
            return Ok(db.CreateClaim(claim));
        }  

         // GET api/cliam
        [HttpGet("{id}")] 
        public IActionResult Get(int id) 
        { 
            //return Ok("The id is: " + id); 
            return Ok(db.RetrieveClaim(id));
        } 

           // PUT api/auto/quotes/id 
        [HttpPut("{id}")] 
        public IActionResult Put([FromBody]Claim claim) 
        { 
            //return NoContent(); 
            return Ok(db.UpdateClaim(claim));
        }

        // DELETE api/auto/quotes/id 
        [HttpDelete("{id}")] 
        public IActionResult  Delete(int id) 
        { 
            //return Delete(id); 
            db.DeleteClaim(id);
            return Ok();
        }

        private IMemoryStore db;
        public ClaimController(IMemoryStore repo) 
        {
              db = repo;
        }

    } 