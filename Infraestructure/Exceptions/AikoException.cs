using System;

namespace Infrastructure.Exceptions
{
    public class AikoException : Exception
    {
        public AikoException(string mensagem) : base(mensagem)
        {
        }
    }
}
