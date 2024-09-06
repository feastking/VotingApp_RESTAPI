using Microsoft.AspNetCore.Mvc;
using VotingApp.Interfaces;
using VotingApp.Models;

namespace VotingApp.Controllers;

[Route("api/dashboard")]
[ApiController]
public class DashboardController(IDashboardService dashboardService) : ControllerBase
{
    [HttpGet]
    public ActionResult<DashboardDto> GetAllInformation() 
    {
        var allInformation = dashboardService.GetAllInformation();
        return Ok(allInformation);
    }
}
