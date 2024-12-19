using DotNetBatch14HWH.SnakeAndLadderGame.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14HWH.ConsoleAppSnakeAndLadder
{
    internal class RefitClientService
    {
        public readonly string endpoint = "https://localhost:7152";
        public readonly ISnakeAndLadderApi _client;

        public RefitClientService()
        {
            _client = RestService.For<ISnakeAndLadderApi>(endpoint);
        }

        public async Task<ResponseModel> CreateGameBoard(GameBoardModel RequestGameBoard)
        {
            var model = await _client.CreateGameBoard(RequestGameBoard);
            return model;
        }

        public async Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayerModel)
        {
            var model = await _client.CreateGame(RequestPlayerModel);
            return model;
        }

        public async Task<ResponseModel> PlayGame(int id)
        {
            var model = await _client.PlayGame(id);
            return model;
        }        
    }
}
public interface ISnakeAndLadderApi
{
    [Post("api/SnakeAndLadder/")]
    Task<ResponseModel> CreateGameBoard(GameBoardModel RequestGameBoard);

    [Post("/api/SnakeAndLadder/CreateGame")]
    Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayerModel);

    [Post("/api/SnakeAndLadder/PlayGame/{id}")]
    Task<ResponseModel> PlayGame(int id);
}
