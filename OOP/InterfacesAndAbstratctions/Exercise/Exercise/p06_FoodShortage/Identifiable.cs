using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Identifiable : IIdentifiable
    {
        public Identifiable(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public bool IsIdFake(string checkNumber)
        {
            if (Id.EndsWith(checkNumber))
            {
                return true;
            }

            return false;
        }
    }
}
