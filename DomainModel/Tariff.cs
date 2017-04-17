using System;

namespace DomainModel
{
	public class Tariff
	{
		public int Id { get; set; }
		public Range Range { get; set; }
		public decimal Price { get; set; }
		public DateTime? Since { get; set; }
		public DateTime? Until { get; set; }
	}
}