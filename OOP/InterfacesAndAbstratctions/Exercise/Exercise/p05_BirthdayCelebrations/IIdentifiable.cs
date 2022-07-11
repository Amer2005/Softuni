using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IIdentifiable
    {
        string Id { get; }

        bool IsIdFake(string checkNumber);
    }
}
