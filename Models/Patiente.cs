namespace Ciudadanos_Sanos.Models
{
	public class Patiente
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Document { get; set; }
		
		public ICollection<Patiente>? Patientes { get; set; }
	}
}
