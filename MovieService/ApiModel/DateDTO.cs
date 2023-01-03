namespace MovieService.ApiModel
{
    public class DateDTO
    {
        public int Year;
        public int Month;
        public int Day;

        public DateDTO(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;  
        }
    }
}
