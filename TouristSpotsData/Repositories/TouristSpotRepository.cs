using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class TouristSpotRepository : RepositoryBase<TouristSpot>, ITouristSpotRepository
    {
        public IEnumerable<TouristSpot> getByName(TouristSpot filter)
        {
            return (DbContext.TouristSpot.Where(p => p.nome.Contains(filter.nome)).ToList());
        }

        public IEnumerable<TouristSpot> getTouristSpotsByRadius(double lat, double lng, double radius = 5)
        {
            var list = DbContext.TouristSpot.ToList();

            foreach (var item in list)
            {
                // Aqui teria que criar o calculo para definir se o ponto esta ou não dentro do raio padrão
            }

            return list;
            //throw new System.NotImplementedException();
        }
    }
}
