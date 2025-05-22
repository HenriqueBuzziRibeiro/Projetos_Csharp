using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AbilityScoreCalculator
{
    internal class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public double Score;

        public void CalculateAbilityScore()
        {
            //Divide
            Score = RollResult / DivideBy;
            Convert.ToInt32(Score);
            //Soma
            Score = Score + AddAmount;

            if (Score < Minimum) 
                Score = Minimum;
            else 
                Score = Score;
        }
    }
}
