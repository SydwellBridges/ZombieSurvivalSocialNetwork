using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZombieSurvivalSocialNetwork.Data;
using ZombieSurvivalSocialNetwork.Models;

namespace ZombieSurvivalSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurvivorsController : ControllerBase
    {

        private readonly ZombieSurvivalDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurvivorsController"/> class.
        /// </summary>
        /// <param name="context">The database context for survivor data.</param>
        public SurvivorsController(ZombieSurvivalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new survivor to the database.
        /// </summary>
        /// <param name="addSurvivor">The details of the survivor to add.</param>
        /// <returns>The added survivor.</returns>
        [HttpPost]
        public async Task<IActionResult> AddSurvivor(AddSurvivorRequest addSurvivor)
        {
            var inventory = new Inventory
            {
                Water = addSurvivor.Inventory.Water,
                Food = addSurvivor.Inventory.Food,
                Medication = addSurvivor.Inventory.Medication,
                Ammunition = addSurvivor.Inventory.Ammunition
            };

            var survivor = new Survivor
            {
                Id = Guid.NewGuid(),
                Name = addSurvivor.Name,
                Age = addSurvivor.Age,
                Gender = addSurvivor.Gender,
                Latitude = addSurvivor.Latitude,
                Longitude = addSurvivor.Longitude,
                Inventory = inventory
            };

            await _context.Survivors.AddAsync(survivor);
            await _context.SaveChangesAsync();

            return Ok(survivor);
        }

        /// <summary>
        /// Retrieves a list of all survivors.
        /// </summary>
        /// <returns>A list of survivors with inventory details.</returns>
        [HttpGet]
        public async Task<IActionResult> ListAllSurvivors()
        {
            // Retrieve a list of survivors including inventory details
            var survivors = await _context.Survivors
                .Include(s => s.Inventory)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return Ok(survivors);
        }

        /// <summary>
        /// Updates the location of a survivor.
        /// </summary>
        /// <param name="id">The ID of the survivor to update.</param>
        /// <param name="update">The new location details.</param>
        /// <returns>The updated survivor with the new location.</returns>
        [HttpPut("{id}/location")]
        public async Task<IActionResult> UpdateSurvivorLocation(Guid id, SurvivorLocationUpdate update)
        {
            // Find the survivor by ID
            var survivor = await _context.Survivors.FindAsync(id);

            if (survivor != null)
            {
                survivor.Latitude = update.Latitude;
                survivor.Longitude = update.Longitude;

                await _context.SaveChangesAsync();

                return Ok(survivor);
            }

            return NotFound();
        }
    }
}
