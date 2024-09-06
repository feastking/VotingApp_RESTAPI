using Microsoft.AspNetCore.Mvc;
using VotingApp.Interfaces;
using VotingApp.Models;

namespace VotingApp.Controllers;

[Route("api/candidates")]
[ApiController]
public class CandidatesController(ICandidatesService candidatesService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CandidateDto>> GetCandidates()
    {
        var candidatesDTO = candidatesService.GetCandidates();

        return Ok(candidatesDTO);
    }

    [HttpPost]
    public ActionResult AddCandidate([FromBody] CreateCandidateDto candidateDto) 
    {
        candidatesService.AddCandidate(candidateDto);

        return Ok("Successfully Added");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCandidate([FromRoute] int id)
    {
        candidatesService.DeleteCandidate(id);

        return Ok("Successfully Deleted");
    }
}
