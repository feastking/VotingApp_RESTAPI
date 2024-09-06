using Microsoft.EntityFrameworkCore;
using VotingApp.Entities;
using VotingApp.Interfaces;

namespace VotingApp.Repositories;

public class VotersRepository(VotingDbContext context) : IVotersRepository
{
    public List<Voter> GetVoters()
    {
        return [.. context.Voters];
    }

    public Voter GetVoter(int id)
    {
        return context.Voters.First(c => c.Id == id);
    }

    public void AddVoter(Voter voter)
    {
        context.Voters.Add(voter);
        context.SaveChanges();
    }

    public void DeleteVoter(Voter voter)
    {
        context.Voters.Remove(voter);
        context.SaveChanges();
    }

    public void UpdateVoter(Voter voter)
    {
        context.Voters.Update(voter);
        context.SaveChanges();
    }
}
