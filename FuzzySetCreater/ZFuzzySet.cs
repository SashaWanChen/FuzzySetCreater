using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class ZFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("Left point.")]
        public double Left
        {
            set
            {
                if (value < parameters[1])
                {
                    parameters[0] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < right. ");
                }
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Right")]
        public double Right
        {
            set
            {
                if (value > parameters[0])
                {
                    parameters[1] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < right. ");
                }
            }
            get
            {
                return parameters[1];
            }
        }

        public override string Core => $"{theUniverse.Title} <= {parameters[0]}";
        public override bool IsMonotonic => true;
        public ZFuzzySet(Universe u) : base(u)
        {
            SetBrowsableValue("Core", true);
            parameters = new double[2];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 3.0;
            parameters[1] = parameters[0] + randomizer.NextDouble() * (u.Maximum - parameters[0]) / 2.0;
            title = $"Z FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (parameters[1] < x) return 0;
            else if (parameters[0] < x & x <= (parameters[0] + parameters[1]) / 2.0)
            {
                double s = 2 * (x - parameters[0]) * (x - parameters[0]) / (parameters[1] - parameters[0]) / (parameters[1] - parameters[0]);
                return 1 - s;
            }
            else if (parameters[1] >= x & x > (parameters[0] + parameters[1]) / 2.0)
            {
                double s = 1 - 2 * (parameters[1] - x) * (parameters[1] - x) / (parameters[1] - parameters[0]) / (parameters[1] - parameters[0]);
                return 1 -s;
            }
            else // x <= parameters[0]
                return 1;
        }
    }
}

