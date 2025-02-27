using ASWA.CCD.API.Entities;
using ASWA.CCD.Common.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ASWA.CCD.API
{
    public class GetSessions(ILogger<GetSessions> logger)
    {
        [Function("GetSessions")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sessions")] HttpRequest req, 
            [TableInput("sessions", Connection = "StorageConnectionString")] IEnumerable<SessionEntity> sessionInput)
        {
            logger.LogInformation("C# HTTP trigger function GetSessions processed a request.");
            var sessions = sessionInput.OrderBy(se => se.Start).ToList();

            return new OkObjectResult(sessions.Select(v => new SessionModel()
            {
                Id = v.Id,
                Duration = v.Duration,
                Description = v.Description,
                End = v.End,
                Room = v.Room,
                Title = v.Title,
                Speaker = v.Speaker,
                Start = v.Start
            }).ToArray());
        }
    }
}
    