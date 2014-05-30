using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Core
{
    public sealed class FrameworkLogicInjector<T>:RealProxy,IFrameworkObject 
    {
        private readonly T _obj;
        private readonly IInterceptor _interceptor;

        public FrameworkLogicInjector(T obj,IInterceptor interceptor):base(typeof(T))
        {
            _obj = obj;
            _interceptor = interceptor;
        }

        public override IMessage Invoke(IMessage msg)
        {           
            var methodCall = msg as IMethodCallMessage;
           
            var methodInfo = methodCall.MethodBase as MethodInfo;
            
            Func<object> action =()=> methodInfo.Invoke(_obj, methodCall.InArgs);

            var command = new MethodInvocation(_obj, methodInfo, action);

            _interceptor.Intercept(command);
                        
            return new ReturnMessage(command.Result, null, 0, methodCall.LogicalCallContext, methodCall);
        }
    }
}
