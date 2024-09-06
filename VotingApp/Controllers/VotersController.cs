using Microsoft.AspNetCore.Mvc;
using VotingApp.Interfaces;
using VotingApp.Models;

namespace VotingApp.Controllers;

[Route("api/voters")]
[ApiController]
public class VotersController(IVotersService voterService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<VoterDto>> GetVoters()
    {
        var votersDTO = voterService.GetVoters();

        return Ok(votersDTO);
    }

    [HttpPost]
    public ActionResult AddVoter([FromBody] CreateVoterDto voterDTO)
    {
        voterService.AddVoter(voterDTO);

        return Ok("Successfully Added");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteVoter([FromRoute] int id)
    {
        voterService.DeleteVoter(id);

        return Ok("Successfully Deleted");
    }

    [HttpPut]
    public ActionResult SubmitVote([FromBody] SubmitVoteDto submitVoteDto)
    {
        voterService.SubmitVote(submitVoteDto);

        return Ok("Vote submitted.");
    }
}
