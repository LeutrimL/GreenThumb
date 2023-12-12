using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GreenThumb.Repository;

namespace GreenThumb
{
    public class Repository : PlantRepository
    {

        private readonly PlantsDbContext _dbContext;

        public Repository(PlantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Plant> GetAllPlants()
        {
            return _dbContext.Plants.ToList();
        }

        public void AddPlant(Plant plant)
        {
            _dbContext.Plants.Add(plant);
            _dbContext.SaveChanges();
        }

        public void AddAdvice(Advice advice)
        {

            if (!_dbContext.Advice.Any(a => a.PlantId == advice.PlantId && a.Description == advice.Description))
            {
                _dbContext.Advice.Add(advice);
                _dbContext.SaveChanges();
            }
        }

        public void RemovePlant(Plant plant)
        {
            _dbContext.Plants.Remove(plant);
            _dbContext.SaveChanges();
        }

        public Plant GetPlantById(int plantId)
        {
            return _dbContext.Plants.Find(plantId);
        }

        public List<Plant> SearchPlants(string searchText)
        {
            return _dbContext.Plants
                .Where(p => p.Name.ToLower().Contains(searchText.ToLower()))
                  .ToList();
        }

        public void AddOrUpdatePlant(Plant plant)
        {

            var existingPlant = _dbContext.Plants
                          .Include(p => p.Advices)
                          .FirstOrDefault(p => p.Plantid == plant.Plantid);

            if (existingPlant != null)
            {
               
                existingPlant.Advices.Clear();

                foreach (var advice in plant.Advices)
                {
                    existingPlant.Advices.Add(advice);
                }
            }
            else
            {
                
                _dbContext.Plants.Add(plant);
            }

            _dbContext.SaveChanges();


        }
    }
}



