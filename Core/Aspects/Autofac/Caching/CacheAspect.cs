using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Caching;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            /*invocation.Method.ReflectedType.FullName komutu ile metodun namespace ini alıyoruz.
             invocation.Method.Name ile de metodun adını alıp aralarında nokta olacak şekilde birleştiriyoruz.*/
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            var arguments = invocation.Arguments.ToList();    //Varsa metodun parametrelerini listeye çeviriyoruz.

            /*methodName e parametreleri parantez içinde olacak şekilde ekliyoruz.
             Ve böylelikle key değerimizi oluşturuyoruz.*/
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            /*cache i kontrol ediyoruz bu key değerinde bir cache var mı? Varsa cache den metodun değerlerini alıp
             metodun ReturnValue değerine aktarıyoruz. Yoksa metodun kendisini çalıştırıp
            cache e ekliyoruz.*/
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
