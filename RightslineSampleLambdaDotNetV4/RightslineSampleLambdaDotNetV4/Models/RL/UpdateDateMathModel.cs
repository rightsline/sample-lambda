using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class UpdateDateMathModel
    {
        public long? DateMathCalcId;
        public DateMathCalcType? Type;
        public DateTime? CompareToDate;
        public DateMathRecalcOption? RecalcOption;
        public DateMathConditionOption? ConditionOption;
        public DateMathDateOption? DateOption;
        public List<CreateDateMathCalcModel> CreateParentCalcs;
        public List<UpdateDateMathCalcModel> UpdateParentCalcs;
        public List<int> DeleteParentCalcs;
    }

    public class UpdateDateMathCalcModel
    {
        public int? DateMathRelId;
        public int? YearQuantity;
        public int? MonthQuantity;
        public int? WeekQuantity;
        public int? DayQuantity;
        public DateMathFrequency? DayUnit;
        public bool? IsPriorTo;
        public int? SortOrder;
    }
}