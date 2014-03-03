using System;

namespace Framework.Entity
{
    public class Audit
    {
        public virtual DateTime? InsertDateTime { get; set; }
        public virtual DateTime? UpdateDateTime { get; set; }
    }
}