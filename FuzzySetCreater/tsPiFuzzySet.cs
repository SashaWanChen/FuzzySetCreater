using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class tsPiFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("Left point.")]
        public double SLeft
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
                    MessageBox.Show("Enter the number Sleft < Sright < Zleft < Zright. ");
                }
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Right")]
        public double SRight
        {
            set
            {
                if (value > parameters[0] & value < parameters[2])
                {
                    parameters[1] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number Sleft < Sright < Zleft < Zright. ");
                }
            }
            get
            {
                return parameters[1];
            }
        }

        [Category("Member Function Parameter")]
        [Description("Left point.")]
        public double ZLeft
        {
            set
            {
                if (value < parameters[3] & value > parameters[1])
                {
                    parameters[2] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter the number Sleft < Sright < Zleft < Zright. ");
                }
            }
            get
            {
                return parameters[2];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Right")]
        public double ZRight
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
                    MessageBox.Show("Enter the number Sleft < Sright < Zleft < Zright. ");
                }
            }
            get
            {
                return parameters[3];
            }
        }

        public override string Core => $"{parameters[1]} <= {theUniverse.Title} <= {parameters[2]}";
        public override bool IsMonotonic => false;
        public tsPiFuzzySet(Universe u) : base(u)
        {
            parameters = new double[4];
            SetBrowsableValue("Core", true);
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 4.0;// a
            parameters[1] = parameters[0] + randomizer.NextDouble() * (u.Maximum - parameters[0]) / 3.0;// b
            parameters[2] = parameters[1] + randomizer.NextDouble() * (u.Maximum - parameters[1]) / 2.0;// c
            parameters[3] = parameters[2] + randomizer.NextDouble() * (u.Maximum - parameters[2]);// d
            title = $"two-side Pi FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0] | x >= parameters[3]) return 0;
            else if (x > parameters[0] & x < parameters[1])
            {
                //S(a, b)
                //newL = parameters[0]
                //newR = parameters[1]
                if (parameters[1] < x) return 1;
                else if (parameters[0] < x & x <= (parameters[0] + parameters[1]) / 2.0)
                {
                    double y = 2 * (x - parameters[0]) * (x - parameters[0]) / (parameters[1] - parameters[0]) / (parameters[1] - parameters[0]);
                    return y;
                }
                else if (parameters[1] >= x & x > (parameters[0] + parameters[1]) / 2.0)
                {
                    double y = 1 - 2 * (parameters[1] - x) * (parameters[1] - x) / (parameters[1] - parameters[0]) / (parameters[1] - parameters[0]);
                    return y;
                }
                else // x <= parameters[0]
                    return 0;
            }
            else if (x > parameters[2] & x < parameters[3])
            {
                //Z(c,d)
                //newL = parameters[2]
                //newR = parameters[3]
                if (parameters[3] < x) return 0;
                else if (parameters[2] < x & x <= (parameters[2] + parameters[3]) / 2.0)
                {
                    double s = 2 * (x - parameters[2]) * (x - parameters[2]) / (parameters[3] - parameters[2]) / (parameters[3] - parameters[2]);
                    return 1 - s;
                }
                else if (parameters[3] >= x & x > (parameters[2] + parameters[3]) / 2.0)
                {
                    double s = 1 - 2 * (parameters[3] - x) * (parameters[3] - x) / (parameters[3] - parameters[2]) / (parameters[3] - parameters[2]);
                    return 1 - s;
                }
                else // x <= parameters[2]
                    return 1;
            }
            else // b<x<c
                return 1;
        }
    }
}
