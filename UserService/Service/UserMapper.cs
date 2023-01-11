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
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Photo = user.Photo,
                BackgroundPhoto = user.BackgroundPhoto,
                JoinDate = user.JoinDate,
            };
        }

        public static User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Email = userDTO.Email,
                Photo= userDTO.Photo,
                BackgroundPhoto= userDTO.BackgroundPhoto,
                JoinDate = userDTO.JoinDate!.Value,
            };
        }
    }
}
