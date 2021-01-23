using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class BellFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("The width of the symmetric point.")]
        public double Width
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
        [Description("Slope")]
        public double Slope
        {
            set
            {
                if (value >= 0) 
                { 
                    parameters[1] = value;
                    FireParameterChangedEvent();
                } 
                else
                {
                    MessageBox.Show("Slope must greater than 0.");
                }
            }
            get
            {
                return parameters[1];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Center"), DisplayName("對稱中心")]
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
        public override string Core => $"{theUniverse.Title}={parameters[2]}";
        public override bool IsMonotonic => false;

        public BellFuzzySet(Universe u) : base(u)
        {
            SetBrowsableValue("Core", true);
            parameters = new double[3];
            parameters[0] = randomizer.NextDouble() * 3.0;
            parameters[1] = randomizer.NextDouble() * 3.0;
            parameters[2] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
            title = $"Bell{++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            double y = 1 / (1 + Math.Pow(Math.Abs((x - parameters[2]) / parameters[0]), 2.0 * parameters[1]));
            return y;
        }
    }
}
