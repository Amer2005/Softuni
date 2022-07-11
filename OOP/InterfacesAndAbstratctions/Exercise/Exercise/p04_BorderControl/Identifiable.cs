using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Identifiable : IIdentifiable
    {
        public Identifiable(string id)
        {
            this.Id = id;
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
