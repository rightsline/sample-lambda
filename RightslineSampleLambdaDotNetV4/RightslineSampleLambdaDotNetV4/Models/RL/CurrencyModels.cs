using System;

namespace RightsLine.Contracts.RestApi.V4
{
	public class CurrencyConversionRestModel
	{
		public Guid ID { get; set; }
		public string CompanyCurrency { get; set; }
		public string TransactionCurrency { get; set; }
		public decimal Rate { get; set; }
		public DateTime? EffectiveDate { get; set; }
	}
}
