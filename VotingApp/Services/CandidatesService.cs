using AutoMapper;
using VotingApp.Entities;
using VotingApp.Exceptions;
using VotingApp.Interfaces;
using VotingApp.Models;

namespace VotingApp.Services;

public class CandidatesService(ICandidatesRepository candidatesRepository, IMapper mapper) : ICandidatesService
{
    public IEnumerable<CandidateDto> GetCandidates()
    {
        var candidates = candidatesRepository.GetCandidates();

        var candidatesDtos = mapper.Map<List<CandidateDto>>(candidates);

        return candidatesDtos;
    }

    public void AddCandidate(CreateCandidateDto candidateDto)
    {
        DoesCandidateExists(candidateDto.Name);

        var candidate = mapper.Map<Candidate>(candidateDto);

        candidatesRepository.AddCandidate(candidate);
    }

    private void DoesCandidateExists(string name)
    {
        var candidates = candidatesRepository.GetCandidates();

        if (candidates.Any(c => c.Name == name))
        {
            throw new BadRequestException("Candidate already exists.");
        }
    }

    public void DeleteCandidate(int id)
    {
        var candidate = candidatesRepository.GetCandidate(id);

        if (candidate is null)
        {
            throw new BadRequestException("Candidate cannot be deleted, as it does not exist.");
        }
        else if(candidate.Voters.Count > 0)
        {
            throw new BadRequestException("Candidate cannot be deleted, as it already has votes from Voters.");
        }

        candidatesRepository.DeleteCandidate(candidate);
    }
}
