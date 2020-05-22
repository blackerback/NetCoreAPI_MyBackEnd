using MyBackEnd.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Utilities.Bussiness
{
    public class BussinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return new SuccessResult();
        }
    }
}
