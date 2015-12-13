namespace NinjaDomain.Classes
{
	public class NinjaEquipment
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public EquipmentType Type { get; set; }
		public Ninja Ninja { get; set; }
	}
}
