using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IBirthdatable
    {
        DateTime Birthday { get; }

        bool IsBornInYear(int year);
    }
}
