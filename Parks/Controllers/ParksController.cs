using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Parks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksContext _db;

    public ParksController(ParksContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Get a list of all parks
    /// </summary>
    /// <param name="name" example="Yosemite">Query an exact name match to return a specific park</param>
    /// <param name="statePark">Query "true" to return all parks that are State Parks</param>
    /// <param name="nationalPark">Query "true" to return all parks that are National Parks</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, bool statePark, bool nationalPark)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(a => a.Name == name);
      }

      if (statePark == true)
      {
        query = query.Where(a => a.IsStatePark == true);
      }

      if (nationalPark == true)
      {
        query = query.Where(a => a.IsNationalPark == true);
      }

      return await query.ToListAsync();
    }

    /// <summary>
    /// Add a new park
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    /// <summary>
    /// Find a park by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }
    
    /// <summary>
    /// Edit an existing park
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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
    /// Delete a park
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

  }
}