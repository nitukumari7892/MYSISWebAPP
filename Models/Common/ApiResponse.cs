namespace MySISWeb.Models.Common
{
    public class ApiResponse<T>
    {
        public string status { get; set; }
        public string error { get; set; }
        public List<T> data { get; set; }

        public bool IsSuccess => status == "true";
    }
}