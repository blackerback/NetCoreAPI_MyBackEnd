using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Utilities.Results
{
    public class DataResult<TEntity> : Result, IDataResult<TEntity>
    {
        public TEntity Data { get; }

        public DataResult(TEntity Data,bool success,string message):base(success,message)
        {
            this.Data = Data;
        }
        public DataResult(TEntity Data, bool success):base(success)
        {
            this.Data = Data;
        }
        
    }
}
