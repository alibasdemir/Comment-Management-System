using System.Security.Cryptography;

namespace Core.Security.EmailCodeGenerator
{
    public class EmailCodeGeneratorHelper : IEmailCodeGeneratorHelper
    {
        public Task<string> CreateEmailGenerateCode()
        {
            string code = RandomNumberGenerator
            .GetInt32(Convert.ToInt32(Math.Pow(x: 10, y: 6)))
            .ToString()
            .PadLeft(totalWidth: 6, paddingChar: '0');
            return Task.FromResult(code);
        }
    }
}
