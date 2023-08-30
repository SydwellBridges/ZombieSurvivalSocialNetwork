using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZombieSurvivalSocialNetwork.Data;

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
    }
}
