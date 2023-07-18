using Unity.Mathematics;
using UnityEngine;

namespace GoogleSheet.Type
{
    [Type(typeof(float2), new string[] { "float2", "Float2" })]
    public class Float2Type : IType
    {
        public object DefaultValue => 0.0f;

        public object Read(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);

            value = value.Replace("(", "");
            value = value.Replace(")", "");
            var values = value.Split(",");

            if (values.Length < 2)
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);

            float2 result = float2.zero;
            float f1 = 0f;
            float f2 = 0f;
            var b1 = float.TryParse(values[0], out f1);
            var b2 = float.TryParse(values[1], out f2);

            if (b1 == false || b2 == false)
            {
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);
            }

            result = new float2(f1, f2);

            return result;
        }

        public string Write(object value)
        {
            var result = value.ToString();
            result = result.Replace("float2", "");
            return result;
        }
    }
}