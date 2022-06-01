using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using IMMRequest.BusinessLogic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.Domain;

namespace IMMRequest.WebApi.Filters
{
    public class AuthFilter : Attribute, IActionFilter
    {
        private ISession<AdminSession> AdminSession;


        private ISession<AdminSession> GetSessions(ActionExecutingContext context)
        {
            return (ISession<AdminSession>)context.HttpContext.RequestServices.GetService(typeof(ISession<AdminSession>));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["auth"];
            if(token==null){
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = "No se ingreso Token",
                };
            return;
            }
            AdminSession = GetSessions(context);
            if(!AdminSession.estaLogueado(Int32.Parse(token))){
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "No esta Logueado",
                };
            return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}