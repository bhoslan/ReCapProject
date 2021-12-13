using Castle.DynamicProxy; //Autofac in dynamicproxy si ile interceptor özelliğine sahip oluyoruz.
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)//invocation metot
        {

        }
    }
}
