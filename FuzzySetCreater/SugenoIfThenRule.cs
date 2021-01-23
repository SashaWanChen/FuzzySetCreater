using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySetCreater
{
    class SugenoIfThenRule
    {
        FuzzySet[] fsIn;
        int fsOut;
        public double FiringStrength { get; set; } = 0.0;
        public SugenoIfThenRule(FuzzySet[] inputs, int output)
        {
            fsIn = inputs;
            fsOut = output;
        }
        public double FuzzyInCrispOutInferenceing(FuzzySet[] conditions, bool isCut = true)// isCut
        {
            FiringStrength = double.MaxValue;//weight
            double[] inputSet = new double[fsIn.Length];
            //loop through each antecedent fuzzy set
            for (int i = 0; i < fsIn.Length; i++)
            {
                double maxDegree;
                FuzzySet newFs;
                newFs = fsIn[i] & conditions[i];
                //newFs.ShowSeries = true;
                maxDegree = newFs.MaxDegree;
                //find min of all universe intersection max 
                if (maxDegree < FiringStrength)
                {
                    FiringStrength = maxDegree;
                }
                inputSet[i] = newFs.GetUniverseValueForADegree(maxDegree);
            }
            //z
            double z = GetOutputValue(inputSet, fsOut);
            return z * FiringStrength;
        }
        public double CrispInCrispOutInferenceing(double[] conditions, bool isCut = true)//isCut
        {
            FiringStrength = double.MaxValue;//weight
            
            //loop through each antecedent fuzzy set
            for (int i = 0; i < fsIn.Length; i++)
            {
                double maxDegree= fsIn[i].GetMembershipDegree(conditions[i]);
                
                //find min of all universe intersection max
                //w
                if (maxDegree < FiringStrength) FiringStrength = maxDegree;
            }
            //z
            double z = GetOutputValue(conditions, fsOut);
            return z * FiringStrength;

        }

        public double GetOutputValue(double[] inputs, int equationID)
        {
            switch (equationID)
            {
                case 0: // Y=0.1X+6.4
                    return 0.1 * inputs[0] + 6.4;
                case 1: // Y=0.5X+4
                    return 0.5 * inputs[0] + 4;
                case 2:// Y = X - 2
                    return inputs[0] - 2;
                case 3:// Z = -X + Y + 1
                    return -inputs[0] + inputs[1] + 1;
                case 4:// Z = -Y + 3
                    return -inputs[1] + 3;
                case 5:// Z = -X + 3
                    return -inputs[0] + 3;
                case 6:// Z = X + Y + 2
                    return inputs[0] + inputs[1] + 2;
            }
            return 0;          
        }
    }
}
