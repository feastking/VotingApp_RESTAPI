namespace VotingApp.Models;

public class CandidateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int VotersCount { get; set; }
    public List<VoterDto> Voters { get; set; }
}
