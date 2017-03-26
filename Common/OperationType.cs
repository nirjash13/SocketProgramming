namespace Common
{
    public enum OperationType
    {
        ClientConnect = 0,
        
        ClientAnswer = 2,
        ClientBackupAnswer = 3,
        
    }


    public enum ServerOperationType
    {
        ConnectionSuccessful = 0,
        ServerExamInfo = 1,
        ServerQuestionFileSent=2,
        StudentNotVerified=3
    }
}