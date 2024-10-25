using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class MessageResponse
    {
        public MessageResponse()
        {
            StateCode = "500";
            FriendlyMessage = "Upss, Something went wrong";
        }
        public MessageResponse(string code, string friendly, string message)
        {
            StateCode = code;
            FriendlyMessage = friendly;
            Message = message;
        }

        public MessageResponse(string code, string friendly)
        {
            StateCode = code;
            FriendlyMessage = friendly;
        }
        
        public string StateCode { get; set; }
        public string Message { get; set; }
        public string FriendlyMessage { get; set; }
    }
}