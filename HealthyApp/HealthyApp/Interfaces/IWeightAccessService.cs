using System.Collections.Generic;
using System.Threading.Tasks;
using HealthyApp.Models;

namespace HealthyApp.Interfaces
{
    public interface IWeightAccessService
    {
        Task<IEnumerable<WeightMeasure>> GetLastMeasures();
        void AddMeasure(WeightMeasure weightMesure);
        void Persist(IEnumerable<WeightMeasure> measures);

    }
}