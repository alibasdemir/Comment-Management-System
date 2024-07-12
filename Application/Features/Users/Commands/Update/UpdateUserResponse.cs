namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
