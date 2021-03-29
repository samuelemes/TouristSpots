using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TouristSpotsDomain.Base;

namespace TouristSpotsDomain.Entities
{
    public class TouristSpot : BaseEntity
    {
        public TouristSpot()
        {
            Photos = new HashSet<TouristSpotPhoto>();
            //FavoriteTouristSpot = new HashSet<FavoriteTouristSpot>();
        }
        public string nome { get; set; }
        public double? nu_lat { get; set; }
        public double? nu_lng { get; set; }

        public int idCategoria { get; set; }
        [JsonIgnore]
        [ForeignKey("idCategoria")]
        public virtual Category Category { get; set; }

        public ICollection<TouristSpotPhoto> Photos { get; set; }

        //public virtual ICollection<FavoriteTouristSpot> FavoriteTouristSpot { get; set; }
    }
}
