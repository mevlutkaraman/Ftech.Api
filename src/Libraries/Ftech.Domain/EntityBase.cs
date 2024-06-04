using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ftech.Domain
{
    public class EntityBase<TIdType>
    {
        public virtual TIdType Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime? UpdatedOn { get; set; }
        public virtual DateTime? DeletedOn { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TIdType>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (EntityBase<TIdType>)obj;

            return item == this;
        }

        public static bool operator == (EntityBase<TIdType> left, EntityBase<TIdType> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator != (EntityBase<TIdType> left, EntityBase<TIdType> right)
        {
            return !(left == right);
        }
    }
}
