using System.ComponentModel.DataAnnotations.Schema;
using TouristSpotsDomain.Base;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsDomain.Entities
{
    public class TouristSpotPhoto : BaseEntity
    {
        public int idTouristSport { get; set; }
        [ForeignKey("idTouristSport")]
        public virtual TouristSpot TouristSpots { get; set; }

        public int idUser { get; set; }
        [ForeignKey("idUser")]
        public AppUser User { get; set; }

        public string ImageTitle { get; set; }
        public string Image { get; set; }
    }
}
