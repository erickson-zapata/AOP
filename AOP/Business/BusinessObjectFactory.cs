using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOP.Core;
using AOP.Business.Core;
using AOP.Business.Objects;
using AOP.Business.Interceptor;

namespace AOP.Business
{
    public static class BusinessObjectFactory
    {
        public static T Create<T>() where T:class,IBusinessObject
        {
            var bo = Activator.CreateInstance<T>();
            var proxy = new FrameworkLogicInjector<T>(bo, new PropertyChangeInterceptor());
            return proxy.GetTransparentProxy() as T;
        }
    }
}
