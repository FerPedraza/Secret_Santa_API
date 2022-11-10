using System.Collections.Generic;
using SecretSanta.Core.Entities;

namespace SecretSanta.Services.Services
{
    public interface IRaffleService
    {
        List<Pair> GetRaffle(int raffleId);
        List<Pair> SetRaffle(RaffleRequest req);
    }
}