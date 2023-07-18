namespace GoogleSheet.Type
{
    [Type(typeof(string[]), new string[] { "string[]", "String[]" })]
    public class StringArrayType : IType
    {
        public object DefaultValue => null;

        public object Read(string value)
        {
            var datas = ReadUtil.GetBracketValueToArray(value);
            return datas;
        }

        public string Write(object value)
        {
            return WriteUtil.SetValueToBracketArray<string>(value);
        }
    }
}