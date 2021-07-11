using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using whnXX.Dtos;
using whnXX.Helper;
using whnXX.Moldes;
using whnXX.ResourceParameters;
using whnXX.Services;

namespace whnXX.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase //Controller
    {
        private ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public TouristRoutesController(
            ITouristRouteRepository touristRouteRepository,
            IMapper mapper
            )
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
            
        }
        // api/touristRoutes?keyword=传入的参数
        [HttpGet]
        [HttpHead]
        public IActionResult GetTouristRoutes(
            [FromQuery]TouristRouteResourceParamaters paramaters
            // [FromQuery]string keyword, string rating

            )
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes(paramaters.Keyword, paramaters.RatingOperator, paramaters.RatingValue);

            if (touristRoutesFromRepo == null || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRoutesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRoutesFromRepo);
            return Ok(touristRoutesDto);
        }


        // api/touristroutes/{touristRouteId}
        // Status Code
        [HttpGet("{touristRouteId}", Name = "GetTouristRouteById")]
        [HttpHead]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound("没有旅游路线");
            }
            //var touristRouteDto = new TouristRouteDto() {
            //    Id = touristRouteFromRepo.Id,
            //    Title = touristRouteFromRepo.Title,
            //    Description = touristRouteFromRepo.Description,
            //    Price = touristRouteFromRepo.OriginalPrice * (decimal)(touristRouteFromRepo.DiscountPresent),
            //    CreateTime = touristRouteFromRepo.CreateTime,
            //    UpdateTime = touristRouteFromRepo.UpdateTime,
            //    Features = touristRouteFromRepo.Features,
            //    Fees = touristRouteFromRepo.Fees,
            //    Notes = touristRouteFromRepo.Notes,
            //    Rating = touristRouteFromRepo.Rating,
            //    TravelDays = touristRouteFromRepo.TravelDays.ToString(),
            //    TripType = touristRouteFromRepo.TripType.ToString(),
            //    DepartureCity = touristRouteFromRepo.DepartureCity.ToString()
            //};

            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }

        [HttpPost]
        public IActionResult CreateTouristRoute([FromBody] TouristRouteForCreationDto touristRouteForCreationDto)
        {
            var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteForCreationDto);
            _touristRouteRepository.AddTouristRoute(touristRouteModel);
            _touristRouteRepository.Save();
            var touristRpouteToReturn = _mapper.Map<TouristRouteDto>(touristRouteModel);
            // api 发现
            return CreatedAtRoute("GetTouristRouteById", new { touristRouteId = touristRpouteToReturn.Id},
                touristRpouteToReturn
                );
        }

        [HttpPut("{touristRouteId}")]
        public IActionResult UpdateTouristRoute([FromRoute]Guid touristRouteId,[FromBody] TouristRouteForUpdateDto touristRouteForUpdateDto)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线找不到");
            }

            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);

            // 1. 映射DTO
            // 2. 更新DTO的数据
            // 3. 保存

            _mapper.Map(touristRouteForUpdateDto, touristRouteFromRepo);
            _touristRouteRepository.Save();
            return NoContent();
        }

        [HttpPatch("{touristRouteId}")]
        public IActionResult PartiallyUpdateTouristRoute([FromRoute]Guid touristRouteId,
            [FromBody] JsonPatchDocument<TouristRouteForUpdateDto> patchDocument)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线找不到");
            }

            // 数据模型
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);

            var touristRouteToPatch = _mapper.Map<TouristRouteForUpdateDto>(touristRouteFromRepo);


            patchDocument.ApplyTo(touristRouteToPatch, ModelState);

            // 数据验证
            if (!TryValidateModel(touristRouteToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(touristRouteToPatch, touristRouteFromRepo);
            _touristRouteRepository.Save();

            return NoContent();
        }

        [HttpDelete("{touristRouteId}")]
        public IActionResult DeleteTouristRoute([FromRoute] Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线找不到");
            }

            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);

            _touristRouteRepository.DeleteTouristRoute(touristRouteFromRepo);

            _touristRouteRepository.Save();

            return NoContent();
        }

        [HttpDelete("({touristIDs})")]
        public IActionResult DeleteByIDs([ModelBinder(BinderType = typeof(ArrayModelBinder))][FromRoute]IEnumerable<Guid> touristIDs)
        {
            if (touristIDs == null)
            {
                return BadRequest();
            }

            var touristRoutesFromrepo = _touristRouteRepository.GetTouristRoutesByIDList(touristIDs);

            _touristRouteRepository.DeleteTouristRoutes(touristRoutesFromrepo);

            _touristRouteRepository.Save();
            return NoContent();

        }
    }
}
