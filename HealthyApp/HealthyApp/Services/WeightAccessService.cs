using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthyApp.Interfaces;
using HealthyApp.Models;

namespace HealthyApp.Services
{
    public class WeightAccessService : IWeightAccessService
    {
        private readonly List<WeightMeasure> _mesures = new List<WeightMeasure>();
        public void AddMeasure(WeightMeasure weightMesure)
        {
            _mesures.Add(weightMesure);
        }

        public void Persist(IEnumerable<WeightMeasure> measures)
        {
        }

        public Task<IEnumerable<WeightMeasure>> GetLastMeasures()
        {
            AddMeasure(new WeightMeasure
            {
                Measure = "100",
                TakenAt = new DateTimeOffset(new DateTime(2017, 11, 1, 8, 0, 0)).ToString()
            });
            AddMeasure(new WeightMeasure
            {
                Measure = "102",
                TakenAt = new DateTimeOffset(new DateTime(2017, 10, 29, 8, 0, 0)).ToString()
            });
            AddMeasure(new WeightMeasure
            {
                Measure = "104",
                TakenAt = new DateTimeOffset(new DateTime(2017, 10, 27, 8, 0, 0)).ToString()
            });  
            Persist(_mesures);
            return Task.FromResult((IEnumerable<WeightMeasure>)_mesures);
        }
    }
}