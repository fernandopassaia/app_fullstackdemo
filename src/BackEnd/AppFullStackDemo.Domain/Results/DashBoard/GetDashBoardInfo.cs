namespace AppFullStackDemo.Domain.Results.DashBoard
{
    public class GetDashBoardInfo
    {
        public GetDashBoardInfo(string field, string value)
        {
            Field = field;
            Value = value;
        }

        public string Field { get; set; }
        public string Value { get; set; }
    }
}
