using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzySetCreater
{
    class IfThenFuzzyRule
    {
        FuzzySet[] fsIn;
        FuzzySet fsOut;
        //for weighted average requirement
        public double FiringStrength { get; set; } = 0.0;
        public IfThenFuzzyRule( FuzzySet[] inputs, FuzzySet output)
        {
            fsIn = inputs;
            fsOut = output;
        }
        //Mandani use
        public FuzzySet FuzzyInFuzzyOutInferenceing( FuzzySet[] conditions, bool isCut = true)
        {
            FiringStrength = double.MaxValue;
            
            //loop through each antecedent fuzzy set
            for (int i = 0; i< fsIn.Length; i++)
            {
                double maxDegree;

                //and min intersection
                //conditions[1].TheUniverse
                if ( fsIn[i].TheUniverse != conditions[i].TheUniverse)
                {
                    MessageBox.Show("theUniverse differ");
                    return null;
                }
                FuzzySet newFs;
                newFs = fsIn[i] & conditions[i];
                newFs.ShowSeries = true;
                maxDegree = newFs.MaxDegree;
                //find min of all universe intersection max
                if (maxDegree < FiringStrength) FiringStrength = maxDegree;
            }
            if (isCut)
                return (FiringStrength - fsOut);//cut
            else
                return (FiringStrength * fsOut);//scale
        }
        //Mandani 3D use 
        internal FuzzySet CrispInFuzzyOutInferenceing(double[] conditions, bool isCut = true)
        {
            FiringStrength = double.MaxValue;
            
            //loop through each antecedent fuzzy set
            for (int i = 0; i < fsIn.Length; i++)
            {
                double maxDegree;

                //and min intersection
                maxDegree = fsIn[i].GetMembershipDegree(conditions[i]);
                //find min of all universe intersection max
                if (maxDegree < FiringStrength) FiringStrength = maxDegree;
            }
            //(FiringStrength - fsOut).ShowSeries = true;
            if (isCut)
                return (FiringStrength - fsOut);//cut
            else
                return (FiringStrength * fsOut);//scale
        }
        //Tsuka
        public double TsukaCrispInCrispOutInferencing(double[] conditions)
        {
            
            FiringStrength = double.MaxValue;//weight

            //loop through each antecedent fuzzy set
            for (int i = 0; i < fsIn.Length; i++)
            {
                double maxDegree = fsIn[i].GetMembershipDegree(conditions[i]);

                //find min of all universe intersection max
                //w
                if (maxDegree < FiringStrength) FiringStrength = maxDegree;
            }
            //condition=-2 fire = 1 get= 4
            //z
            double z = fsOut.GetUniverseValueForADegree(FiringStrength);
            return z * FiringStrength;
        }
        //Tsuka
        public double FuzzyInCrispOutInferencing(FuzzySet[] conditions)
        {
            FiringStrength = double.MaxValue;//weight

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
                    FiringStrength = maxDegree;
            }
            //z
            double z = fsOut.GetUniverseValueForADegree(FiringStrength);
            return z * FiringStrength;
        }
    }
}
