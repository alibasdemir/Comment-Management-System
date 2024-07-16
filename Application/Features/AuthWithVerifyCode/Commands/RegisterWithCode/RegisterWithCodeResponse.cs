namespace Application.Features.AuthWithVerifyCode.Commands.RegisterWithCode
{
    public class RegisterWithCodeResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
