using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }

        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
            );
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult Get(string nome)
        {
            var herois = _context.Herois.Where(hero => hero.Nome.Contains(nome)).ToList();
            return Ok(herois);
        }

        // GET api/values/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Put(string nameHero)
        {

            var heroi = _context.Herois
                            .Where(h => h.Id == 3)
                            .FirstOrDefault();
            heroi.Nome = "Homem Aranha";            
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois.Where(hero => hero.Id == id).Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }

    }
}
