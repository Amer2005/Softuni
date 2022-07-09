using System;
using System.Collections.Generic;
using System.Text;

namespace p04_PizzaCalories
{
    public class Dough
    {
        private string flourType;

        private string bakingTechnique;

        private decimal grams;

        public Dough(string flourType, string bakingTechnique, decimal grams)
        {
            this.flourType = flourType;
            this.bakingTechnique = bakingTechnique;
            this.grams = grams;


            if (!IsDoughValid())
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (grams < 1 || grams > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }

        public decimal Calories => GetCalories();

        private bool IsDoughValid()
        {
            bool isFlourTypeValid = false;
            bool isbakingTechniqueValid = false;

            if (flourType == "white")
            {
                isFlourTypeValid = true;
            }
            else if (flourType == "wholegrain")
            {
                isFlourTypeValid = true;
            }

            if (bakingTechnique == "crispy")
            {
                isbakingTechniqueValid = true;
            }
            else if (bakingTechnique == "chewy")
            {
                isbakingTechniqueValid = true;
            }
            else if (bakingTechnique == "homemade")
            {
                isbakingTechniqueValid = true;
            }

            return isFlourTypeValid == true && isbakingTechniqueValid == true;
        }

        private decimal GetCalories()
        {
            decimal calories;

            decimal flourTypeMultiplier = 1;
            decimal bakingTechniqueMultiplier = 1;

            if (flourType == "white")
            {
                flourTypeMultiplier = 1.5m;
            }
            else if (flourType == "wholegrain")
            {
                flourTypeMultiplier = 1;
            }

            if(bakingTechnique == "crispy")
            {
                bakingTechniqueMultiplier = 0.9m;
            }
            else if (bakingTechnique == "chewy")
            {
                bakingTechniqueMultiplier = 1.1m;
            }
            else if (bakingTechnique == "homemade")
            {
                bakingTechniqueMultiplier = 1;
            }

            calories = grams * flourTypeMultiplier * bakingTechniqueMultiplier * 2;

            return calories;
        }
    }
}
