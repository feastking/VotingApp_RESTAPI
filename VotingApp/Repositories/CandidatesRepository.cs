using Microsoft.EntityFrameworkCore;
using VotingApp.Entities;
using VotingApp.Interfaces;

namespace VotingApp.Repositories;

public class CandidatesRepository(VotingDbContext context) : ICandidatesRepository
{
    public List<Candidate> GetCandidates()
    {
        return [.. context.Candidates.Include(v => v.Voters)];
    }

    public Candidate? GetCandidate(int id)
    {
        return context.Candidates.Include(v => v.Voters).FirstOrDefault(c => c.Id == id);
    }

    public void AddCandidate(Candidate candidate)
    {
        context.Candidates.Add(candidate);
        context.SaveChanges();
    }

    public void DeleteCandidate(Candidate candidate)
    {
        context.Candidates.Remove(candidate);
        context.SaveChanges();
    }
}
