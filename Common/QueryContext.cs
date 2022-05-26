
namespace WebApi.Common
{
    public class QueryContext
    {
        public static AsyncLocal<Dictionary<string, object>> ContextLocal = new AsyncLocal<Dictionary<string, object>>();

        public static Object? Get(string key)
        {
            return ContextLocal.Value == null ? null : ContextLocal.Value[key];
        }

        public static void Put(string key, object value)
        {
            if (ContextLocal.Value == null)
            {
                ContextLocal.Value = new Dictionary<string, object>();
            }
            ContextLocal.Value.Add(key, value);
        }

        public static void clear()
        {
            if (ContextLocal.Value != null)
            {
                ContextLocal.Value.Clear();
            }
        }
    }
}
