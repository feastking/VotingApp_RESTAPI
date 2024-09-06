using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using VotingApp.Entities;
using VotingApp.Enums;

namespace VotingApp;

public class VotingSeeder(VotingDbContext dbContext)
{
    public void Seed()
    {
        if (dbContext.Database.CanConnect())
        {
            if (!dbContext.Candidates.Any())
            {
                var candidates = SeedCandidates();
                dbContext.Candidates.AddRange(candidates);
                dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Candidate> SeedCandidates()
    {
        var candidates = new List<Candidate>()
        {
            new Candidate()
            {
                Name = "Piotr",
                Voters = new List<Voter>
                {
                    new Voter()
                    {
                        Name = "Voter1",
                        Age = 23,
                        Gender = Gender.Male.ToString()
                    },
                    new Voter()
                    {
                        Name = "Voter2",
                        Age = 28,
                        Gender = nameof(Gender.Male)
                    }
                }
            },
            new Candidate()
            {
                Name = "Michal"
            }
        };

        return candidates;
    }   
}
