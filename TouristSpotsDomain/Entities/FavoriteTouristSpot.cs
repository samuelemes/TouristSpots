using System.ComponentModel.DataAnnotations.Schema;
using TouristSpotsDomain.Base;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsDomain.Entities
{
    public class FavoriteTouristSpot : BaseEntity
    {
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public AppUser User { get; set; }

        public int idTouristSpot { get; set; }
        [ForeignKey("idTouristSpot")]
        public TouristSpot TouristSpots { get; set; }
    }
}
