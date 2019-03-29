using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompileIt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompileItWebApi
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CompileItController : ControllerBase
    {
        private ICompileItGame _game;

        public CompileItController(ICompileItGame game)
        {
            _game = game;
        }
        
        [HttpGet]
        [Route("api/start")]
        public ActionResult<Status> StartGame()
        {
            Status result = null;
            try
            {
                _game.Start();
                result = new Status(true, "Game Started");
            }
            catch (Exception)
            {
                result = new Status(false, "This game has no players.");
            }
            return UpdateStatus(result);
        }

        [HttpGet]
        [Route("api/players")]
        public ActionResult<Players> GetPlayers()
        {
            Players result = new Players();
            try
            {
                List<string> names = new List<string>();
                _game.Players.ForEach(m => names.Add(m.Name));
                result.GamePlayers = names;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccessful = false;
            }
            return (Players) UpdateStatus(result);
        }

        [HttpGet]
        [Route("api/rolldice")]
        public ActionResult<Status> RollDice()
        {
            Status result = null;
            try
            {
                _game.RollDice();
                result = new Status();
            }
            catch (Exception ex)
            {
                result = new Status(false, ex.Message);
            }
            return UpdateStatus(result);
        }

        [HttpGet]
        [Route("api/passturn")]
        public ActionResult<Status> PassTurn()
        {
            Status result = null;
            try
            {
                _game.PassTurn();
                result = new Status();
            }
            catch (Exception ex)
            {
                result = new Status(false, ex.Message);
            }
            return UpdateStatus(result);
        }

        [HttpGet]
        [Route("api/status")]
        public ActionResult<Status> GetStatus()
        {
            Status result = new Status();
            return UpdateStatus(result);
        }

        [HttpPost]
        [Route("api/player")]
        public ActionResult<Status> AddPlayer([FromBody] Player player)
        {
            Status result = null;
            try
            {
                _game.AddPlayer(player.Name);
                result = new Status();
            }
            catch(Exception ex)
            {
                result = new Status(false, ex.Message);
            }
            return UpdateStatus(result);
        }

        [HttpDelete("{name}")]
        [Route("api/player/{name}")]
        public ActionResult<Status> RemovePlayer(string name)
        {
            Status result = null;
            try
            {
                _game.RemovePlayer(name);
                result = new Status();
            }
            catch (Exception ex)
            {
                result = new Status(false, ex.Message);
            }
            return UpdateStatus(result);
        }

        [HttpDelete]
        [Route("api/players")]
        public ActionResult<Status> RemoveAllPlayers()
        {
            Status result = null;
            try
            {
                _game.RemoveAllPlayers();
                result = new Status();
            }
            catch (Exception ex)
            {
                result = new Status(false, ex.Message);
            }
            return UpdateStatus(result);
        }

        private Status UpdateStatus(Status status)
        {
            if (_game.CurrentPlayerStatus != null)
            {
                status.TurnStatus = new TurnStatus(_game.CurrentPlayerStatus);
                status.GameStatus.CurrentPlayer = _game.CurrentPlayerName;
                status.GameStatus.HasWinner = _game.HasWinner;
                status.GameStatus.IsLastRound = _game.IsLastRound;
                status.GameStatus.IsTurnOver = _game.IsTurnOver;
            }
            else
            {
                status.Message = "The game does not have any players yet.";
            }

            return status;
        }
    }
}