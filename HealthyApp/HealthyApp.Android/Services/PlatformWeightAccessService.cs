using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HealthyApp.Droid.Services;
using HealthyApp.Interfaces;
using HealthyApp.Models;
using HealthyApp.Services;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformWeightAccessService))]

namespace HealthyApp.Droid.Services
{
	public class PlatformWeightAccessService : IWeightAccessService
	{
        private const string Key = "Measures";
        private List<WeightMeasure> _mesures = new List<WeightMeasure>();

		public Task<IEnumerable<WeightMeasure>> GetLastMeasures()
		{
            using (var settings = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {

                if (settings.Contains(Key))
                {
                    var json = settings.GetString(Key, string.Empty);
                    var data = JsonConvert.DeserializeObject<WeightMeasure[]>(json);
                    _mesures = new List<WeightMeasure>(data);
                }
                else
                {
                    AddMeasure(new WeightMeasure
                    {
                        Measure = "84",
                        TakenAt = new DateTimeOffset(new DateTime(2017, 10, 27, 8, 0, 0)).ToString()
                    });
                    AddMeasure(new WeightMeasure
                    {
                        Measure = "82",
                        TakenAt = new DateTimeOffset(new DateTime(2017, 10, 29, 8, 0, 0)).ToString()
                    });
                    AddMeasure(new WeightMeasure
                    {
                        Measure = "80",
                        TakenAt = new DateTimeOffset(new DateTime(2017, 11, 1, 8, 0, 0)).ToString()
                    });
                }
                return Task.FromResult((IEnumerable<WeightMeasure>)_mesures);
            }
		}

		public void AddMeasure(WeightMeasure weightMesure)
		{
			_mesures.Insert(0, weightMesure);
            Persist(_mesures);
		}

	    public void Persist(IEnumerable<WeightMeasure> measures)
	    {
	        using (var settings = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
	        {
	            using (var sharedPreferencesEditor = settings.Edit())
	            {
	                sharedPreferencesEditor.PutString(Key, JsonConvert.SerializeObject(measures));
	                sharedPreferencesEditor.Commit();

	            }
	        }
        }
	}
}