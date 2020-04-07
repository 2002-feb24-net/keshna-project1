﻿using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Project1.Controllers
{
    public class ErrorController : Controller
    {
      
              public IActionResult LogError()
        {
            //Get hold of the exceptiom that occured
            var exFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exFeature != null)
            {
                //Get the path where the eroor occured
                string path = exFeature.Path;

                //Get the Exception
                Exception ex = exFeature.Error;

                //Log in a flat fire or other storage
                Log.Error(ex, path);

                var error = new { ErrorMessage = ex.Message, ErrorPath = path };

                return BadRequest(error);

            }

            return BadRequest();

        }
    }
}