using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExam.Model
{
    [SerializableAttribute]
    internal class Result
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int NumberFails { get; set; }
        public int TimeSeconds { get; set; }
        public DateTime dateTime { get; set; }

        public override string ToString()
        {
            return $"| {Name,20} | {Speed,4} | {NumberFails,4} | {TimeSeconds,4} | {dateTime.ToString("dd/MM/yyyy"),20} |";
        }
    }
}
