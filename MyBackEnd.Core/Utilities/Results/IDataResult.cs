using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Utilities.Results
{
    public interface IDataResult<out TEntity>:IResult
    {
        TEntity Data { get; }
    }
}
