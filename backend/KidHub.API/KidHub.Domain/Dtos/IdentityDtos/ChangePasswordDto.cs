using System.ComponentModel.DataAnnotations;

namespace KidHub.Domain.Dtos.IdentityDtos
{
    public class ChangePasswordDto 
    {
        public ChangePasswordDto(Guid id, string password, string newPassword)
        {
            Id = id;
            Password = password;
            NewPassword = newPassword;
        }

        public Guid Id { get;}

        [Required, StringLength(256)]
        public string Password { get; }

        [Required, StringLength(256)]
        public string NewPassword { get; }
    }
}