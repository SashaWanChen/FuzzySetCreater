using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class UnaryOperatedFuzzySet : FuzzySet
    {
        static int count = 0;
        UnaryFSOperator theOperator;
        FuzzySet theFS;

        [TypeConverter( typeof(ExpandableObjectConverter))]
        public UnaryFSOperator TheOperator { get => theOperator; }
        public FuzzySet TheBase { get => theFS; }
        public override void SaveFile(StreamWriter sw)
        {
            // call parent
            sw.WriteLine($"FuzzySetType:{this.GetType().Name}");
            theOperator.SaveFile(sw);

            sw.WriteLine($"OperandHashCode:{theFS.GetHashCode()}");
            //Same as parent FS
            sw.WriteLine($"OriginHashCode:{this.GetHashCode()}");
            sw.WriteLine($"Title:{title}");
        }
        public override void ReadFile(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            Title = items[1];
            //no parameter
        }

        //same FS Set
        public UnaryOperatedFuzzySet( FuzzySet fs, UnaryFSOperator op) : base( fs.TheUniverse )
        {
            theFS = fs;
            theOperator = op;
            SetBrowsableValue("Core", false);
            title = theOperator.Title + theFS.Title + $"{++count}";
            //if (theOperator.Title == "Cut") SetBrowsableValue("CutValue", true);
            // subscribe events
            theFS.ParameterChanged += TheFS_ParameterChanged;
            TheOperator.ParameterChanged += TheFS_ParameterChanged;
        }

        private void TheFS_ParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries) UpdateSeriesDataPoints();

            //Fire event
            FireParameterChangedEvent();
        }

        public override double GetMembershipDegree(double x)
        {
            double a = theFS.GetMembershipDegree(x);
            return theOperator.Evaluate(a);
        }
    }
}
