using UserService.ApiModel;
using UserService.Model;

namespace UserService.Service
{
    public class UserMapper
    {
        public static UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Email = user.Email,
                Photo = user.Photo,
                //WatchingMovies = new List<int>(user.WatchingMovies),
                //CompletedMovies = new List<int>(user.CompletedMovies),
                //OnHoldMovies = new List<int>(user.OnHoldMovies),
                //DroppedMovies = new List<int>(user.DroppedMovies),
                //PlanToWatchMovies = new List<int>(user.PlanToWatchMovies),
                //WatchingSeries = new List<int>(user.WatchingSeries),
                //CompletedSeries = new List<int>(user.CompletedSeries),
                //OnHoldSeries = new List<int>(user.OnHoldSeries),
                //DroppedSeries = new List<int>(user.DroppedSeries),
                //PlanToWatchSeries = new List<int>(user.PlanToWatchSeries)
            };
        }

        public static User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                NickName = userDTO.NickName,
                Email = userDTO.Email,
                Photo= userDTO.Photo,
                //WatchingMovies = new List<int>(userDTO.WatchingMovies),
                //CompletedMovies = new List<int>(userDTO.CompletedMovies),
                //OnHoldMovies = new List<int>(userDTO.OnHoldMovies),
                //DroppedMovies = new List<int>(userDTO.DroppedMovies),
                //PlanToWatchMovies = new List<int>(userDTO.PlanToWatchMovies),
                //WatchingSeries = new List<int>(userDTO.WatchingSeries),
                //CompletedSeries = new List<int>(userDTO.CompletedSeries),
                //OnHoldSeries = new List<int>(userDTO.OnHoldSeries),
                //DroppedSeries = new List<int>(userDTO.DroppedSeries),
                //PlanToWatchSeries = new List<int>(userDTO.PlanToWatchSeries)
            };
        }
    }
}
