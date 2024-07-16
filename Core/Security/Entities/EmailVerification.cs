using Core.Persistence;

namespace Core.Security.Entities
{
    public class EmailVerification : Entity
    {
        public int UserId { get; set; }
        public string? VerificationCode { get; set; }
        public bool IsVerified { get; set; }

        public virtual User User { get; set; }

        public EmailVerification()
        {
        }

        public EmailVerification(int id, int userId, string? verificationCode, bool isVerified)
            : this()
        {
            Id = id;
            UserId = userId;
            VerificationCode = verificationCode;
            IsVerified = isVerified;
        }
    }
}
