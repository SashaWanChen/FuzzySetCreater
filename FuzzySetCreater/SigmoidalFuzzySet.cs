using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class SigmoidalFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("The slope at the crossover point x=c.")]
        public double Slope
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
        [Description("Crossover Point"), DisplayName("拐點")]
        public double CrossoverPoint
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
        public override string Core => $"{theUniverse.Title}=無限大";
        public override bool IsMonotonic => true;
        public SigmoidalFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            SetBrowsableValue("Core", true);
            parameters[0] = randomizer.NextDouble();
            parameters[1] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
            title = $"Sigmoidal{++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            double y = 1 / (1 + Math.Exp(-parameters[0] * (x - parameters[1])));

            return y;
        }
    }
}
