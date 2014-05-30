using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Core
{
    public interface IInterceptor
    {
        void Intercept(IMethodInvocation invocation);
    }
}

