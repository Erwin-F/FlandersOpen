using FlandersOpen.Web.Dtos;
using FlandersOpen.Web.Entities;

namespace FlandersOpen.Web.Mapper
{
    public class Mapper
    {
        public static User FromDto(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username
            };
        }

        public static UserDto FromEntity(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Username = entity.LastName
            };
        }
    }
}
