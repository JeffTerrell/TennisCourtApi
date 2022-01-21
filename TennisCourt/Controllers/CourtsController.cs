using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisCourt.Models;

namespace TennisCourt.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CourtsController : ControllerBase
  {
    private readonly TennisCourtContext _db;

    public CourtsController(TennisCourtContext db)
    {
      _db = db;
    }

    // GET api/courts (Search parameter: city)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Court>>> Get(string city, string state, string surfaceType , string sortBy, string sortBy_desc, string sortBy_asc)
    {
      var query = _db.Courts.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (surfaceType != null)
      {
        query = query.Where(entry => entry.SurfaceType == surfaceType);
      }

      if (sortBy_asc != null)
      {
        if (sortBy_asc == "city")
        {
          query = query.OrderBy(entry => entry.City);
        }  
        if (sortBy_asc == "state")
        {
          query = query.OrderBy(entry => entry.State);
        }
      }


      if (sortBy_desc != null)
      {
        if (sortBy_desc == "city")
        {
          query = query.OrderByDescending(entry => entry.City);
        }
        if (sortBy_desc == "state")
        {
          query = query.OrderByDescending(entry => entry.State);
        }
      }

      return await query.ToListAsync();
    }

    // GET: api/courts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Court>> GetCourt(int id)
    {
        var court = await _db.Courts.FindAsync(id);

        if (court == null)
        {
            return NotFound();
        }

        return court;
    }

    // POST api/courts
    [HttpPost]
    public async Task<ActionResult<Court>> Post(Court court)
    {
      _db.Courts.Add(court);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCourt) , new { id = court.CourtId }, court);
    }

    // PUT: api/courts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Court court)
    {
      if (id != court.CourtId)
      {
        return BadRequest();
      }

      _db.Entry(court).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CourtExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Court court)
    {
      if (id != court.CourtId)
      {
        return BadRequest();
      }

      _db.Entry(court).State = EntityState.Modified;

      try
      {      
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CourtExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/courts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourt(int id)
    {
      var court = await _db.Courts.FindAsync(id);
      if (court == null)
      {
        return NotFound();
      }

      _db.Courts.Remove(court);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool CourtExists(int id)
    {
      return _db.Courts.Any(e => e.CourtId == id);
    }
  }
}