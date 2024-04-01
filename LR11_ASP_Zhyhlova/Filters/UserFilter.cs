using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11_ASP_Zhyhlova.Filters
{
    public class UserFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var userIp = context.HttpContext.Connection.RemoteIpAddress;

            string pathUsers = "Files/users_ip.txt";
            string pathCounter = "Files/users_counter.txt";

            if (File.Exists(pathUsers) && (File.Exists(pathCounter)))
            {
                using (FileStream fs1 = File.OpenRead(pathUsers)) ;
                using (FileStream fs2 = File.OpenRead(pathCounter)) ;
            }
            else if (!File.Exists(pathUsers))
            {
                using (FileStream fs = File.Create(pathUsers)) ;
            }
            if (!File.Exists(pathCounter))
            {
                using (FileStream fs = File.Create(pathCounter)) ;
                File.WriteAllText(pathCounter, "0");
            }

            var content = File.ReadAllText(pathUsers);

            if (!content.Contains(userIp.ToString()))
            {
                File.AppendAllText(pathUsers, userIp.ToString() + "\n");
                File.WriteAllText(pathCounter, (Int32.Parse(File.ReadAllText(pathCounter)) + 1).ToString());
            }

            base.OnActionExecuted(context);
        }
    }
}