namespace VotingApp.Models;

public class DashboardDto
{
    public IEnumerable<VoterDto>? Voters { get; set; }
    public IEnumerable<CandidateDto>? Candidates { get; set; }
    public List<VotersToVoteDto>? VotersToVote { get; set; }
}
