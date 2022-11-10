using System;
namespace SecretSanta.Core.Entities
{
	public class Pair
	{
		public Person GivingPerson { get; set; }
		public Person ReceivingPerson { get; set; }
		public Pair(Person givingPerson, Person receivingPerson)
		{
			GivingPerson = givingPerson;
			ReceivingPerson = receivingPerson;

        }
	}
}

