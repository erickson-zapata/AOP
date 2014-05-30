using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOP.Core;
using AOP.Business.Core;

namespace AOP.Business.Interceptor
{
    public class PropertyChangeInterceptor:IInterceptor
    {
        public void Intercept(IMethodInvocation invocation)
        {
            if(invocation.MethodInfo.Name.Contains("set_"))
            {
                var contextType =invocation.Context.GetType();
                
                MethodInfo propertyChanging = contextType.GetMethod("OnPropertyChanging", BindingFlags.NonPublic | BindingFlags.Instance);

                MethodInfo propertyChanged = contextType.GetMethod("OnPropertyChanged", BindingFlags.NonPublic | BindingFlags.Instance);
                
                if(propertyChanging!=null) propertyChanging.Invoke(invocation.Context, new object[] { invocation.MethodInfo.Name.Remove(0, 4) });

                invocation.Result=invocation.Invoke();

                if (propertyChanged != null)  propertyChanged.Invoke(invocation.Context, new object[] { invocation.MethodInfo.Name.Remove(0, 4) });
                               
            }
            else
            {
                invocation.Result=invocation.Invoke();
            }
            
            
        }
    }
}
