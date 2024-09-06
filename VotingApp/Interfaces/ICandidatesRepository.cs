using VotingApp.Entities;

namespace VotingApp.Interfaces;

public interface ICandidatesRepository
{
    List<Candidate> GetCandidates();
    Candidate? GetCandidate(int id);
    void AddCandidate(Candidate candidate);
    void DeleteCandidate(Candidate candidate);

}
