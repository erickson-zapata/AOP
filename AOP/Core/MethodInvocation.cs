using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Core
{
    public sealed class MethodInvocation:FrameworkObject,IMethodInvocation
    {
        private Func<object> _method;

        public object Context { get; set; }
       
        public MethodInfo MethodInfo {get; private set;}

        public object Result { get; set; }

        public object Invoke()
        {
            return _method.Invoke();
        }
        
        public MethodInvocation(object context,MethodInfo mi,Func<object> method)
        {
            Context = context;
            MethodInfo = mi;
            _method = method;
        }
    }
}
