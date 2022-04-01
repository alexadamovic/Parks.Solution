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

    /// <summary>
    /// Gets a list of all locations
    /// </summary>
    /// <param name="mostParks">Query "yes" to organize locations list by number of parks</param>
    /// <param name="state">Query state abbreviation (ex. CO, OR, CA, etc.) to return a specific location</param>
    /// <param name="minParks">Query an integer to get a list of locations with that minimum number of parks</param>
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

    /// <summary>
    /// Add a new location
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Location>> Post(Location location)
    {
      _db.Locations.Add(location);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, location);
    }

    /// <summary>
    /// Find a location by ID
    /// </summary>
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
    
    /// <summary>
    /// Update an existing location
    /// </summary>
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

    /// <summary>
    /// Delete a location
    /// </summary>
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