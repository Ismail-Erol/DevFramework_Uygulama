using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cachType;
        private int _cachByMinute;
        private ICacheManager _cacheManager;


        public CacheAspect(Type cachType, int cachByMinute=60)
        {
            _cachType = cachType;
            _cachByMinute = cachByMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            // eğer gönderilen type cachmanager türünde değilse 
            if (typeof(ICacheManager).IsAssignableFrom(_cachType)==false)
            {
                throw new Exception("Wrong Cach Manager");
            }
            _cacheManager = (ICacheManager) Activator.CreateInstance(_cachType);  
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0} {1} {2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);
            var argumants = args.Arguments.ToList();

            var key = string.Format("{0} ({1})", methodName,
                string.Join(",", argumants.Select(x => x != null ? x.ToString() : "<Null>")));

            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }

            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cachByMinute);
        }
    }
}
