using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    abstract class UnaryFSOperator
    {
        protected static Random rnd = new Random();
        //properties
        public virtual string Title { get => ""; }
        public override string ToString()
        {
            return Title;
        }
        // data
        protected double[] parameters;

        // event
        public event EventHandler ParameterChanged;

        // public virtual double Evaluate( double a) { throw new Exception("No implemented"); }
        public abstract double Evaluate(double a); // { return 0.0; }
        protected void FireParameterChangedEvent()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }

        public virtual void SaveFile(StreamWriter sw)
        {
            sw.WriteLine($"OperatorType:{this.GetType().Name}");
            if (parameters == null)
                sw.WriteLine($"NumberOfParameters:0");
            else
            {
                sw.WriteLine($"NumberOfParameters:{parameters.Length}");
                for (int i = 0; i < parameters.Length; i++)
                    sw.WriteLine($"Par{i}:{parameters[i]}");
            }
        }

        public virtual void ReadFile(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            int num = Convert.ToInt32(items[1]);
            parameters = new double[num];
            for(int i = 0; i< num; i++)
            {
                items = sr.ReadLine().Split(':');
                parameters[i] = Convert.ToDouble(items[1]);
            }
        }
    }
    class ScaleOperator:UnaryFSOperator 
    {
        public override string Title => "Scale ";
        public ScaleOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }
        public double ScaleValue
        {
            get => parameters[0];
            set
            {
                parameters[0] = value;
                    // fire event
                FireParameterChangedEvent();
               
            }
        }
        public override double Evaluate(double a)
        {
            return a * parameters[0];
        }
    }
    class NegateOperator : UnaryFSOperator
    {
        public override string Title => "Not ";

        public override double Evaluate(double a)
        {
            return 1.0 - a;
        }
    }
    class ValueCutOperator : UnaryFSOperator
    {
        public override string Title => "Cut ";
        public ValueCutOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }
        public double CutValue
        {
            get => parameters[0];
            set
            {
                if (value >= 0 && value <= 1.0)
                {
                    parameters[0] = value;
                    // fire event
                    FireParameterChangedEvent();
                }
            }
        }
        public override double Evaluate(double a)
        {
            return a >= parameters[0] ? parameters[0] : a;
        }
    }
    class DilationOperator : UnaryFSOperator
        {
            public override string Title => "More/Less "; //DIL

            public override double Evaluate(double a)
            {
                return Math.Sqrt(a);
            }
        }
        class ConcertrationOperator : UnaryFSOperator
        {
            public override string Title => "Very "; // CON

            public override double Evaluate(double a)
            {
                return a * a;
            }
        }
        class ExtremelyOperator : UnaryFSOperator
        {
            public override string Title => "Extremely ";

            public override double Evaluate(double a)
            {
                return a * a * a * a * a * a * a * a;
            }
        }
    class IntensificationOperator : UnaryFSOperator
    {
         public override string Title => "Intensification ";

         public override double Evaluate(double a)
         {
             if(a >= 0 && a <= 0.5) return 2 * a * a ;
             if (a <= 1 && a >= 0.5) return 1 - 2 * (1 - a) * (1 - a);
             else return 0;
         }
    }
    class DiminisherOperator : UnaryFSOperator
    {
        public override string Title => "Diminisher ";

        public override double Evaluate(double a)
        {
            if (a >= 0 && a <= 0.5) return Math.Sqrt(a/2.0);
            if (a <= 1 && a >= 0.5) return 1-Math.Sqrt((1-a)/2.0);
            else return 0;
        }
    }
    class SugenoOperator : UnaryFSOperator
    {
        public override string Title => "Sugeno's complement";
        public SugenoOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }
        public double S
        {
            get => parameters[0];
            set
            {
                if (value >= -1.0)
                {
                    parameters[0] = value;
                    // fire event
                    FireParameterChangedEvent();
                }
            }
        }
        public override double Evaluate(double a)
        {
            return (1 - a) / (1 + S * a);
        }
    }
    class YagerOperator : UnaryFSOperator
    {
        public override string Title => "Yager's complement";
        public YagerOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }
        public double w
        {
            get => parameters[0];
            set
            {
                if (value >= 0 )
                {
                    parameters[0] = value;
                    // fire event
                    FireParameterChangedEvent();
                }
            }
        }
        public override double Evaluate(double a)
        {
            return Math.Pow(1 - Math.Pow(a, w), 1 / w);
        }
    }
}
