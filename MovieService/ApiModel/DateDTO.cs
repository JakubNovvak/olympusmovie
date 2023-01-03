namespace MovieService.ApiModel
{
    public class DateDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateDTO(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;  
        }
    }
}
