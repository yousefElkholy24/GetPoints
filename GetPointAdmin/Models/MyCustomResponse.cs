namespace GetPointAdmin.Models.Dto
{
    internal class MyCustomResponse
    {
        public MyCustomResponse()
        {
        }

        public object Data { get; set; }
        public string Message { get; set; }
        public float TotalPrice { get; set; }
    }
}