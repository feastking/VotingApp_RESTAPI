using VotingApp.Models;

namespace VotingApp.Interfaces;

public interface ICandidatesService
{
    void AddCandidate(CreateCandidateDto candidateDto);
    IEnumerable<CandidateDto> GetCandidates();
    void DeleteCandidate(int id);
}
