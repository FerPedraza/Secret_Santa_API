using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SecretSanta.Core.Entities;
using SecretSanta.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SecretSanta.Services.Services
{
    public class RaffleService : IRaffleService
    {
        IRaffleRepository _RaffleRepo;
        static Random random = new Random();

        public RaffleService(IRaffleRepository raffleRepo)
        {
            _RaffleRepo = raffleRepo;
        }

        public List<Pair> SetRaffle(RaffleRequest req)
        {
            List<Pair> Raffle = new List<Pair>();
            List<Person> participants = new List<Person>(req.People);
            List<Person> givingPeople = new List<Person>(req.People);
            List<Group> groups = new List<Group>(req.Groups);

            
            if (req.Groups.Count != 0)
            {
                while(groups.Count > 0)
                {
                    var maxPeople = groups.Max(r => r.People.Count);
                    var maxPeopleGroup = groups.Where(p => p.People.Count == maxPeople).FirstOrDefault();
                    maxPeopleGroup.People.ForEach(givingPerson =>
                    {
                        Boolean match = false;
                        while (!match)
                        {
                            int index = random.Next(participants.Count);
                            if (givingPerson.Name != participants[index].Name)
                            {
                                match = true;
                            }
                            if (maxPeopleGroup.People.Any(p => p.Name == givingPerson.Name) &&
                            maxPeopleGroup.People.Any(p => p.Name == participants[index].Name))
                            {
                                match = false;
                            }
                            if (match)
                            {
                                Raffle.Add(new Pair(givingPerson, participants[index]));
                                participants.Remove(participants[index]);
                                groups.Remove(maxPeopleGroup);
                                givingPeople.Remove(givingPeople.Where(item => item.Name == givingPerson.Name).FirstOrDefault());
                            }
                        }

                    });
                }
            }
            if (givingPeople.Count == 3)
            {
                Raffle.Add(new Pair(givingPeople[0], participants[2]));
                Raffle.Add(new Pair(givingPeople[1], participants[0]));
                Raffle.Add(new Pair(givingPeople[2], participants[1]));

            }
            else
            {

            givingPeople.ForEach(givingPerson =>
            {
                Boolean match = false;
                while (!match)
                {
                    
                    int index = random.Next(participants.Count );
                    if (givingPerson.Name != participants[index].Name)
                    {
                        match = true;
                    }
                    if (match)
                    {
                        Raffle.Add(new Pair(givingPerson, participants[index]));
                        participants.Remove(participants[index]);
                    }
                }

            });
            }





            return _RaffleRepo.SetRaffle(Raffle);
        }
        public List<Pair> GetRaffle(int raffleId)
        {
            return _RaffleRepo.GetRaffle(raffleId);
        }
    }
}
