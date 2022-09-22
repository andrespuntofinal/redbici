using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackCRUD.Models;
using BackCRUD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackCRUD.Controllers
{


    [Route("api/[controller]")]
    [ApiController]


    public class BicicletasController : Controller
    {

        private IBiciCollection db = new BiciCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllBicicletas()
        {

            try
            {

                return Ok(await db.GetAllBicicletas());

            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBicicletasDetails(string id)
        {

            return Ok(await db.GetBicicletasById(id));


        }


        [HttpPost]

        public async Task<IActionResult> CreateBicicletas([FromBody] Bicicletas bicicleta)
        {
            if (bicicleta == null)
                return BadRequest();

            if (bicicleta.IdBicicleta == 0)
            {

                ModelState.AddModelError("Id Bici", "El id no debe ir vacío");


            }

            await db.InsertBici(bicicleta);


            return Created("Created", true);



        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBicicletas([FromBody] Bicicletas bicicleta, string id)
        {
            if (bicicleta == null)
                return BadRequest();

            if (bicicleta.IdBicicleta == 0)
            {

                ModelState.AddModelError("Id Bici", "El id no debe ir vacío");


            }

            bicicleta.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateBici(bicicleta);


            return Created("Created", true);



        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBicicletas(string id)
        {

            await db.DeleteBici(id);

            return NoContent();
        }

    }
}
