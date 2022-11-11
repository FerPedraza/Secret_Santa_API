using SecretSanta.Core.Entities;
using SecretSanta.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Infrastructure.Repositories
{
    public class RaffleRepository : IRaffleRepository
    {
        private Raffle _Raffle;

        public RaffleRepository()
        {

        }
        public List<Pair> SetRaffle(List<Pair> raffleSecuence)
        {
            //_Raffle = new Raffle(0, raffleSecuence);

            return raffleSecuence;
        }
        public List<Pair> GetRaffle(int id)
        {
            //Unique Raffle avalaible
            return _Raffle.RaffleSequence;
        }

    }
}
