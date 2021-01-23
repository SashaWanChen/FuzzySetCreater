using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace FuzzySetCreater
{
    class FuzzySet
    {
        // operator overloaded
        //! not (FuzzySet)
        //* scale (double, FuzzySet) 
        //- cut (double, FuzzySet) 
        //- cut (FuzzySet)
        //& and min intersection(FuzzySet, FuzzySet)
        //| or max union(FuzzySet, FuzzySet)

        // "/"
        public static FuzzySet operator !(FuzzySet fs)
        {
            UnaryFSOperator op = new NegateOperator();
            return new UnaryOperatedFuzzySet(fs, op);
        }
        public static FuzzySet operator *(double scaleValue, FuzzySet fs)
        {
            ScaleOperator op = new ScaleOperator();
            op.ScaleValue = scaleValue;
            return new UnaryOperatedFuzzySet(fs, op);
        }
         public static FuzzySet operator -(double cutValue, FuzzySet fs)
        {
            ValueCutOperator op = new ValueCutOperator();
            op.CutValue = cutValue;
            return new UnaryOperatedFuzzySet(fs, op);
        }
        //cut: unary operation for C#
        public static FuzzySet operator -(FuzzySet fs)
        {
            UnaryFSOperator op = new ValueCutOperator();
            return new UnaryOperatedFuzzySet(fs, op);
        }
        // or max union
        public static FuzzySet operator |(FuzzySet leftFS, FuzzySet rightFS)
        {
            BinaryFSOperator op = new Union();
            return new BinaryOperatedFuzzySet(leftFS, rightFS, op);
        }
        //and min intersection
        public static FuzzySet operator &(FuzzySet leftFS, FuzzySet rightFS)
        {
            BinaryFSOperator op = new Intersection();
            return new BinaryOperatedFuzzySet(leftFS, rightFS, op);
        }
        public virtual double COACrispValue()
        {
            double Area = 0;
            double total = 0;
            //traverse each DataPoint of the series
            double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
            {
                total = total + this.GetMembershipDegree(x) * x * deltaX;
                Area = Area + this.GetMembershipDegree(x) * deltaX;
                
            }
            return total / Area;
        }
        public virtual double BOACrispValue()
        {
          
                double Area = 0;
                // traverse each DataPoint of the series
                double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
                for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
                {
                    Area = Area + this.GetMembershipDegree(x) * deltaX;
                }
                double newArea = 0;
                for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
                {
                    newArea = newArea + this.GetMembershipDegree(x) * deltaX;
                    if (newArea >= (Area / 2.0)) return x;
                }
                return 0.0;
           
        }
        public virtual double SOMCrispValue(double MaxFireValue)
        {
            // traverse each DataPoint of the series
            double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
            {
                if (this.GetMembershipDegree(x)>= MaxFireValue) 
                    return 1-x;
            }
            return 0.0;
            
        }
        public virtual double MOMCrispValue(double MaxFireValue)
        {
       
            // traverse each DataPoint of the series
            double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
            double SOM = 0,LOM = 0;
            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
            {
                if (this.GetMembershipDegree(x) >= MaxFireValue) SOM = x;
            }
            for (double x = theUniverse.Maximum; x >= theUniverse.Minimum; x = x - deltaX)
            {
                if (this.GetMembershipDegree(x) >= MaxFireValue) LOM = x;
            }
            return (SOM + LOM) / 2.0; 

        }
        public virtual double LOMCrispValue(double MaxFireValue)
        {
           
           // traverse each DataPoint of the series
           double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
           for (double x = theUniverse.Maximum; x >= theUniverse.Minimum; x = x - deltaX)
           {
                if (this.GetMembershipDegree(x) >= MaxFireValue) return x;
           }       
           return 0.0;
        }

        #region DataMembers
        protected double[] parameters;
        protected string title;
        protected Random randomizer = new Random();

        protected Universe theUniverse;
        protected System.Windows.Forms.DataVisualization.Charting.Series theSeries;
        public event EventHandler ParameterChanged;
        protected void FireParameterChangedEvent()
        {
            if (ParameterChanged != null) ParameterChanged(this, null);
        }
        #endregion

        public virtual double MaxDegree
        {
            get
            {
                double maxDegree = 0.0;

                if (theSeries == null)
                {
                    // theUniverse the range of universe to get the degree
                    double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
                    for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
                    {
                        double y;
                        y = GetMembershipDegree(x);
                        if (y > maxDegree) maxDegree = y;
                    }
                }
                else
                {
                    // traverse each DataPoint of the series
                    for (int i = 0; i < theSeries.Points.Count; i++)
                    {
                        if (theSeries.Points[i].YValues[0] > maxDegree) maxDegree = theSeries.Points[i].YValues[0];
                    }
                }
                return maxDegree;
            }
        }
        [Description("The universe."), Browsable(false)]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public  Universe TheUniverse { get => theUniverse; }
        public override string ToString()
        {
            return title;
        }
        [Category("Property")]
        [Description("The fuzzy set."), DisplayName("Fuzzy set")]
        public string Title 
        {
            get {
                return title;
            }
            set {
                title = value;
                theSeries.LegendText = value;
            }
        }
        public virtual bool IsMonotonic
        {
            set; get;
        } = false;
        //Tsuka
        public virtual double GetUniverseValueForADegree(double degree)
        {
            double resultX;
            double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
            {
                double difference = Math.Abs(degree - this.GetMembershipDegree(x));
                if (difference <0.05 && (this.GetMembershipDegree(x) != this.GetMembershipDegree(x + deltaX)))
                {
                    resultX = x;
                    return resultX;
                }         
            }
            // no intersection
            return double.NaN;
        }
        [Description("Draw series.")]
        public bool ShowSeries
        {
            set
            {
                if( value)
                {
                    if( theSeries == null )
                    {
                        theSeries = new System.Windows.Forms.DataVisualization.Charting.Series(Title);
                        if(ShowSeriesArea)
                            theSeries.ChartType = SeriesChartType.Area;
                        else
                            theSeries.ChartType = SeriesChartType.Line;

                        theSeries.IsVisibleInLegend = true;
                       
                        UpdateSeriesDataPoints();
                        // Add this series to chart via universe
                        theUniverse.AddASeriesOfAFuzzySet(theSeries);
                    }
                }
                else
                {
                    if(theSeries != null)
                    {
                        if (theSeries.ChartType == SeriesChartType.Line)
                            theSeries.Points.Clear();
                        else
                        {
                            theSeries.ChartType = SeriesChartType.Line;
                            theSeries.Points.Clear();
                        }

                    }
                        
                    theUniverse.RemoveASeriesOfAFuzzySet(theSeries);
                    if (theSeries != null) theSeries = null;
                }
            }
            get
            {
                return theSeries == null ? false : true;
            }
        }
        public bool ShowSeriesArea
        {
            set; get;
        } = false;    
        protected void UpdateSeriesDataPoints()
        {
            if (theSeries == null) return;

            theSeries.Points.Clear();
            double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x = x + deltaX)
            {
                double y;
                y = GetMembershipDegree(x);
                theSeries.Points.AddXY(x, y);

                // Create the ToolTip and associate with the Form container.
                ToolTip toolTip1 = new ToolTip();
                // Set up the delays for the ToolTip.
                toolTip1.InitialDelay = 0;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;
                theSeries.ToolTip = $"{Title}";
                // set core
                //theSeries.YValuesPerPoint
            }
        }
        public virtual double GetMembershipDegree(double x)
        {
            throw new NotImplementedException();
        }
        
        [Description("The core"), Browsable(false)]
        public virtual string Core { get => ""; }
        public void SetBrowsableValue(string attribute, object value)
        {
            var descriptor = TypeDescriptor.GetProperties(GetType())[attribute];
            var attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
            var isBrowsable = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
            isBrowsable.SetValue(attrib, value);
        }
        public FuzzySet( Universe u)
        {
            theUniverse = u;
            // subscribe ParameterChanged Event
            u.ParameterChanged += Universe_ParameterChanged;
        }
        private void Universe_ParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries)
            {
                UpdateSeriesDataPoints();
            }
        }
        public void SelectSeries()
        {
            theSeries.ChartType = SeriesChartType.Spline;

            //設定線圖粗度及樣式
            theSeries.BorderWidth = 3;
        }
        public void UnSelectSeries()
        {
            theSeries.ChartType = SeriesChartType.Line;

            //設定線圖粗度及樣式
            theSeries.BorderWidth = 1;
        }
        public virtual void SaveFile(StreamWriter sw)
        {
            sw.WriteLine($"FuzzySetType:{this.GetType().Name}");
            sw.WriteLine($"OriginHashCode:{this.GetHashCode()}");
            sw.WriteLine($"Title:{Title}");
            sw.WriteLine($"NumberOfParameters:{parameters.Length}");
            int c = 0;
            foreach (double p in parameters)
                sw.WriteLine($"Par{c}:{parameters[c++]}");
        }
        public virtual void ReadFile(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            title = items[1];
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            for(int i = 0; i< num; i++)
            {
                items = sr.ReadLine().Split(':');
                parameters[i] = Convert.ToDouble(items[1]);
            }
        }
    }
}
