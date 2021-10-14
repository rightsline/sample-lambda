using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class CreateDateMathModel
    {
        public DateMathCalcType Type;
        public DateTime? CompareToDate;
        public int ChildEntityTypeId;
        public int ChildId;
        public string ChildTagLabel;
        public DateMathRecalcOption RecalcOption;
        public DateMathConditionOption? ConditionOption;
        public DateMathDateOption? DateOption;
        public List<CreateDateMathCalcModel> ParentCalcs;
    }

    public class CreateDateMathCalcModel
    {
        public int EntityTypeId;
        public int Id;
        public string TagLabel;
        public int? YearQuantity;
        public int? MonthQuantity;
        public int? WeekQuantity;
        public int? DayQuantity;
        public DateMathFrequency? DayUnit;
        public bool? IsPriorTo;
        public int? SortOrder;
    }

    public enum DateMathDateOption
    {
        None = 0,
        FirstOfTheMonth = 1
    }

    public enum DateMathCalcType
    {
        Equals = 1,
        EarliestOf,
        LatestOf,
        PriorityOf
    }

    public enum DateMathRecalcOption
    {
        Hard = 1,
        Archive,
        Open
    }

    public enum DateMathFrequency
    {
        Days = 1,
        Weeks,
        Months,
        Years,
        BusinessDays
    }

    public enum DateMathConditionOption
    {
        ASAP = 1,
        KeepTBD
    }
}