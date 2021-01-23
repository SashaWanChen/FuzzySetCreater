using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class GaussianFuzzySet : FuzzySet
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
        [Category("Member Function Parameter")]
        [Description("Standard Deviation"), DisplayName("標準差")]
        public double StandardDeviation
        {
            set
            {
                parameters[1] = value;
                FireParameterChangedEvent();
            }
            get
            {
                return parameters[1];
            }
        }
        public override string Core => $"{theUniverse.Title}={parameters[0]}";
        public override bool IsMonotonic => false;
        public GaussianFuzzySet( Universe u) : base( u )
        {
            SetBrowsableValue("Core", true);
            parameters = new double[2];
            parameters[0] = u.Minimum +  randomizer.NextDouble() * (u.Maximum - u.Minimum); //center
            parameters[1] = randomizer.NextDouble() * 2 * (u.Maximum - u.Minimum) / 10.0; //std
            title = $"Gaussian FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / parameters[1] / parameters[1]);
        }
    }
}
