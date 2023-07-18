using System;

namespace GoogleSheet.Type
{
    [Type(Type: typeof(bool), TypeName: new string[] { "bool", "Bool", "Boolean" })]
    public class BoolType : IType
    {
        public object DefaultValue => 0;

        public object Read(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);

            bool @bool = false;
            var b = bool.TryParse(value, out @bool);
            if (b == false)
            {
                throw new UGSValueParseException("Parse Faield => " + value + " To " + this.GetType().Name);
                //return DefaultValue;
            }

            return @bool;
        }

        public string Write(object value)
        {
            return value.ToString();
        }
    }
}