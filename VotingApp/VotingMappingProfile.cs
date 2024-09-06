using AutoMapper;
using VotingApp.Entities;
using VotingApp.Models;

namespace VotingApp;

public class VotingMappingProfile : Profile
{
    public VotingMappingProfile()
    {
        CreateMap<Candidate, CandidateDto>()
            .ForMember(dest => dest.VotersCount, opt => opt.MapFrom(src => src.Voters.Count));

        CreateMap<CreateCandidateDto, Candidate>();

        CreateMap<Voter, VoterDto>()
            .ForMember(dest => dest.hasVoted, opt => opt.MapFrom(src => src.CandidateId.HasValue));

        CreateMap<VoterDto, Voter>();

        CreateMap<VoterDto, VotersToVoteDto>();

        CreateMap<CreateVoterDto, Voter>();
    }
}
