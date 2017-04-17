using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
	public class CostsEvaluator
	{
		private readonly IList<Tariff> _tariffs;

		public CostsEvaluator(IList<Tariff> tariffs)
		{
			_tariffs = tariffs.OrderBy(t => t.Range.From).ToList();
			var since = _tariffs.FirstOrDefault()?.Since;
			var until = _tariffs.FirstOrDefault()?.Until;

			foreach (var tariff in _tariffs)
			{
				if (since != tariff.Since || until != tariff.Until)
				{
					throw new ArgumentOutOfRangeException(
						  "cannot evaluate costs over inconsistent tariff range");
				}
			}
		}

		public decimal Calculate(int consumption)
		{
			decimal total = 0m;
			for (int i = 0; i < _tariffs.Count && consumption >= _tariffs[i].Range.From; i++)
			{
				total += (consumption - _tariffs[i].Range.From) * _tariffs[i].Price;
			}
			return total;
		}
	}
}
