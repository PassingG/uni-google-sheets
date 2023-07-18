namespace GoogleSheet.Protocol.v2
{
    public enum EInstruction
    {
        SEARCH_GOOGLE_DRIVE = 0,
        READ_SPREADSHEET = 1,
        WRITE_OBJECT = 2,
        WRITE_OBJECTS = 3,
        CREATE_DEFAULT_TABLE = 101,
        COPY_EXAMPLE = 102,
        COPY_FOLDER = 103
    }
}