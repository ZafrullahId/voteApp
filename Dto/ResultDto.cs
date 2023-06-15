namespace VoteApp.Dto
{
    public class ResultDto
    {
        public string Id { get; set; }
        public string ResultName { get; set; }
        public decimal Score { get; set; }
    }

    public class CreateResultRequestModel
    {
        public string ResultName { get; set; }
    }

    public class UpdateResultRequestModel
    {
        public string ResultName { get; set;}
    }
}
