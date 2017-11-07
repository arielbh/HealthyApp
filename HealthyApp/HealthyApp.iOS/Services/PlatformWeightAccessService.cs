using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using HealthyApp.iOS.Services;
using HealthyApp.Interfaces;
using HealthyApp.Models;
using HealthyApp.Services;
using Newtonsoft.Json;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(PlatformWeightAccessService))]

namespace HealthyApp.iOS.Services
{
    class PlatformWeightAccessService : IWeightAccessService
    {
        private const string Key = "Measures";
        private List<WeightMeasure> _mesures = new List<WeightMeasure>();

	    public Task<IEnumerable<WeightMeasure>> GetLastMeasures()
        {
	        var settings = NSUserDefaults.StandardUserDefaults;
	        if (settings[Key] != null)
	        {
		        var json = settings.StringForKey(Key);
		        var data = JsonConvert.DeserializeObject<WeightMeasure[]>(json);

		        _mesures = new List<WeightMeasure>(data);
	        }
	        else
	        {
	            AddMeasure(new WeightMeasure
	            {
	                Measure = "94",
	                TakenAt = new DateTimeOffset(new DateTime(2017, 10, 27, 8, 0, 0)).ToString()
	            });
	            AddMeasure(new WeightMeasure
	            {
	                Measure = "92",
	                TakenAt = new DateTimeOffset(new DateTime(2017, 10, 29, 8, 0, 0)).ToString()
	            });
	            AddMeasure(new WeightMeasure
	            {
	                Measure = "90",
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
            var settings = NSUserDefaults.StandardUserDefaults;
            settings.SetString(JsonConvert.SerializeObject(measures), Key);
            settings.Synchronize();
        }
    }
}