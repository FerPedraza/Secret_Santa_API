using SecretSanta.Core.Entities;
using System.Collections.Generic;

namespace SecretSanta.Core.Interfaces
{
    public interface IRaffleRepository
    {
        List<Pair> GetRaffle(int id);
        List<Pair> SetRaffle(List<Pair> raffleSecuence);
    }
}