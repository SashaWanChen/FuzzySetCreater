using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FuzzySetCreater
{
    class PiFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("The spread on each side of Mf.")]
        public double Spread
        {
            set
            {
                if (value > 0) 
                { 
                    parameters[0] = value;
                    FireParameterChangedEvent();
                } 
                else
                {
                    MessageBox.Show("Enter the number greater than 0. ");
                }
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Center")]
        public double Center
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

        public override string Core => $"{theUniverse.Title} = {parameters[1]}";
        public override bool IsMonotonic => false;
        public PiFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            SetBrowsableValue("Core", true);
            parameters[0] = randomizer.NextDouble() * (u.Maximum - u.Minimum); //spread
            parameters[1] = parameters[0] + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 2.0; //center
            title = $"Pi FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[1]) 
            {
                //S(c-a, c)
                //newL = (parameters[1] - parameters[0]);
                //newR = parameters[1]
                if (parameters[1] < x) return 1;
                else if ((parameters[1] - parameters[0]) < x & x <= ((parameters[1] - parameters[0]) + parameters[1]) / 2.0)
                {
                    double y = 2 * (x - (parameters[1] - parameters[0])) * (x - (parameters[1] - parameters[0])) / (parameters[1] - (parameters[1] - parameters[0])) / (parameters[1] - (parameters[1] - parameters[0]));
                    return y;
                }
                else if (parameters[1] >= x & x > ((parameters[1] - parameters[0]) + parameters[1]) / 2.0)
                {
                    double y = 1 - 2 * (parameters[1] - x) * (parameters[1] - x) / (parameters[1] - (parameters[1] - parameters[0])) / (parameters[1] - (parameters[1] - parameters[0]));
                    return y;
                }
                else // x <= parameters[0]
                    return 0;               
            }
            else
            {
                //Z(c,c+a)
                // newL = parameters[1]
                // newR = (parameters[1] + parameters[0]);
                if ((parameters[1] + parameters[0]) < x) return 0;
                else if (parameters[1] < x & x <= (parameters[1] + (parameters[1] + parameters[0])) / 2.0)
                {
                    double s = 2 * (x - parameters[1]) * (x - parameters[1]) / ((parameters[1] + parameters[0]) - parameters[1]) / ((parameters[1] + parameters[0]) - parameters[1]);
                    return 1 - s;
                }
                else if ((parameters[1] + parameters[0]) >= x & x > (parameters[1] + (parameters[1] + parameters[0])) / 2.0)
                {
                    double s = 1 - 2 * ( (parameters[1] + parameters[0])-x ) * ((parameters[1] + parameters[0])-x) / ((parameters[1] + parameters[0]) - parameters[1]) / ((parameters[1] + parameters[0]) - parameters[1]);
                    return 1 - s;
                }
                else // x <= parameters[0]
                    return 1;
            }
        }
    }
}

