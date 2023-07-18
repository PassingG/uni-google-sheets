using System.Collections.Generic;
using System.Text;

namespace GoogleSheet.Type
{
    public static class WriteUtil
    {
        public static string SetValueToBracketArray<T, G>(object value) where T : List<G>
        {
            return SetValueToBracketArray(value as T);
        }

        public static string SetValueToBracketArray<T>(object value)
        {
            return SetValueToBracketArray(value as T[]);
        }

        public static string SetValueToBracketArray<T>(System.Collections.Generic.List<T> value)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.AppendJoin(",", value);
            builder.Append("]");
            return builder.ToString();
        }

        public static string SetValueToBracketArray<T>(T[] value)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.AppendJoin(",", value);
            builder.Append("]");
            return builder.ToString();
        }
    }
}