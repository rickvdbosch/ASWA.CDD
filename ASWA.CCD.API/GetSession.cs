using ASWA.CCD.API.Entities;
using ASWA.CCD.Common.Models;

using Azure.Data.Tables;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ASWA.CCD.API
{
    public class GetSession(ILogger<GetSession> logger)
    {
        [Function("GetSession")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sessions/{day}/{id}")] HttpRequest req,
            [TableInput("sessions", "{day}", "{id}", Connection = "StorageConnectionString")] TableEntity sessionInput)
        {
            logger.LogInformation("C# HTTP trigger function GetSession processed a request.");
            var session = sessionInput.ToEntity<SessionEntity>();

            return new OkObjectResult(new SessionModel()
            {
                Id = session.Id,
                Title = session.Title,
                Duration = session.Duration,
                Description = session.Description,
                End = session.End,
                Room = session.Room,
                Speaker = session.Speaker,
                Start = session.Start
            });
        }
    }
}
