using System.ComponentModel.DataAnnotations.Schema;
using TouristSpotsDomain.Base;

namespace TouristSpotsDomain.Entities
{
    public class FavoriteTouristSpot : BaseEntity
    {
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public User User { get; set; }

        public int idTouristSpot { get; set; }
        [ForeignKey("idTouristSpot")]
        public TouristSpot TouristSpots { get; set; }
    }
}
