namespace Ciudadanos_Sanos.Models
{
	public class MedicalHistory
	{

		public int Id { get; set; }

		public  int Patiente_Id	{get;set;}
		public int Doctor_Id { get;set;}
		public DateTime Date { get; set; }
		public Doctor Doctor { get;set;}
		public Patiente Patiente { get; set; }
	} 
}
