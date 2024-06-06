namespace malak.Helpers
{
    public class APIError
    {
        private string v1;
        private int v2;
        public APIError()
        { }
        public APIError(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        public string ErrorDescription { get; set; }
        public int Code { get; set; }
    }
}
