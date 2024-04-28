using System.Reflection;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreWebApi.Filters
{
    public class TransactionScopeFilter:IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            ControllerActionDescriptor controllerActionDesc = context.ActionDescriptor as ControllerActionDescriptor;
            bool isUseTranscope = false;
            if(controllerActionDesc != null)
            {
                bool hasNotTransactionalAttribute = controllerActionDesc.MethodInfo.GetCustomAttributes(typeof(NotTransactionalAttribute),false).Any();
                isUseTranscope = !hasNotTransactionalAttribute;
            }
            if(isUseTranscope)
            {
                using (TransactionScope txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var r = await next();
                    if (r.Exception == null)
                    {
                        txScope.Complete();
                    }
                }
            }
            else
            {
                await next();
            }



        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class NotTransactionalAttribute :Attribute
    {

        
    }
}
