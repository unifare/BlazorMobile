﻿using Daddoon.Blazor.Xam.Interop;
using Daddoon.Blazor.Xam.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace Daddoon.Blazor.Xam.Controller
{
    public class BlazorController : WebApiController
    {
        public BlazorController(IHttpContext context) : base(context)
        {
        }

        [WebApiHandler(HttpVerbs.Get, "/(.)*")]
        public async Task<bool> BlazorAppRessources()
        {
            try
            {
                IWebResponse response = new EmbedIOWebResponse(this.Request, this.Response);
                await WebApplicationFactory.ManageRequest(response);
                return true;
            }
            catch (Exception ex)
            {
                return this.JsonExceptionResponse(ex);
            }
        }

        // You can override the default headers and add custom headers to each API Response.
        public override void SetDefaultHeaders() => this.NoCache();
    }
}
