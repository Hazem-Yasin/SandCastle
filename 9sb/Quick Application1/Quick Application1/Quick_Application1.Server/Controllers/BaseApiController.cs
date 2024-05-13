﻿// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quick_Application1.Core.Services.Account;
using Quick_Application1.Server.Attributes;
using Quick_Application1.Server.Services;

namespace Quick_Application1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SanitizeModel]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseApiController> _logger;

        public BaseApiController(ILogger<BaseApiController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        protected string GetCurrentUserId(string errorMsg = "Error retrieving the userId for the current user.")
        {
            return Utilities.GetUserId(User) ?? throw new UserNotFoundException(errorMsg);
        }

        protected void AddModelError(IEnumerable<string> errors, string key = "")
        {
            foreach (var error in errors)
            {
                AddModelError(error, key);
            }
        }

        protected void AddModelError(string error, string key = "")
        {
            ModelState.AddModelError(key, error);
        }
    }
}
