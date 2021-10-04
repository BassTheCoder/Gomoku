using Gomoku.Contracts.Models;
using Gomoku.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        // GET: PlayersController
        [HttpGet]
        public ActionResult<ICollection<PlayerResponse>> Index()
        {
            return Ok(_databaseContext.Players.ToList());
        }
    }
}
