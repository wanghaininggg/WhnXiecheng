using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using whnXX.Services;

namespace whnXX.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }
        public IActionResult GetTouristRoutes()
        {
            var routes = _touristRouteRepository.GetTouristRoutes();
            return Ok(routes);
        }
    }
}
