using System.ComponentModel.DataAnnotations.Schema;
using TouristSpotsDomain.Base;

namespace TouristSpotsDomain.Entities
{
    public class TouristSpotPhoto : BaseEntity
    {
        public int idTouristSport { get; set; }
        [ForeignKey("idTouristSport")]
        public virtual TouristSpot TouristSpots { get; set; }

        public int idUser { get; set; }
        [ForeignKey("idUser")]
        public User User { get; set; }

        public string ImageTitle { get; set; }
        public string Image { get; set; }
    }
}
