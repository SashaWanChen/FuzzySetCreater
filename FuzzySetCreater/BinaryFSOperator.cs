using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class BinaryFSOperator
    {
        protected static Random rnd = new Random();
        //properties
        public virtual string Title { get => ""; }

        // event
        public event EventHandler ParameterChanged;

        // public virtual double Evaluate( double a) { throw new Exception("No implemented"); }
        public virtual double Evaluate(double a, double b) { throw new Exception("No implemented"); }// { return 0.0; }
        protected void FireParameterChangedEvent()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }
    }
    class Union : BinaryFSOperator
    {
        public override string Title => "Union";

        public override double Evaluate(double a,double b)
        {
            return Math.Max(a,b);
        }
    }
    class Intersection : BinaryFSOperator
    {
        public override string Title => "Intersection";

        public override double Evaluate(double a, double b)
        {
            return Math.Min(a,b);
        }
    }
    class TMin : BinaryFSOperator
    {
        public override string Title => "Minimum T-norm";

        public override double Evaluate(double a, double b)
        {
            return Math.Min(a, b);
        }
    }
    class Tap : BinaryFSOperator
    {
        public override string Title => "Algebraic product";

        public override double Evaluate(double a, double b)
        {
            return a*b;
        }
    }
    class Tbp : BinaryFSOperator
    {
        public override string Title => "Bounded product";

        public override double Evaluate(double a, double b)
        {
            return Math.Max(0, (a+b-1));
        }
    }
    class Tdp : BinaryFSOperator
    {
        public override string Title => "Drastic product";

        public override double Evaluate(double a, double b)
        {
            if ( b >= 0.998 && b <= 1.002 ) return a;
            else if ( a >= 0.998 && a <= 1.002 ) return b;
            else return 0;// if(a < 1 && b < 1) 
        }
    }
    class SMax : BinaryFSOperator
    {
        public override string Title => "Maximum S-norm";

        public override double Evaluate(double a, double b)
        {
            return Math.Max(a, b);
        }
    }
    class Sas : BinaryFSOperator
    {
        public override string Title => "Algebraic sum S-norm";

        public override double Evaluate(double a, double b)
        {
            return a +b - a * b;
        }
    }
    class Sbs : BinaryFSOperator
    {
        public override string Title => "Bounded sum S-norm";

        public override double Evaluate(double a, double b)
        {
            return Math.Min(1, (a + b));
        }
    }
    class Sds : BinaryFSOperator
    {
        public override string Title => "Drastic sum S-norm";

        public override double Evaluate(double a, double b)
        {
            if (b >= -0.998 && b <= 0.002) return a;
            else if (a >= -0.998 && a <= 0.002) return b;
            else return 0;// if(a < 1 && b < 1) 
        }
    }
}
