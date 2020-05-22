using Castle.DynamicProxy;
using MyBackEnd.Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using MyBackEnd.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyBackEnd.Core.Aspects.AutoFac.Performance
{
    public class PerformanceAspect:MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;

        public PerformanceAspect(int interval)
        {
            _stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            _interval = interval;
        }

        protected override void OnBefore(IInvocation ınvocation)
        {
            _stopWatch.Start();
        }

        protected override void OnAfter(IInvocation ınvocation)
        {
            if (_stopWatch.Elapsed.TotalSeconds>_interval)
            {
                Debug.WriteLine($"Performance: {ınvocation.Method.DeclaringType.FullName}.{ınvocation.Method.Name} --> {_stopWatch.Elapsed.TotalSeconds}");
            }
            _stopWatch.Reset();
        }
    }
}
