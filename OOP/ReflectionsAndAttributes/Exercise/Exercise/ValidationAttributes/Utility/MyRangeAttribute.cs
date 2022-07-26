using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utility
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if(obj is int number)
            {
                return number >= this.minValue && number <= this.maxValue;
            }

            return false;
        }
    }
}
