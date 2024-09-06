using VotingApp.Entities;

namespace VotingApp.Interfaces;

public interface IVotersRepository
{
    List<Voter> GetVoters();
    Voter GetVoter(int id);
    void AddVoter(Voter voter);
    void DeleteVoter(Voter voter);
    void UpdateVoter(Voter voter);
}
