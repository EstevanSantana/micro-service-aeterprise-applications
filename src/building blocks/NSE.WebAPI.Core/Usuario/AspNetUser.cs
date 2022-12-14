using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebAPI.Core.Usuario
{
    public class AspNetUser : IAspNetUser
    {
        public string Nome => _accessor.HttpContext.User.Identity.Name;

        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserEmail() : string.Empty;
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserToken() : string.Empty;
        }

        public bool EstaAutenticado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool PossuiRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _accessor.HttpContext;
        }
    }
}
