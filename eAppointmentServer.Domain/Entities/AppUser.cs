using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.Domain.Entities
{
    public sealed class AppUser:IdentityUser<Guid>
    {


        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public string FullName=>string.Join(" ", Firstname, Lastname);


    }
}
