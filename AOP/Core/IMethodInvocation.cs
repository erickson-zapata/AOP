using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Core
{
    public interface IMethodInvocation
    {
         object Context { get; }

         MethodInfo MethodInfo { get;}

         object Result { get; set; }

         object Invoke();
       
    }
}
