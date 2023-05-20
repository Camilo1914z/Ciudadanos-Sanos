namespace Ciudadanos_Sanos.Models
{
	public class Doctor
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Document { get; set; }

		public ICollection<Doctor>? Doctors { get; set; }


	}
}
