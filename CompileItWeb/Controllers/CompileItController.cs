using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompileIt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompileItWeb.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CompileItController : ControllerBase
    {
        private ICompileItGame _game;

        public CompileItController(ICompileItGame game)
        {
            _game = game;
        }

        [HttpGet]
        [Route("api/odds")]
        public ActionResult<string> GetOdds()
        {
            return _game.Odds.ToString("N2");
        }

        [HttpGet]
        [Route("api/start")]
        public ActionResult<string> StartGame()
        {
            string result = "Game Started";
            try
            {
                _game.Start();
            }
            catch (NoPlayersException)
            {
                result = "This game has no players.";
            }
            return result;
        }

        [HttpGet]
        [Route("api/players")]
        public ActionResult<List<string>> GetPlayers()
        {
            List<string> result = new List<string>();
            _game.Players.ForEach(m => result.Add(m.Name));
            return result;
        }

        [HttpPost]
        [Route("api/player")]
        public void AddPlayer([FromBody] Test name)
        //public void AddPlayer(Test name)
        {   
            _game.AddPlayer(name.ToString());
        }

        [HttpDelete("{name}")]
        [Route("api/player")]
        public void DeletePlayer(int index)
        {
            
        }
    }
}