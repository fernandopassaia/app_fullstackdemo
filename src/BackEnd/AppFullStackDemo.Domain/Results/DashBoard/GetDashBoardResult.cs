using System.Collections.Generic;

namespace AppFullStackDemo.Domain.Results.DashBoard
{
    public class GetDashBoardResult
    {
        public List<GetDashBoardInfo> ListOfAndroid { get; set; }
        public List<GetDashBoardInfo> ListOfManufacturers { get; set; }

        public GetDashBoardResult(List<GetDashBoardInfo> listOfAndroids, List<GetDashBoardInfo> listOfManufacturers)
        {
            ListOfAndroid = listOfAndroids;
            ListOfManufacturers = listOfManufacturers;
        }
    }
}