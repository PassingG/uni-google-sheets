using System;

namespace GoogleSheet.Protocol.v2.Req
{
    public class WriteObjectReqModel : Model
    {
        public string folderID;
        public string fileName;
        public string sheetName;
        public string key;
        [Newtonsoft.Json.JsonProperty("type")] public string[] types;

        [Newtonsoft.Json.JsonProperty("head")] public string[] headers;

        [Newtonsoft.Json.JsonProperty("value")]
        public string[] values;

        public WriteObjectReqModel(string folderID, string fileName, string sheetName, string key, string[] types, string[] headers, string[] values)
        {
            this.instruction = (int)EInstruction.WRITE_OBJECT;
            this.folderID = folderID;
            this.fileName = fileName;
            this.sheetName = sheetName;
            this.key = key;
            this.types = types;
            this.headers = headers;
            this.values = values;
        }
    }

    public class WriteObjectsReqModel : Model
    {
        public string folderID;
        public string fileName;
        public string sheetName;
        public string key;
        [Newtonsoft.Json.JsonProperty("type")] public string[] types;
        [Newtonsoft.Json.JsonProperty("head")] public string[] headers;

        [Newtonsoft.Json.JsonProperty("values")]
        public MultiDimension[] values;

        public WriteObjectsReqModel(string folderID, string fileName, string sheetName, string key, string[] types, string[] headers, MultiDimension[] values)
        {
            this.instruction = (int)EInstruction.WRITE_OBJECTS;
            this.folderID = folderID;
            this.fileName = fileName;
            this.sheetName = sheetName;
            this.key = key;
            this.types = types;
            this.headers = headers;
            this.values = values;
        }
    }

    [Serializable]
    public class MultiDimension
    {
        [Newtonsoft.Json.JsonProperty("value")]
        public string[] value;

        public MultiDimension(string[] value)
        {
            this.value = value;
        }
    }
}