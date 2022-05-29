using System;

namespace Application.Exceptions
{
    public class AikoException : Exception
    {
        public AikoException(string mensagem) : base(mensagem)
        {
        }
    }
}
