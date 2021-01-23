using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class tsGaussianFuzzySet : FuzzySet
    {
        static int count = 0;

        // properities
        // Attributes
        [Category("Member Function Parameter")]
        [Description("The location of the symmetric point."), DisplayName("對稱中心1")]
        public double Center1
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
                    MessageBox.Show("Enter center1 < center2.");
                }
            }
            get
            {
                return parameters[0];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Standard Deviation"), DisplayName("標準差1")]
        public double StandardDeviation1
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
        [Category("Member Function Parameter")]
        [Description("The location of the symmetric point."), DisplayName("對稱中心2")]
        public double Center2
        {
            set
            {
                if (value > parameters[0])
                {
                    parameters[2] = value;
                    FireParameterChangedEvent();
                }
                else
                {
                    MessageBox.Show("Enter center1 < center2.");
                }
            }
            get
            {
                return parameters[2];
            }
        }
        [Category("Member Function Parameter")]
        [Description("Standard Deviation"), DisplayName("標準差2")]
        public double StandardDeviation2
        {
            set
            {
                parameters[3] = value;

                FireParameterChangedEvent();
            }
            get
            {
                return parameters[3];
            }
        }

        public override string Core => $"{parameters[0]} <= {theUniverse.Title} <= {parameters[2]} ";
        public override bool IsMonotonic => false;
        public tsGaussianFuzzySet(Universe u) : base(u)
        {
            parameters = new double[4];
            SetBrowsableValue("Core", true);
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum) / 2.0;// c1
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() / 10.0; //std
            parameters[2] = parameters[0] + randomizer.NextDouble() * (u.Maximum - parameters[0]);// c2
            parameters[3] = (u.Maximum - u.Minimum) * randomizer.NextDouble() / 10.0; //std
            title = $"two-side Gaussian FS {++count}";
        }
        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0] )
            {
                return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / parameters[1] / parameters[1]); ;
            }
            else if (x >= parameters[2] )
            {
                return Math.Exp(-0.5 * (x - parameters[2]) * (x - parameters[2]) / parameters[3] / parameters[3]); ;
            }
            else // c1<x<c2
                return 1;
        }
    }
}

