using DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
	public class ConsumptionEvaluator
	{
		public int Calculate(IList<Measurement> measurements)
		{
			var ascending = measurements.OrderBy(m => m.Value).ToList();
			return ascending.Last().Value - ascending.First().Value;
		}
	}
}
