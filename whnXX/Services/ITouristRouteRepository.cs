using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whnXX.Moldes;

namespace whnXX.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid touristRouteId);
    }
}
