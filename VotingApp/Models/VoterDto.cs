namespace VotingApp.Models;

public class VoterDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public bool hasVoted { get; set; }
}
