namespace VoteApp.Dto.ResponseModel
{
    public class BaseResponse <T>
    {
        public T Data { get; set;}
        public bool Status{ get; set;}
        public string Message{get; set;}
    }
}
