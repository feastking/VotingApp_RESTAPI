using AutoMapper;
using VotingApp.Interfaces;
using VotingApp.Models;

namespace VotingApp.Services;

public class DashboardService(IVotersService votersService, ICandidatesService candidatesService, IMapper mapper) : IDashboardService
{
    public DashboardDto GetAllInformation()
    {
        DashboardDto dashboardDto = new DashboardDto()
        {
            Voters = votersService.GetVoters(),
            Candidates = candidatesService.GetCandidates(),
        };

        dashboardDto.VotersToVote = mapper.Map<List<VotersToVoteDto>>(dashboardDto.Voters.Where(x => x.hasVoted == false));

        return dashboardDto;
    }
}
