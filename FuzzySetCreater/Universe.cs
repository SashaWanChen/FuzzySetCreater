using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FuzzySetCreater
{
    //The class is to define the common value ranges and resolution for displaying the member functions of fuzzy sets.
    class Universe
    {
        static int count = 0;

        //// data member
        Chart theChart;
        ChartArea theArea;
        Legend theLegend;
        //string title;
        //double mininum = 0;
        //double maximum = 10;
        int resolution = 100;

        //public void SetTitle(string s)
        //{
        //    //Check validity
        //    title = s;
        //}
        //public string GetTitle()
        //{
        //    return title;
        //}

        //// event
        public event EventHandler ParameterChanged;

        //// property: title, mininum, maximum, resolution
        [Category("Property")]
        [Description("The title of the universe.")]
        public string Title
        {
            set
            {
                // check validaity of value
                theArea.AxisX.Title = value;
            }
            get
            {
                return theArea.AxisX.Title;
            }
        }

        [Category("Property")]
        [Description("The minimum of x axis.")]
        public double Minimum
        {
            get => theArea.AxisX.Minimum;
            set 
            {
                if (value < theArea.AxisX.Maximum) {

                    theArea.AxisX.Minimum = value;
                    //fire parameter changed event
                    if (ParameterChanged != null)
                        ParameterChanged(this, null);
                }
                else
                {
                    MessageBox.Show("Maximum must greater than minimum.");
                }
            } 
        }

        internal void RemoveASeriesOfAFuzzySet(Series theSeries)
        {
            theChart.Series.Remove(theSeries);
        }
        public override string ToString() 
        {
            return Title;
        }

        [Category("Property")]
        [Description("The maximum of x axis.")]
        public double Maximum 
        { 
            get => theArea.AxisX.Maximum;
            set
            {
                if (value >= theArea.AxisX.Minimum) theArea.AxisX.Maximum = value;
                else
                {
                    MessageBox.Show("Maximum must greater than minimum.");
                }
            }
        }
        [Category("Property")]
        [Description("Resolution must greater than 50")]
        public int Resolution 
        { 
            get => resolution;
            set
            {
                if (value >= 50) resolution = value;
                else
                {
                    MessageBox.Show("Resolution must greater than 50");
                }
            }
        }
        public void AddASeriesOfAFuzzySet(Series aSeries)
        {
            // register the series to the chartArea
            aSeries.ChartArea = theArea.Name;

            //add the series to Chart.Series
            theChart.Series.Add(aSeries);
        }

        // constructor
        public Universe( Chart theChart )
        {
            string s =  $"Universe{++count}";
            theArea = new ChartArea(s);
            theArea.AxisX.Title = s;
            theArea.AxisY.Title = "Membership Degree";
            theArea.AxisX.Enabled = AxisEnabled.True;
            theArea.AxisY.Enabled = AxisEnabled.True;
            theArea.AxisX.Minimum = 0;
            theArea.AxisX.Maximum = 10;
            theArea.AxisX.MajorGrid.LineWidth = 0;
            theArea.AxisX.LineWidth = 2;
            theArea.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            theArea.AxisY.LineWidth = 2;
            theLegend = new Legend();

            this.theChart = theChart;
            this.theChart.ChartAreas.Add(theArea);
            this.theChart.Legends.Add(theLegend);
        }

        public void SaveFile(StreamWriter sw)
        {
            sw.WriteLine($"Title:{Title}");
            sw.WriteLine($"Minimum:{Minimum}");
            sw.WriteLine($"Maximum:{Maximum}");
            sw.WriteLine($"Resolution:{Resolution}");
        }

        public void ReadFile(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            Title = items[1];
            items = sr.ReadLine().Split(':');
            Minimum = Convert.ToDouble(items[1]);

            items = sr.ReadLine().Split(':');
            Maximum = Convert.ToDouble(items[1]);
            items = sr.ReadLine().Split(':');
            Resolution = Convert.ToInt32(items[1]);
        }
    }
}
