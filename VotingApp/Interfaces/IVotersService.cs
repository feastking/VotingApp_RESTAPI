using VotingApp.Models;

namespace VotingApp.Interfaces;

public interface IVotersService
{
    void AddVoter(CreateVoterDto voterDto);
    IEnumerable<VoterDto> GetVoters();
    void DeleteVoter(int id);
    void SubmitVote(SubmitVoteDto submitVoteDto);
}
