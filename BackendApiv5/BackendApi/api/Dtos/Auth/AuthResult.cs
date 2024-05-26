using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Auth
{
    public class AuthResult
    {
        
        public string Token { get; set; } =string.Empty;
         
        public bool Result { get; set; } 
        
        public List<string> Errors { get; set; } 
    }
}