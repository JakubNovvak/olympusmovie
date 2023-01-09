namespace MovieService.ApiModel.Common
{
    public class DateDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateDTO(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
