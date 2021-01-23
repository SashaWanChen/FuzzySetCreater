using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class TriangularFuzzySet : FuzzySet
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
                    MessageBox.Show("Enter the number left < peak < right. ");
                }
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Peak point.")]
        public double Peak
        {
            set
            {
                if (value < parameters[2] & value > parameters[0])
                {
                    parameters[1] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < peak < right. ");
                }
            }
            get
            {
                return parameters[1];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Right point.")]
        public double Right
        {
            set
            {
                if (value > parameters[1])
                {
                    parameters[2] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number left < peak < right. ");
                }
            }
            get
            {
                return parameters[2];
            }
        }
        public override string Core => $"{theUniverse.Title}={parameters[1]}";
        public override bool IsMonotonic => false;
        public TriangularFuzzySet(Universe u) : base(u)
        {
            SetBrowsableValue("Core", true);
            parameters = new double[3];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 3.0;
            parameters[1] = parameters[0] + randomizer.NextDouble() * (u.Maximum - parameters[0]) / 2.0;
            parameters[2] = parameters[1] + randomizer.NextDouble() * (u.Maximum - parameters[1]);
            title = $"Triangular FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0] | parameters[2] <= x)
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
                double y = (parameters[2] - x) / (parameters[2] - parameters[1]);
                return y;
            }
            else
                return 0;
        }
    }
}
