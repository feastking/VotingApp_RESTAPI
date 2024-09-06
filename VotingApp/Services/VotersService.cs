using AutoMapper;
using VotingApp.Entities;
using VotingApp.Exceptions;
using VotingApp.Interfaces;
using VotingApp.Models;
using VotingApp.Repositories;

namespace VotingApp.Services;

public class VotersService(IVotersRepository votersRepository, ICandidatesRepository candidatesRepository, IMapper mapper) : IVotersService
{
    public IEnumerable<VoterDto> GetVoters()
    {
        var voters = votersRepository.GetVoters();

        var votersDtos = mapper.Map<List<VoterDto>>(voters);

        return votersDtos;
    }

    public void AddVoter(CreateVoterDto voterDto)
    {
        DoesVoterExists(voterDto.Name);
        var voter = mapper.Map<Voter>(voterDto);

        votersRepository.AddVoter(voter);
    }

    private void DoesVoterExists(string name)
    {
        var voters = votersRepository.GetVoters();

        if (voters.Any(c => c.Name == name))
        {
            throw new BadRequestException("Voter already exists.");
        }
    }

    public void DeleteVoter(int id)
    {
        var voter = votersRepository.GetVoter(id);

        if (voter is null)
        {
            throw new BadRequestException("Voter cannot be deleted, as it does not exist.");
        }

        votersRepository.DeleteVoter(voter);
    }

    public void SubmitVote(SubmitVoteDto submitVoteDto)
    {
        var voter = votersRepository.GetVoter(submitVoteDto.Id);

        if (voter is null)
        {
            throw new BadRequestException("Voter cannot vote, as it does not exist.");
        }

        var candidate = candidatesRepository.GetCandidate(submitVoteDto.CandidateId);

        if (candidate is null)
        {
            throw new BadRequestException("Candidate does not exist.");
        }

        voter.CandidateId = submitVoteDto.CandidateId;

        votersRepository.UpdateVoter(voter);
    }
}
