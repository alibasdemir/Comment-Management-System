namespace Application.Features.AuthWithVerifyCode.Commands.VerifyEmail
{
    public class VerifyEmailResponse
    {
        public bool IsVerified { get; set; }
        public string Message { get; set; }
    }
}
