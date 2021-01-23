using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class LRFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("Center point.")]
        public double Center
        {
            set
            {
                parameters[2] = value;
                FireParameterChangedEvent();
            }
            get
            {
                return parameters[2];
            }
        }
        [Category("Member Function Parameter")]
        [Description("alpha.")]

        public double Alpha
        {
            set
            {
                parameters[0] = value;
                FireParameterChangedEvent();
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Beta")]
        public double beta
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
        public LRFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            SetBrowsableValue("Core", true);
            parameters[0] = u.Minimum + (u.Maximum - u.Minimum) / 2.0 + randomizer.NextDouble(); // Center
            parameters[1] = randomizer.NextDouble() * (u.Maximum - u.Minimum); // alpha
            parameters[2] = randomizer.NextDouble() * (u.Maximum - parameters[0]); //bata
            title = $"Left-Right FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0])
            {
                return Math.Max(0.0, (double) Math.Sqrt(1-((parameters[0] - x) * (parameters[0] - x) / parameters[1] / parameters[1])));
            }
            else if (x >= parameters[0])
            {
                return Math.Exp(- Math.Abs((x - parameters[0]) / parameters[2]) * Math.Abs((x - parameters[0]) / parameters[2]) * Math.Abs((x - parameters[0]) / parameters[2]));
            }
            else
            {
                return 0;
            }

        }
    }
}
