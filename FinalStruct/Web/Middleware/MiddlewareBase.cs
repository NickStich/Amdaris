using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Middleware
{
    public class MiddlewareBase
    {
        private readonly RequestDelegate _requestDelegate;

        public MiddlewareBase(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var requestDate = DateTime.Now;
            var url = httpContext.Request.GetDisplayUrl();
            var ip = httpContext.Request.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            var isAuth = httpContext.Request.HttpContext.User.Identity.IsAuthenticated;
            var reqLength = (int?)httpContext.Request.ContentLength;
            //var browType = httpContext.Request.Headers["User-Agent"].ToString();
            var browName = httpContext.Request.Headers["User-Agent"].ToString();
            //var browVers = httpContext.Request.Headers["User-Agent"].ToString();
            using (var dbContext = new AccountingAppDbContext())
            {
                dbContext.WebAnalytics.Add(
                    new WebAnalytics
                    {
                        RequestTime = requestDate,
                        RequestURL = url,
                        IPAdress = ip,
                        IsRequestAuthenticated = isAuth,
                        RequestLength = reqLength,
                        BrowserName = browName
                    }
                    ) ;
                dbContext.SaveChanges();                
            }
                await _requestDelegate(httpContext);
        }
    }
}
