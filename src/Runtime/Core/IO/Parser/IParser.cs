using GoogleSheet.IO;
using GoogleSheet.Protocol.v2.Res;

namespace GoogleSheet
{
    public interface IParser
    {
        SheetInfo[] ParseSheet(ReadSpreadSheetResult sheetJsonData);
    }
}