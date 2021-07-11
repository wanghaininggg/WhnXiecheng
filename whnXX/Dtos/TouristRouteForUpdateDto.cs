using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using whnXX.ValidationAttributes;

namespace whnXX.Dtos
{
    //[TouristRouteMustBeDifferentFromDescriptionAttribute]
    public class TouristRouteForUpdateDto : TouristRouteForMaipulationDto
    {
        //[Required(ErrorMessage = "title 不可为空")]
        //[MaxLength(100)]
        //public string Title { get; set; }

        [Required(ErrorMessage = "更新不能为null")]
        [MaxLength(100)]

        // 加override 报错，父类不是虚函数
        public override string Description { get; set; }

        //public decimal OriginalPrice { get; set; }

        //public decimal Price { get; set; }
        ////public double? DiscountPresent { get; set; }

        //public DateTime CreateTime { get; set; }

        //public DateTime? UpdateTime { get; set; }

        //public DateTime? DepartureTime { get; set; }

        //public string Features { get; set; }

        //public string Fees { get; set; }

        //public string Notes { get; set; }

        //public double? Rating { get; set; }
        //public string TravelDays { get; set; }

        //public string TripType { get; set; }

        //public string DepartureCity { get; set; }
        //public ICollection<TouristRoutePictureForCreationDto> TouristRoutePictures { get; set; }

        //        = new List<TouristRoutePictureForCreationDto>();
    }
}
