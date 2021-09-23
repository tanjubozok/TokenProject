using System;

namespace TokenProject.MvcUI.Models
{
    public class AccessToken
    {
        public string Token { get; set; }  // Token Değeri
        public DateTime Expiration { get; set; } // Token geçerlilik süresi
    }
}
