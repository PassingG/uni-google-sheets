namespace GoogleSheet.Protocol.v2.Req
{
    public class ReadSpreadSheetReqModel : Model
    {
        public string folderID;
        public string fileName;

        public ReadSpreadSheetReqModel(string folderID, string fileName)
        {
            this.instruction = (int)EInstruction.READ_SPREADSHEET;
            this.folderID = folderID;
            this.fileName = fileName;
        }
    }
}