using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class BinaryOperatedFuzzySet: FuzzySet
    {
        static int count = 0;
        private FuzzySet theleftFS;
        private FuzzySet therightFS;
        private BinaryFSOperator theOperator;

        public BinaryOperatedFuzzySet(FuzzySet leftFS, FuzzySet rightFS, BinaryFSOperator op) : base(leftFS.TheUniverse )
        {
            theleftFS = leftFS;
            therightFS = rightFS;
            theOperator = op;
            SetBrowsableValue("Core", false);
            title = leftFS.Title + theOperator.Title + rightFS.Title + $"{++count}";
            // subscribe events
            theleftFS.ParameterChanged += TheFS_ParameterChanged;
            therightFS.ParameterChanged += TheFS_ParameterChanged;
        }
        private void TheFS_ParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries) UpdateSeriesDataPoints();

            //Fire event
            FireParameterChangedEvent();
        }
        public override double GetMembershipDegree(double x)
        {
            double a = theleftFS.GetMembershipDegree(x);
            double b = therightFS.GetMembershipDegree(x);
            return theOperator.Evaluate(a, b);
        }
    }
}
