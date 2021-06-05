﻿using Genocs.FormRecognizer.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Genocs.FormRecognizer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {

        private readonly IDistributedCache _distributedCache;


        public SettingsController(IDistributedCache distributedCache)
        {
            this._distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        /// <summary>
        /// It allows to classify an image.
        /// </summary>
        /// <param name="url">The HTML encoded url</param>
        /// <returns>The classification result</returns>
        [Route("SetupClassificationModel"), HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostSetupClassificationModel([FromBody] SetupSettingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Key))
            {
                return BadRequest("key cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(request.Value))
            {
                return BadRequest("value cannot be null or empty");
            }

            await _distributedCache.SetAsync(request.Key, Encoding.UTF8.GetBytes(request.Value));

            return NoContent();
        }

    }
}
