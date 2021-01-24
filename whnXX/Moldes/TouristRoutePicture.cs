using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace whnXX.Moldes
{
    public class TouristRoutePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }

        // 外键 类名+Id
        [ForeignKey("TouristRouteId")]
        public Guid TouristRouteId { get; set; }
        public TouristRoute TouristRoute{ get; set; }
    }
}
