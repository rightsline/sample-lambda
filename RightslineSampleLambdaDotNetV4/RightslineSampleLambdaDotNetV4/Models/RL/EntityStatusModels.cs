using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
	public class EntityStatusRestModel
	{
		public int StatusId { get; set; }
		public string StatusName { get; set; }
	}

	public class EntityStatusListModel
	{
		public List<EntityStatusRestModel> Statuses { get; set; } = new List<EntityStatusRestModel>();
    }
}