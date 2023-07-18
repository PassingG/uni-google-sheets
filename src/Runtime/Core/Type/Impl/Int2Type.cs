using Unity.Mathematics;
using UnityEngine;

namespace GoogleSheet.Type
{
    [Type(typeof(int2), new string[] { "int2", "Int2" })]
    public class Int2Type : IType
    {
        public object DefaultValue => 0;

        public object Read(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);

            value = value.Replace("(", "");
            value = value.Replace(")", "");
            var values = value.Split(",");

            if (values.Length < 2)
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);

            int2 result = int2.zero;
            int i1 = 0;
            int i2 = 0;
            var b1 = int.TryParse(values[0], out i1);
            var b2 = int.TryParse(values[1], out i2);

            if (b1 == false || b2 == false)
            {
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);
            }

            result = new int2(i1, i2);

            return result;
        }

        public string Write(object value)
        {
            var result = value.ToString();
            result = result.Replace("int2", "");
            return result;
        }
    }
}