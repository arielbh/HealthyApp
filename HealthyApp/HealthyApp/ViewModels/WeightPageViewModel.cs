using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HealthyApp.Interfaces;
using HealthyApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms;

namespace HealthyApp.ViewModels
{
    public class WeightPageViewModel : BindableBase
    {

        public async Task Appeared()
        {
            Measures = new ObservableCollection<WeightMeasure>(
                await WeightAccessService.GetLastMeasures());
        }


        private DelegateCommand<string> _addMeasureCommand;

        public DelegateCommand<string> AddMeasureCommand
        {
            get
            {
                return _addMeasureCommand ?? (_addMeasureCommand = new DelegateCommand<string>(
                           p =>
                           {
                               var measure = new WeightMeasure
                               {
                                   Measure = p,
                                   TakenAt = DateTimeOffset.Now.ToString()
                               };
                               WeightAccessService.AddMeasure(measure);
                               Measures.Insert(0, measure);
                           },
                           p => !string.IsNullOrEmpty(p)));
            }
        }

        private ObservableCollection<WeightMeasure> _measures;

        public ObservableCollection<WeightMeasure> Measures
        {
            get { return _measures; }
            set
            {
                if (value != _measures)
                {
                    _measures = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        [Microsoft.Practices.Unity.Dependency]
        public IWeightAccessService WeightAccessService { get; set; }
    }
}