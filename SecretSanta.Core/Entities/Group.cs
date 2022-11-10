using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Core.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public List<Person> People { get; set; }
    }
}
