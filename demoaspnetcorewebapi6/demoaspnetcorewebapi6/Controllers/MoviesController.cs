using demoaspnetcorewebapi6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoaspnetcorewebapi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesController _dbContext;
        public MoviesController(MoviesController dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
                if(_dbContext.Movies == null)
                    {
                        return NotFound();
                    }    

                    return await _dbContext.Movies.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if(_dbContext.Movies == null)
            {
                return NotFound();
            }    
            //var movie = await _dbContext.Movies.Find
        }
    }
}
