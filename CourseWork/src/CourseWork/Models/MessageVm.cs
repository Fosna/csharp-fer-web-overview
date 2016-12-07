using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Models
{
    // This class is serialized to query string.
    // Make sure it's stimple enough to be serializable. 
    public class MessageVm
    {
        public string Message { get; set; }
        public string ReturnUrl { get; set; }

        public static MessageVm Create(IUrlHelper urlService, string message, string returnAction, string returnController, object routeValues = null)
        {
            var returnUrl = urlService.Action(returnAction, returnController, routeValues);
            return new MessageVm
            {
                Message = message,
                ReturnUrl = returnUrl
            };
        }
    }
}