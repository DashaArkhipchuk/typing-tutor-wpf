using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppExam.Model;

namespace WpfAppExam.Data
{
    internal class ListResults
    {
        ObservableCollection<Result> results;
        public ListResults()
        {
            results = new ObservableCollection<Result>();
            if (File.Exists("Serealization.bin"))
            {
                ObservableCollection<Result> list = BinaryLoad("Serealization.bin");
                if (list.Count==0)
                {
                    results.Add(new Result { Name = "Default", NumberFails = 0, Speed = 55, TimeSeconds = 60 });
                }
                else
                {
                    foreach(var item in list)
                    {
                        results.Add(item);
                    }
                }
            }
            else
            {
                results.Add(new Result { Name = "Default", NumberFails = 0, Speed = 55, TimeSeconds = 60 });
            }
        }
        public ObservableCollection<Result> GetResults() => results;

        public static void BinarySave<T>(T obj, string file)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream stream = File.Create(file))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static ObservableCollection<Result> BinaryLoad(string file)
        {
            ObservableCollection<Result> l = new ObservableCollection<Result>();
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (Stream stream = File.OpenRead(file))
                {
                    l =(ObservableCollection<Result>)(formatter.Deserialize(stream));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return l;
        }

    }
}
