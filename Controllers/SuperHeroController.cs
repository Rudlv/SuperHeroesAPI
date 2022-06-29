using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {
                Id = 1,
                Name = "Man Spider",
                FirstName = "Pete",
                LastName = "Park",
                Place = "New City"
            },
            
            new SuperHero {
                Id = 2,
                Name = "Man of Iron",
                FirstName = "Tom",
                LastName = "Sark",
                Place = "Short Island"
            },

            new SuperHero {
                Id = 3,
                Name = "Ant Boy",
                FirstName = "Bruce",
                LastName = "Clancy",
                Place = "Chicago"
            },

            new SuperHero {
                Id = 4,
                Name = "Red Canary",
                FirstName = "Sarah",
                LastName = "Connie",
                Place = "Saltsburg"
            },


        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found ");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request )
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found ");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(heroes);
        }
     
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found ");
            heroes.Remove(hero);
            return Ok(heroes);
        }


    }
}
