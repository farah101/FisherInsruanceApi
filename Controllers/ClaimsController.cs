using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FisherInsuranceApi.Controllers
{
    [RouteAttribute("api/claims")]
    public class ClaimsController : Controller
    {

        private readonly FisherContext db;

        public ClaimsController(FisherContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(db.Claims);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Claim claim)
        {
            var newClaim = db.Claims.Add(claim);
            db.SaveChanges();

            return CreatedAtRoute("GetClaim", new { id = claim.Id }, claim);
        }


        [HttpGet("{id}", Name = "GetClaim")]
        public IActionResult Get(int id)
        {
            return Ok(db.Claims.Find(id));
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Claim newClaim)
        {
            var claim = db.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim = newClaim;
            claim.Id = id;

            db.Update(claim);
            db.SaveChanges();
            
            return Ok(claim);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var claimToDelete = db.Claims.Find(id);
            if (claimToDelete == null)
            {
                return NotFound();
            }

            db.Claims.Remove(claimToDelete);
            db.SaveChangesAsync();

            return NoContent();

        }
    }
}