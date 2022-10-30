using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using User.Application.Contracts.Infrastructure.Interfaces;
using User.Application.Dto;
using User.Application.Helpers.Extension;

namespace User.Application.Contracts.Infrastructure.Services
{
    public class PostService:IPostService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public PostService(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<bool> CheckPostalCodeLen(int postalCode)
        {
            // request and timeout 5 second control
            var requestTimeout = TimeSpan.FromSeconds(10);
            var httpTimeout = TimeSpan.FromSeconds(5);
            _client.Timeout = httpTimeout;

            try
            {
                var url = $"/api/PostalCode/CheckPostalCodeLen/{postalCode}";
                using var tokenSource = new CancellationTokenSource(requestTimeout);
                var response = await _client.GetAsync(url, tokenSource.Token);

                var result = await response.ReadContentAs<PostServiceResponseDto>();
                _logger.LogInformation("Request Success");
                return result.Result;
            }
            catch (TaskCanceledException e)
            {
                _logger.LogError("Request TimeOut");
                return false;
            }
          
        }
    }
}
