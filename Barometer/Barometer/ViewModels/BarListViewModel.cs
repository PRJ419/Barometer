using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Barometer.Models;
using Barometer.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace Barometer.ViewModels
{
    public class BarListViewModel : BindableBase
    {
        public ObservableCollection<Bar> Bars { get; set; }
        public ListSortDescription Description { get; set; }    

        public BarListViewModel()
        {
            Bars = new ObservableCollection<Bar>(new List<Bar>(){
                new Bar()
            {Name = "Dat Bar", Address = "Peter Bøgh", BarId = 1,
                CVR = 21312213, Email = "Dat@bar.dk", Image = "chess.png",
                AboutText = "Datbar sutter", Rating = 12               
            },
                new Bar()
                {
                    Name = "Katrines kælder", Address = "Katrionebjerg", BarId = 0,
                    CVR = 21203050, Email = "KK@kk.dk", Image = "katrine.png",
                    AboutText = "Katrines kælder er fredagsbar for ingeniørene på katrinebjerg.", Rating = 10

            }
            });
        }


        #region Propertis

        private Bar _currentBar = null;

        public Bar CurrentBar
        {
            get => _currentBar;
            set => SetProperty(ref _currentBar, value);
        }

        #endregion

        #region Commands


        //Skal implementeres når vi skal hente data fra DB
        private ICommand _loadItemsCommand;
        public ICommand LoadItemsCommand
        {
            get
            {
                return _loadItemsCommand ??
                       (_loadItemsCommand = new DelegateCommand(OnLoadItemsCommand));
            }
        }

        private void OnLoadItemsCommand()
        {

        }

        private ICommand _filterItemsCommand;

        public ICommand FilterItemsCommand {
            get {
                Debug.WriteLine("Called");
            return _filterItemsCommand ?? (_filterItemsCommand =
                new DelegateCommand<string>(FilterItemsExecute, FilterItemsCanExecute).ObservesProperty(() => Bars.Count)
            );
            }
        }

    public bool FilterItemsCanExecute(string obj)
        {
            return Bars.Count != 0;
        }

        public void FilterItemsExecute(string obj)
        {            
            //switch (obj)
            //{
            //    case "Name":
            //        var tempBarsName = new ObservableCollection<Bar>(Bars.OrderBy(o => o.Name).ToList());
            //        Bars.Clear();
            //        Bars = tempBarsName;
            //        break;
            //    case "Rating":

            //        Bars.OrderBy(o => o.Rating);
            //        //Bars.Clear();
            //        //Bars = tempBarsRating;
            //        break;
            //    default:
            //        throw new InvalidEnumArgumentException("Couldn't find the item");
            //}

            //foreach (var bar in Bars)
            //{
            //    Console.WriteLine(bar.Rating);                
            //}
        }

        #endregion


    }
}