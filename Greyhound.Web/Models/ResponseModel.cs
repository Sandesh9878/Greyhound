namespace Greyhound.Web.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {

        }
        public ResponseModel(bool isSuccess, string message)
        {
            this.isSuccess = isSuccess;
            this.Message = message; 
        }
        public bool isSuccess { get; set; }
        public string Message { get; set; }
    }
}
