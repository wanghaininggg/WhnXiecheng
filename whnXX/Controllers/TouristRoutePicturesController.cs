using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whnXX.Dtos;
using whnXX.Moldes;
using whnXX.Services;

namespace whnXX.Controllers
{
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public TouristRoutePicturesController(
            ITouristRouteRepository touristRouteRepository,
            IMapper mapper
            )
        {
            _touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var picturesFromRepo = _touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);

            // 数组null 或者 长度等于 0
            if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
            {
                return NotFound("照片不存在");
            }

            return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(picturesFromRepo));
        }

        [HttpGet("{pictureId}", Name = "GetPicture")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pircturFromRepo = _touristRouteRepository.GetPicture(pictureId);

            if (pircturFromRepo == null)
            {
                return NotFound("照片不存在");
            }
            return Ok(_mapper.Map<TouristRoutePictureDto>(pircturFromRepo));
        }

        [HttpPost]
        public IActionResult CreateTouristRoutePicture([FromRoute] Guid touristRouteId,
            [FromBody] TouristRoutePictureForCreationDto touristRoutePictureForCreation
            )
        {
            //先判断是否已经存在

            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pictureModel = _mapper.Map<TouristRoutePicture>(touristRoutePictureForCreation);

            _touristRouteRepository.AddTouristPictureRoutePicture(touristRouteId, pictureModel);

            _touristRouteRepository.Save();

            var pictureToReturn = _mapper.Map<TouristRoutePictureDto>(pictureModel);
            return CreatedAtRoute(
                "GetPicture",
                new
                {
                    touristRouteId = pictureModel.TouristRouteId,
                    pictureId = pictureModel.Id
                },
                pictureToReturn
                );
        }

        [HttpDelete("{pictureId}")]
        public IActionResult DeletePicture([FromRoute] Guid touristRouteId, [FromRoute] int pictureId )
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pircturFromRepo = _touristRouteRepository.GetPicture(pictureId);

            _touristRouteRepository.DeletePictureRoute(pircturFromRepo);

            _touristRouteRepository.Save();

            return NoContent();
        }

    }
}
