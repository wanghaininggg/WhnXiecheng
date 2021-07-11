using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whnXX.Moldes;

namespace whnXX.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string ratingOperator, int? ratingValue);
        TouristRoute GetTouristRoute(Guid touristRouteId);

        bool TouristRouteExists(Guid touristRouteId);

        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);

        TouristRoutePicture GetPicture(int pictureId);
        void AddTouristRoute(TouristRoute touristRoute);

        void AddTouristPictureRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);
        bool Save();

        void DeleteTouristRoute(TouristRoute touristRoute);

        void DeletePictureRoute(TouristRoutePicture touristRoutePicture);

        IEnumerable<TouristRoute> GetTouristRoutesByIDList(IEnumerable<Guid> ids);
        void DeleteTouristRoutes (IEnumerable<TouristRoute> touristRoutes);
    }
}
