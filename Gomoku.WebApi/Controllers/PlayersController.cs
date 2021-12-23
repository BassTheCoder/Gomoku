using Gomoku.Contracts.Inputs;
using Gomoku.Contracts.Responses;
using Gomoku.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gomoku.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public PlayersController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: /players
        [HttpGet]
        public ActionResult<ICollection<PlayerResponse>> Index()
        {
            return Ok(_databaseContext.Players.ToList());
            //HTTP 200
        }

        // Get: /players/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public ActionResult<PlayerResponse> Get(Guid id)
        {
            return Ok(new PlayerResponse());
        }

        [HttpPost]
        public ActionResult Create(PlayerInput playerInput)
        {
            return new CreatedResult("/test", null);
            //HTTP 201
        }

        // PATCH /players/{id}
        [HttpPatch]
        [Route("{id:guid}")]
        public ActionResult Update(string playerInput, Guid id)
        {
            //Update player
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            return NoContent();
            //204
        }
    }
}
