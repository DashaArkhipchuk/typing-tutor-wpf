using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfAppExam.Data;
using WpfAppExam.Model;

namespace WpfAppExam.ResultViewModel
{
    internal class ResultViewModel : DependencyObject
    {
        public string FilterByName
        {
            get { return (string)GetValue(FilterByNameProperty); }
            set { SetValue(FilterByNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterByName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterByNameProperty =
            DependencyProperty.Register("FilterByName", typeof(string), typeof(ResultViewModel),
               new PropertyMetadata("", filterChanged));

        private static void filterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ResultViewModel THIS)
            {
                THIS.ItemsResults.Filter = null;
                THIS.ItemsResults.Filter = THIS.PredicateByName;
            }
        }
        private bool PredicateByName(object obj)
        {
            if (obj is Model.Result st)
                return st.ToString().Contains(FilterByName);
            return false;
        }
        //Collection students
        public ICollectionView ItemsResults
        {
            get { return (ICollectionView)GetValue(ItemsResultsProperty); }
            set { SetValue(ItemsResultsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsStudents.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsResultsProperty =
            DependencyProperty.Register("ItemsResults", typeof(ICollectionView), typeof(ResultViewModel), new PropertyMetadata(null));

        //List<Models.Student> list;
        private readonly ObservableCollection<Model.Result> results;
        public ResultViewModel()
        {
            results = new ObservableCollection<Model.Result>(new Data.ListResults().GetResults());
            ItemsResults = CollectionViewSource.GetDefaultView(results);
            AddResult = new Service.RelayCommand(AddResultToList, canAddRes);
            SaveResults = new Service.RelayCommand(SaveResultsToFile, canSaveRes);
            FilterByName = "";
            ItemsResults.Filter = PredicateByName;
        }
        public ICommand AddResult { get; }

        private void AddResultToList(object obj)
        {
            if (obj is Model.Result res)
                results.Add(res);


        }
        private bool canAddRes(object obj)
        {
            if (obj is Model.Result r)
            {
                bool b1 = true, b2 = true;
                b1 = !(String.IsNullOrWhiteSpace(r.Name)
                    || String.IsNullOrWhiteSpace(r.Speed.ToString())
                    || String.IsNullOrWhiteSpace(r.TimeSeconds.ToString())
                    || String.IsNullOrWhiteSpace(r.NumberFails.ToString())
                    || r.dateTime > DateTime.Now);
                foreach (var item in results)
                {
                    if (item.Speed == r.Speed
                        && item.NumberFails == item.NumberFails
                        && item.TimeSeconds == item.TimeSeconds
                        && item.dateTime == item.dateTime)
                        b2 = false;
                }
                return b1 && b2;
            }

            return false;
        }

        public ICommand SaveResults { get; }

        private void SaveResultsToFile(object obj)
        {
             FilterByName = "";
             ListResults.BinarySave<ObservableCollection<Result>>(results, "Serealization.bin");
        }
        private bool canSaveRes(object obj)
        {
            return results.Count > 0;
        }
    }
}
