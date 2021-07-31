using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengaJouSimple.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> func)
        {
            if (dictionary.TryGetValue(key, out var resultingValue))
                return resultingValue;

            var value = func();

            if (value != null)
                dictionary.Add(key, value);

            return value;
        }
    }
}
