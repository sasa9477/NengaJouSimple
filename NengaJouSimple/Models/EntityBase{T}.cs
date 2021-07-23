using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NengaJouSimple.Models
{
    public abstract class EntityBase<T> : IEquatable<T> where T : EntityBase<T>
    {
        public int Id { get; set; }

        public DateTime RegisterdDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public bool Equals([AllowNull] T other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;

            if (other.Id == Id) return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
