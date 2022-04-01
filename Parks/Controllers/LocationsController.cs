using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Locations.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private readonly ParksContext _db;

    public LocationsController(ParksContext db)
    {
      _db = db;
    }

    // GET api/locations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> Get(string mostParks, string state, int minParks)
    {
      var query = _db.Locations
        .Include(a => a.Parks)
        .AsQueryable();

      if (mostParks == "yes")
      {
        query = query.OrderByDescending(a => a.Parks.Count());
      }

      if (state != null)
      {
        query = query.Where(a => a.State == state);
      }

      if (minParks > 0)
      {
        query = query.Where(a => a.Parks.Count() >= minParks);
      }

      return await query.ToListAsync();
    }

    // POST api/locations
    [HttpPost]
    public async Task<ActionResult<Location>> Post(Location location)
    {
      _db.Locations.Add(location);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, location);
    }

    // GET: api/Locations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> GetLocation(int id)
    {
        var location = await _db.Locations.Include(a => a.Parks).FirstOrDefaultAsync(a => a.LocationId == id);

        if (location == null)
        {
            return NotFound();
        }

        return location;
    }
    
    // PUT: api/Locations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Location location)
    {
      if (id != location.LocationId)
      {
        return BadRequest();
      }

      _db.Entry(location).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!LocationExists(id))
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

    // DELETE: api/Locations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
      var location = await _db.Locations.FindAsync(id);
      if (location == null)
      {
        return NotFound();
      }

      _db.Locations.Remove(location);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool LocationExists(int id)
    {
      return _db.Locations.Any(e => e.LocationId == id);
    }

  }
}