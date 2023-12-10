using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb
{
    public interface PlantRepository
    {
        List<Plant> GetAllPlants();
        void AddPlant(Plant plant);
        void RemovePlant(Plant plant);
        Plant GetPlantById(int plantId);
        List<Plant> SearchPlants(string searchText);
    }
}
