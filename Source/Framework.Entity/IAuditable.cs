using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    public interface IAuditable
    {
        Audit Audit { get; set; }
    }
}
