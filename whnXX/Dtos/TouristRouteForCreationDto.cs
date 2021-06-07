using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using whnXX.ValidationAttributes;

namespace whnXX.Dtos
{
    // DTo 不需要合并，应该保持互相独立
    [TouristRouteMustBeDifferentFromDescriptionAttribute]
    public class TouristRouteForCreationDto  //: IValidatableObject
    {
        [Required(ErrorMessage ="title 不可为空")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "描述 不可为空")]
        [MaxLength(100)]
        public string Description { get; set; }

        //public decimal OriginalPrice { get; set; }

        public decimal Price { get; set; }
        //public double? DiscountPresent { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? DepartureTime { get; set; }
        public string Features { get; set; }

        public string Fees { get; set; }
        public string Notes { get; set; }

        public double? Rating { get; set; }
        public string TravelDays { get; set; }

        public string TripType { get; set; }

        public string DepartureCity { get; set; }
        public ICollection<TouristRoutePictureForCreationDto> TouristRoutePictures { get; set; }

    = new List<TouristRoutePictureForCreationDto>();

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult("路线名称必须与路线描述不一样",
        //            new[] { "TouristRouteForCreationDto" }
        //            );
        //    }
        //}
    }
}
