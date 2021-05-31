using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athletics.Exceptions;
using Athletics.Model;
using Athletics.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athletics.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class AthleteController : Controller
    {
        private IAthleteService service;

        public AthleteController(IAthleteService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AthleteModel>> GetAthletes()
        {
            try
            {
                return Ok(service.GetAthletes());
            }
            catch (BadOperationRequest ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<AthleteModel> GetAthlete(int id)
        {
            try
            {
                return Ok(service.GetAthlete(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteAthlete(int id)
        {
            try
            {
                return Ok(service.DeleteAthlete(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<AthleteModel> CreateAthlete([FromBody] AthleteModel athlete)
        {
            try
            {
                var newAthlete = service.CreateAthlete(athlete);
                return Created($"/api/Athlete/{newAthlete.Id}", newAthlete);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<bool> UpdateAthlete(int id,[FromBody]AthleteModel athlete)
        {
            try
            {
                return Ok(service.UpdateAthlete(id, athlete));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


    }
}