namespace VotingApp.Entities;

public class Voter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public int? CandidateId { get; set; }
    public virtual Candidate Candidate { get; set; } 
}
