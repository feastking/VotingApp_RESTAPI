namespace VotingApp.Entities;

public class Candidate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Voter> Voters { get; set; }
}
