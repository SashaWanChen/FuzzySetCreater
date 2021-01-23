using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class StepUpFuzzySet : FuzzySet
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
        [Description("Right point.")]
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

        public override string Core => $"{parameters[1]}<={theUniverse.Title}";
        public override bool IsMonotonic => true;
        public StepUpFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            SetBrowsableValue("Core", true);
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 3.0;
            parameters[1] = parameters[0] + randomizer.NextDouble() * (u.Maximum - parameters[0]) / 2.0;
            title = $"StepUp FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0])
            {
                double y = 0.0;
                return y;
            }
            else if (parameters[0] <= x & x <= parameters[1])
            {
                double y = (x - parameters[0]) / (parameters[1] - parameters[0]);
                return y;
            }
            else
            {
                return 1;
            }
        }
    }
}
