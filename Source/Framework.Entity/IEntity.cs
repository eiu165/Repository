using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    public interface IEntity
    {
        bool IsTransient { get; }
    }
}
