namespace Core.Security.EmailCodeGenerator
{
    public interface IEmailCodeGeneratorHelper
    {
        public Task<string> CreateEmailGenerateCode();
    }
}
