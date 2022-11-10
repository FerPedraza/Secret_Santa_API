using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Core.Entities
{
    public class Raffle
    {
        public int Id { get; set; }
        public List<Pair> RaffleSequence { get; set; }
        public Raffle(int id, List<Pair> raffleSec)
        {
            Id = id;
            RaffleSequence = raffleSec;
        }
    }
}
