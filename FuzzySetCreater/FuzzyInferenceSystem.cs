using FuzzySetCreater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class FuzzyInferenceSystem
    {

    }

    [Description("Defuzzification Type ")]
    public enum DefuzzificationType { COA, BOA, MOM, SOM, LOM};
    
    public interface IFuzzyInferencing
    {
        [Description("Cut or not Cut")]
        bool IsCut { get; set; }

        void ConstructSystem(DataGridView dgv);
        double CrispInCrispOutInferencing(double[] conditions, DefuzzificationType defuzzificationType);
       
    }
    class MamdaniFuzzySystem : IFuzzyInferencing
    {
        IfThenFuzzyRule[] rules;
        DefuzzificationType defuzzification = DefuzzificationType.COA;
        public bool IsCut { get; set; } = true;
        public DefuzzificationType Defuzzification { get => defuzzification; set => defuzzification = value; }
        internal IfThenFuzzyRule[] Rules { get => rules; set => rules = value; }
        public void ConstructSystem(DataGridView dgv)
        {
            // create if-then rules
            FuzzySet output;
            rules = new IfThenFuzzyRule[dgv.Rows.Count];
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgv.Columns.Count - 1];
                for (int c = 0; c < dgv.Columns.Count - 1; c++)
                {
                    inputs[c] = (FuzzySet)dgv.Rows[r].Cells[c].Value;
                }
                //find output col
                output = (FuzzySet)dgv.Rows[r].Cells[dgv.Columns.Count - 1].Value;
                rules[r] = new IfThenFuzzyRule(inputs, output);
            }
        }
        public double CrispInCrispOutInferencing(double[] conditions, DefuzzificationType defuzzification)
        {
            FuzzySet resultFS = null;
            double MaxFireValue = double.MinValue;
            foreach (IfThenFuzzyRule ifr in rules)
            {   
                if(resultFS == null)
                    resultFS = ifr.CrispInFuzzyOutInferenceing(conditions, IsCut);
                else//or max 之前的rules
                    resultFS = resultFS | ifr.CrispInFuzzyOutInferenceing(conditions, IsCut);
                if (ifr.FiringStrength > MaxFireValue) MaxFireValue = ifr.FiringStrength;
                
            }

            switch (defuzzification)
            {
                case DefuzzificationType.COA:
                    return resultFS.COACrispValue();
                case DefuzzificationType.BOA:
                    return resultFS.BOACrispValue();
                case DefuzzificationType.SOM:
                    return resultFS.SOMCrispValue(MaxFireValue);
                case DefuzzificationType.MOM:
                    return resultFS.MOMCrispValue(MaxFireValue);
                case DefuzzificationType.LOM:
                    return resultFS.LOMCrispValue(MaxFireValue);
            }
            return 0.0;
        }
    }
    class TsukamotoFuzzySystem: IFuzzyInferencing
    {
        IfThenFuzzyRule[] rules;
        public bool IsWeightedAverage { get; set; } = false;
        internal IfThenFuzzyRule[] Rules { get => rules; set => rules = value; }
        public bool IsCut { get; set; } = true;
        public void ConstructSystem(DataGridView dgv)
        {
            //Create If-Then rules
            rules = new IfThenFuzzyRule[dgv.Rows.Count];
            FuzzySet output;// output
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgv.Columns.Count - 1];
                for (int c = 0; c < dgv.Columns.Count - 1; c++)
                {
                    inputs[c] = (FuzzySet)dgv.Rows[r].Cells[c].Value;
                }
                //find output col
                output = (FuzzySet)dgv.Rows[r].Cells[dgv.Columns.Count - 1].Value;
                if (!output.IsMonotonic)
                {
                    MessageBox.Show("Select a Monotonic Fuzzy set as output.");

                }
                //output.IsMonotonic = true;
                rules[r] = new IfThenFuzzyRule(inputs, output);
            }
        }
        public double CrispInCrispOutInferencing(double[] conditions, DefuzzificationType type)
        {
            //if(IsWeightedAverage) { }
            //foreach (IfThenFuzzyRule ifr in rules)
            //ifr.firingstrength
            double weightedSum = 0.0;
            double wSum = 0.0;
            foreach (IfThenFuzzyRule ifr in rules)
            {
                weightedSum = weightedSum + ifr.TsukaCrispInCrispOutInferencing(conditions);
                wSum = wSum + ifr.FiringStrength;
            }
            if (IsWeightedAverage)
            {
                return weightedSum / wSum;
            }
            else return weightedSum;
        }
    }
    class SugenoFuzzySystem : IFuzzyInferencing
    {
        SugenoIfThenRule[] rules;
        public bool IsWeightedAverage { get; set; } = false;
        public bool IsCut { get; set; } = true;
        public void ConstructSystem(DataGridView dgv)
        {
            //Create If-Then rules
            rules = new SugenoIfThenRule[dgv.Rows.Count];
            int equationId;// output
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgv.Columns.Count - 1];
                for (int c = 0; c < dgv.Columns.Count - 1; c++)
                {
                    inputs[c] = (FuzzySet)dgv.Rows[r].Cells[c].Value;
                }
                //find output col
                equationId = (int)dgv.Rows[r].Cells[dgv.Columns.Count - 1].Value;// # of equation
                rules[r] = new SugenoIfThenRule(inputs, equationId);
            }

        }
        public double CrispInCrispOutInferencing(double[] conditions, DefuzzificationType type = DefuzzificationType.COA)
        {
            double weightedSum = 0.0;
            double wSum = 0.0;
            foreach (SugenoIfThenRule ifr in rules)
            {
                weightedSum = weightedSum + ifr.CrispInCrispOutInferenceing(conditions, IsCut);
                wSum = wSum + ifr.FiringStrength;
            }
            if (IsWeightedAverage)
            {
                return weightedSum / wSum;
            }
            else return weightedSum;
        }
    }
}

