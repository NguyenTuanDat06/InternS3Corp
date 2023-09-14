using Service.Models.Requests;

namespace Service.Models.DTOs
{
    public class DtoUser
    {
        private string name;
        private string email;
        private string address;

        public DtoUser(CreateUserRequest user) 
        {
            name = user.Name;
            email = user.Email;
            address = user.Address;
        }
    }
}
