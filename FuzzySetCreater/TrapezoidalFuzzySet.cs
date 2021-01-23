using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class TrapezoidalFuzzySet : FuzzySet
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
                    MessageBox.Show("Enter the number left < LPeak <= RPeak < right. ");
                }
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Left peak point.")]
        public double LPeak
        {
            set
            {
                if (value <= parameters[2] & value > parameters[0])
                {
                    parameters[1] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < LPeak <= RPeak < right. ");
                }
            }
            get
            {
                return parameters[1];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Right Peak point.")]
        public double RPeak
        {
            set
            {
                if (value < parameters[3] & value >= parameters[1])
                {
                    parameters[2] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < LPeak <= RPeak < right. ");
                }
            }
            get
            {
                return parameters[2];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Right point.")]
        public double Right
        {
            set
            {
                if (value > parameters[2])
                {
                    parameters[3] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < LPeak <= RPeak < right. ");
                }
            }
            get
            {
                return parameters[3];
            }
        }
        public override string Core => $"{parameters[1]}<={theUniverse.Title}<={parameters[2]}";
        public override bool IsMonotonic => false;
        public TrapezoidalFuzzySet(Universe u) : base(u)
        {
            parameters = new double[4];
            SetBrowsableValue("Core", true);
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 4.0;
            parameters[1] = parameters[0] + randomizer.NextDouble() * (u.Maximum - parameters[0]) / 3.0;
            parameters[2] = parameters[1] + randomizer.NextDouble() * (u.Maximum - parameters[1]) / 2.0;
            parameters[3] = parameters[2] + randomizer.NextDouble() * (u.Maximum - parameters[2]);
            title = $"Trapezoidal FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0] | parameters[3] <= x)
            {
                double y = 0.0;
                return y;
            }
            else if (parameters[0] <= x & x <= parameters[1])
            {
                double y = (x - parameters[0]) / (parameters[1] - parameters[0]);
                return y;
            }
            else if (parameters[1] <= x & x <= parameters[2])
            {
                return 1;
            }
            else if (parameters[2] <= x & x <= parameters[3])
            {
                double y = (parameters[3] - x) / (parameters[3] - parameters[2]);
                return y;
            }
            else
                return 0;
        }
    }
}

