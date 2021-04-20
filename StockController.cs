using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JWTAuthentication_TokenBearer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]

    public class StockController : ControllerBase
    {
        private readonly List<Stock> Stocks = new List<Stock>()
{
        new Stock { id = 101, name = "toys", cost = 1200, quantity= 2000},
        new Stock { id = 102, name = "stationary",cost = 1400, quantity= 4000},
        new Stock { id = 103, name = "grocery", cost = 5000, quantity= 8000},
        new Stock { id = 104, name = "tools", cost = 3200, quantity= 5000},
        new Stock { id = 105, name = "cosmetic", cost = 2200, quantity= 1000},

        };
        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return Stocks;
        }
        [HttpGet("{id:int}")]
        public Stock GetOne(int id)
        {
            return Stocks.SingleOrDefault(x => x.id ==id);
        }

    }
}