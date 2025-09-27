using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RMS.Application.DTOs;
using RMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RMS.Infrastructure.Services.ThirdParty
{
    public class ApilayerResumeProcessor : IThirdPartyResumeProcessor
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "GLy87ak3Qja52GKv7qyjf66Csn0o92XY";

        public ApilayerResumeProcessor(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResumeData> ProcessResumeAsync(IFormFile resumeFile)
        {
            using var ms = new MemoryStream();
            await resumeFile.CopyToAsync(ms);
            var bytes = ms.ToArray();

            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.apilayer.com/resume_parser/upload");
            request.Headers.Add("apikey", _apiKey);
            request.Content = new ByteArrayContent(bytes);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var resumeData = JsonConvert.DeserializeObject<ResumeData>(json);

            return resumeData;
        }
    }
}
