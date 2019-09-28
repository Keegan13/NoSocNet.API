using NoSocNet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NoSocNet.API.Extensions
{
    public static class ObjectExtensions
    {

        public static object ApplyError(this IHasResultCode obj, params string[] errorMessages)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (obj.GetType().GetProperty("ResultCode") is PropertyInfo codeProp)
            {
                if (codeProp.PropertyType == typeof(int))
                {
                    codeProp.SetValue(obj, (int)ResultCode.Error);
                }
                if (codeProp.PropertyType == typeof(ResultCode))
                {
                    codeProp.SetValue(obj, ResultCode.Error);
                }
            }

            if (errorMessages == null || errorMessages.Length == 0)
            {
                return obj;
            }

            if (obj.GetType().GetProperty("Messages") is PropertyInfo prop)
            {
                if (prop.PropertyType == typeof(List<string>))
                {
                    var list = prop.GetValue(obj) as List<string>;
                    if (list != null)
                    {
                        list.AddRange(errorMessages);
                    }
                }
            }

            return obj;
        }
        public static object ApplyError(this IHasResultCode obj, params Exception[] exeptions)
        {
            return obj.ApplyError(exeptions?.Select(x => x.Message).ToArray());
        }

        public static T ErrorizeObject<T>(params Exception[] exceptions) where T : IHasResultCode
        {
            var instance = Activator.CreateInstance<T>();
            instance.ApplyError(exceptions);
            return instance;
        }
    }
}
