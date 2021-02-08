using System;
using System.Collections.Generic;
using System.Text;

namespace HightechAngular.Core.Base
{
    public interface IHasCreatedDateString
    {
        DateTime Created { get; }

        string CreatedString { get; }
    }
}
