using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NengaJouSimple.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime RegisterdDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;

            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;

            if (other.Id == Id) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
