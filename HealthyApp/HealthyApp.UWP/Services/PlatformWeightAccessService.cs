using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using HealthyApp.Interfaces;
using HealthyApp.Models;
using HealthyApp.Services;
using HealthyApp.UWP.Services;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformWeightAccessService))]

namespace HealthyApp.UWP.Services
{
    public class PlatformWeightAccessService : IWeightAccessService
	{
        private const string Key = "Measures";
        private List<WeightMeasure> _mesures = new List<WeightMeasure>();

	    public Task<IEnumerable<WeightMeasure>> GetLastMeasures()
		{
		    if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Key))
		    {
			    var json= ApplicationData.Current.LocalSettings.Values[Key] as string;
			    var data = JsonConvert.DeserializeObject<WeightMeasure[]>(json);
				_mesures = new List<WeightMeasure>(data);
		    }
		    else
		    {
		        AddMeasure(new WeightMeasure
		        {
		            Measure = "74",
		            TakenAt = new DateTimeOffset(new DateTime(2017, 10, 27, 8, 0, 0)).ToString()
		        });
		        AddMeasure(new WeightMeasure
		        {
		            Measure = "72",
		            TakenAt = new DateTimeOffset(new DateTime(2017, 10, 29, 8, 0, 0)).ToString()
		        });
		        AddMeasure(new WeightMeasure
		        {
		            Measure = "70",
		            TakenAt = new DateTimeOffset(new DateTime(2017, 11, 1, 8, 0, 0)).ToString()
		        });

            }
		    return Task.FromResult((IEnumerable<WeightMeasure>)_mesures);
		}

		public void AddMeasure(WeightMeasure weightMesure)
		{
			_mesures.Insert(0, weightMesure);
		    Persist(_mesures);
		}

	    public void Persist(IEnumerable<WeightMeasure> measures)
	    {
			ApplicationData.Current.LocalSettings.Values[Key] = JsonConvert.SerializeObject(measures);
        }
    }
}
