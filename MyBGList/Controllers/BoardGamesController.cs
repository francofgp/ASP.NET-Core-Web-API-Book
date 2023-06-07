﻿using Microsoft.AspNetCore.Mvc;
using MyBGList.DTO;

namespace MyBGList.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
    [Route("[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        //private readonly ILogger<BoardGamesController> _logger;


        [HttpGet(Name = "GetBoardGames")]
        public RestDTO<BoardGame[]> Get()
        {
            return new RestDTO<BoardGame[]>()
            {
                Data = new BoardGame[] {
                    new BoardGame() {
                    Id = 1,
                    Name = "Axis & Allies",
                    Year = 1981
                    },
                    new BoardGame() {
                    Id = 2,
                    Name = "Citadels",
                    Year = 2000
                    },
                    new BoardGame() {
                    Id = 3,
                    Name = "Terraforming Mars",
                    Year = 2016
                    }
                },

                Links = new List<LinkDTO> {
                    new LinkDTO(
                    Url.Action(null, "BoardGames", null, Request.Scheme)!,
                    "self",
                    "GET"),
                }
            };
        }
    }
}
