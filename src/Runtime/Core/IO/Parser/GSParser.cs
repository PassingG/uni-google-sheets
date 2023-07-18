using System.Collections.Generic;
using GoogleSheet.IO;
using GoogleSheet.IO.Generator;
using GoogleSheet.Protocol.v2.Res;
using System.Linq;

namespace GoogleSheet
{
    public class GSParser : IParser
    {
        public virtual SheetInfo[] ParseSheet(ReadSpreadSheetResult sheetJsonData)
        {
            ReadSpreadSheetResult getTableResult = sheetJsonData;

            List<SheetInfo> _infos = new();


            return _infos.ToArray();
        }
    }
}