using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11_ASP_Zhyhlova.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

            string path = "Files/actions_logs.txt";
            if (File.Exists(path))
            {
                using (FileStream fs = File.OpenRead(path)) ;
            }
            else
            {
                using (FileStream fs = File.Create(path)) ;
            }

            string date = DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss");
            string str = $"{controllerName}/{actionName} - {date}\n";

            File.AppendAllText(path, str);

            base.OnActionExecuted(context);
        }
    }

}
