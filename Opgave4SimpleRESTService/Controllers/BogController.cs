using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Opgave1CsharpogUnittests;

namespace Opgave4SimpleRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogController : ControllerBase
    {
        private static List<Bog> boglist = new List<Bog>()
        {
            new Bog()
            {
                Titel = "Det Sorte Svaerd Slutningen", Forfatter = "Benjamin Soerensen", Isbn = "1234567812345", SideTal = 999
            },
            new Bog()
            {
                Titel = "Det Sorte Svaerd 2.2", Forfatter = "Benjamin Soerensen", Isbn = "4324567890123", SideTal = 150
            },
            new Bog()
            {
                Titel = "Det Sorte Svaerd 2", Forfatter = "Benjamin Soerensen", Isbn = "1234567890432", SideTal = 100
            },
            new Bog()
            {
                Titel = "Det Sorte Svaerd", Forfatter = "Benjamin Soerensen", Isbn = "1234567890123", SideTal = 200
            }
        };


        // GET: api/Bog
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return boglist;
        }

        // GET: api/Bog/5
        [HttpGet("{Isbn}")]
        public Bog Get(string Isbn)
        {
            return boglist.Find(bog => bog.Isbn == Isbn);
        }

        // POST: api/Bog
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            boglist.Add(value);
        }

        // PUT: api/Bog/5
        [HttpPut("{Isbn}")]
        public void Put(string Isbn, [FromBody] Bog value)
        {
            boglist.ForEach(bog =>
            {
                if (bog.Isbn == Isbn)
                {
                    bog.Forfatter = value.Forfatter;
                    bog.SideTal = value.SideTal;
                    bog.Titel = value.Titel;
                }
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Isbn}")]
        public void Delete(string Isbn)
        {
            boglist.Remove(Get(Isbn));
        }
    }
}
