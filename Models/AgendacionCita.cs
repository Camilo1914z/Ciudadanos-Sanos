namespace Ciudadanos_Sanos.Models
{
    public class AgendacionCita
    {
        	public int Id { get; set; }

		public  int Patiente_Id	{get;set;}
		public int Doctor_Id { get;set;}
		public DateTime Date { get; set; }
		public Doctor Doctor { get;set;}
		public Patiente Patiente { get; set; } 

		public ICollection<AgendacionCita>? AgendacionCitas { get; set; }

    }
}
