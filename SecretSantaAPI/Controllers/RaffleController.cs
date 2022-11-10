using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Core.Entities;
using SecretSanta.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SecretSantaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaffleController : ControllerBase
    {

        IRaffleService _raffleService;

        public RaffleController(IRaffleService raffleService)
        {
            _raffleService = raffleService;
        }


        /// <summary>
        /// Retrieves random pairs of people that were entered in the request
        /// </summary>
        /// <remarks>Follow the request format</remarks>
        /// <response code="200">Draw successful</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Oops! Can't draw your secret santa right now</response>


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Raffle>))]
        public async Task<IActionResult> GetRaffle([FromBody] RaffleRequest req )
        {
            var res = new ApiResponse<Raffle>(null);
            if (req.People == null | req.People.Count <= 0)
            {
                res = new ApiResponse<Raffle>(null) { Code = 1, Status = "Failed", Message = "No participants provided" };
                return Ok(res);
            }/*
            if (req.People.Count % 2 != 0)
            {
                res = new ApiResponse<Raffle>(null) { Code = 1, Status = "Failed", Message = "Number of participants not even. Provide a consistent number of people." };
                return Ok(res);
            }*/
            if (req.Groups.Count >0)
            {
                Boolean maxGroup = false;
                req.Groups.ForEach(group =>
                {
                    if (group.People.Count > req.People.Count / 2)
                    {
                        maxGroup = true;
                    }
                });
                if (maxGroup)
                {
                    res = new ApiResponse<Raffle>(null) { Code = 1, Status = "Failed", Message = "The number of members in a group is too large for the draw" };
                    return Ok(res);
                }
            }
            var data = _raffleService.SetRaffle(req);
            var raffle = new Raffle(0, data);
            res = new ApiResponse<Raffle>(raffle) { Code = 0, Status = "Ok"}; 

            return Ok(res);
 
        }
    }
}
