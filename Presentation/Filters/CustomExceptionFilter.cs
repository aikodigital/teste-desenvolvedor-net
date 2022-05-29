using Application.ViewModels;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Presentation.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext contexto)
        {
            var codigo = HttpStatusCode.InternalServerError;
            var mensagem = "Não possível executar a operação solicitada, por favor contate do administrador do sistema.";

            if (contexto.Exception.GetType().Name == typeof(AikoException).Name)
            {
                mensagem = contexto.Exception.Message;
            }
            else if (contexto.Exception.GetType().Name == typeof(NotFoundException).Name)
            {
                codigo = HttpStatusCode.NotFound;
                mensagem = contexto.Exception.Message;
            }

            contexto.HttpContext.Response.ContentType = "application/json";
            contexto.HttpContext.Response.StatusCode = (int)codigo;
            contexto.Result = new JsonResult(new SaidaViewModel
            {
                Mensagem = mensagem,
                Sucesso = false
            });
        }
    }
}
