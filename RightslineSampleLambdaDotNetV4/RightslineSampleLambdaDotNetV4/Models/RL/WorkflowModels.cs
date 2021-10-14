using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class WorkflowProcessListModel
    {
        public List<ProcessRestModel> Processes { get; set; } = new List<ProcessRestModel>();
    }

    public class ProcessRestModel
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
    }

    public class WorkflowActionListModel
    {
        public List<ActionRestModel> Actions { get; set; } = new List<ActionRestModel>();
    }

    public class ActionRestModel
    {
        public int ActionId { get; set; }
        public string ActionName { get; set; }

        public bool IsInitialAction { get; set; }

        public string ResultingStatus { get; set; }
    }

    public class WorkflowStatusListModel
    {
        public List<StatusRestModel> Statuses { get; set; } = new List<StatusRestModel>();
    }

    public class StatusRestModel
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeletable { get; set; }

        public List<ActionRestModel> AvailableActions { get; set; } = new List<ActionRestModel>();
    }

    public class GenerateDocumentRestModel
    {
        public int? TemplateId { get; set; }
    }
}