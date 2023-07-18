#if UNITY_2017_1_OR_NEWER || UNITY_BUILD
using System.Collections.Generic;
using GoogleSheet;
using GoogleSheet.IO;
using GoogleSheet.IO.Generator;
using GoogleSheet.Protocol.v2.Res;
using System.Linq;

namespace UGS.IO
{
    /*
        백업 플
     */
    public class UnityGSParser : IParser
    {
        public SheetInfo[] ParseSheet(ReadSpreadSheetResult sheetJsonData)
        {
            ReadSpreadSheetResult getTableResult = sheetJsonData;

            List<SheetInfo> results = new();

            return results.ToArray();
        }
    }
}


#endif