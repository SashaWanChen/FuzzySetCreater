using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class SingletonFuzzySet : FuzzySet
    {
        static int count = 0;

        public override double MaxDegree => 1.0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("The location of the symmetric point."), DisplayName("對稱中心")]
        public double Center
        {
            set
            {
                parameters[0] = value;
                UpdateSeriesDataPoints();
                FireParameterChangedEvent();
            }
            get
            {
                return parameters[0];
            }
        }

        public override string Core => $"{theUniverse.Title}={parameters[0]}";
        public override bool IsMonotonic => false;
        public SingletonFuzzySet(Universe u) : base(u)
        {
            SetBrowsableValue("Core", true);
            parameters = new double[2];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum); //center
            title = $"Singleton FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            return Math.Abs(x - Center) < 0.05? 1 : 0;
        }
    }
}