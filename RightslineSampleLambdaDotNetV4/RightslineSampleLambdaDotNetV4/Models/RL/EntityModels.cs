using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RightsLine.Contracts.Data.Comment;

namespace RightsLine.Contracts.RestApi.V4
{
    public class EntitySearchModel
    {
        public string Keywords { get; set; }
        public JObject Query { get; set; }
        public int? Start { get; set; }
        public int? Rows { get; set; }
        public string CursorToken { get; set; }
        public List<string> SortOrders { get; set; } = new List<string>();

        public Dictionary<int, JObject> ParentQuery { get; set; } = new Dictionary<int, JObject>();

        public Dictionary<int, JObject> ChildQuery { get; set; } = new Dictionary<int, JObject>();
    }


    public class EntityTitleAvailableResponse
    {
        public bool IsAvailable { get; set; }
        public bool IsExclusive { get; set; }
    }

    public class EntityAvailabilityResponse
    {
        public int RowCount { get; set; }
        public List<EntityAvailabilityCalculationResponse> Rows { get; set; } = new List<EntityAvailabilityCalculationResponse>();
    }

    public class EntityAvailabilityCalculationResponse: EntityAvailableCatalogItemRestModel
    {
        public DateTime LastUpdatedDate { get; set; }
        public EntityTemplateRestModel Template { get; set; }
        public EntityStatusRestModel Status { get; set; }
        [JsonConverter(typeof(CustomIsoDateOnlyConverter))]
        public DateTime WindowStart { get; set; }
        [JsonConverter(typeof(CustomIsoDateOnlyConverter))]
        public DateTime WindowEnd { get; set; }
        public List<CharDataRestModel> Dim1 { get; set; } = null;
        public List<CharDataRestModel> Dim2 { get; set; } = null;
        public List<CharDataRestModel> Dim3 { get; set; } = null;
        public List<CharDataRestModel> Dim4 { get; set; } = null;
        public bool IsExclusive { get; set; }
        public bool IsExact { get; set; }
        public string MatchType { get; set; }
        public string Available { get; set; }
        public string ReasonUnavailable { get; set; }
    }

    public class EntityAvailableCatalogItemRestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }


    public class EntitySearchResponse
    {
        public int NumFound { get; set; }
        public List<EntityRestModel> Entities { get; set; } = new List<EntityRestModel>();
    }

    public class EntityRestModel
    {
        public int? Id { get; set; }
        public int? RevisionId { get; set; }
        public string Title { get; set; }
        public EntityTemplateRestModel Template { get; set; }
        public EntityStatusRestModel Status { get; set; }

        [JsonConverter(typeof(CharacteristicDataItemConverter))]
        public Dictionary<string, List<CharDataRestModel>> Characteristics { get; set; } = new Dictionary<string, List<CharDataRestModel>>();
        public List<RIS_Comment> Comments { get; set; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int? StatusUpdatedById { get; set; }
        public DateTime? StatusUpdatedDate { get; set; }


        public EntityRestModel(EntityRestModel restModel)
        {
            if (restModel == null) return;
            Id = restModel.Id;
            RevisionId = restModel.RevisionId;
            Title = restModel.Title;
            Template = restModel.Template;
            Status = restModel.Status;
            Characteristics = restModel.Characteristics;
            Comments = restModel.Comments;
            CreatedById = restModel.CreatedById;
            CreatedById = restModel.CreatedById;
            LastUpdatedById = restModel.LastUpdatedById;
            LastUpdatedDate = restModel.LastUpdatedDate;
            StatusUpdatedById = restModel.StatusUpdatedById;
            StatusUpdatedDate = restModel.StatusUpdatedDate;
        }

        public EntityRestModel()
        {

        }
    }

    public class MoneyValueRestModel
    {
        public string LocAmt { get; set; }
        public int? LocCur { get; set; }
        public string LocSym { get; set; }
        public string DivAmt { get; set; }
        public int? DivCur { get; set; }
        public string DivSym { get; set; }
    }

    public class CharDataRestModel : Common.CharDataRestModel
    {
        public CharDataRestModel() : base()
        {

        }
        public CharDataRestModel(string value) : base(value)
        {
        }
    }

    public class CharDataListRestModel : List<CharDataRestModel>
    {
        [JsonIgnore]
        public bool IsMultiple { get; set; }

        public CharDataListRestModel(IEnumerable<CharDataRestModel> charDatas, bool isMultiple = false)
        {
            this.AddRange(charDatas);
            this.IsMultiple = isMultiple;
        }

        public CharDataListRestModel(bool isMultiple)
        {
            this.IsMultiple = isMultiple;
        }

        public CharDataListRestModel()
        {

        }
    }

    public class FriendlyLOVModel
    {
        public int? Id { get; set; }
        public string Tag_Label { get; set; }
    }

    public class AvailabilityCalculationSearchBaseModel
    {
        public List<int> RecordID { get; set; }
        public List<int> Dim1 { get; set; }
        public List<int> Dim2 { get; set; }
        public List<int> Dim3 { get; set; }
        public List<int> Dim4 { get; set; }
        [JsonConverter(typeof(CustomIsoDateOnlyConverter))]
        public DateTime WindowStart { get; set; }
        [JsonConverter(typeof(CustomIsoDateOnlyConverter))]
        public DateTime WindowEnd { get; set; }
        public bool? IsExclusive { get; set; }
        public string MatchType { get; set; }
        public int Start { get; set; }
        public int Rows { get; set; }
    }

    public enum DateQueryOption
    {
        CoverEntire = 0,
        OverlapPart,
        StartWithin,
        EndWithin
    }

    public enum UnavailReasonIds
    {
        NoRightsIn = 1,
        RightsOut = 2,
        ExclusivityMismatch = 3,
        ExactMismatch = 4
    }

    public class IsAvailableRequestModel : AvailabilityCalculationSearchBaseModel
    {
        public int RecordID { get; set; }

    }

    public class AvailabilityCalculationResponseRestModel
    {
        public int RowCount { get; set; }
        public List<AvailabilityCalculationRestModel> Rows { get; set; } = new List<AvailabilityCalculationRestModel>();
    }

    public class AvailableCatalogItemsResponseRestModel
    {
        public int RowCount { get; set; }
        public List<AvailableCatalogItemRestModel> Rows { get; set; } = new List<AvailableCatalogItemRestModel>();
    }

    public class AvailabilityCalculationRestModel : AvailableCatalogItemRestModel
    {
        public DateTime LastUpdatedDate { get; set; }
        public EntityTemplateRestModel Template { get; set; }
        public EntityStatusRestModel Status { get; set; }
        [JsonConverter(typeof(CustomIsoDateOnlyConverter))]
        public DateTime WindowStart { get; set; }
        [JsonConverter(typeof(CustomIsoDateOnlyConverter))]
        public DateTime WindowEnd { get; set; }
        public List<CharDataRestModel> Dim1 { get; set; } = null;
        public List<CharDataRestModel> Dim2 { get; set; } = null;
        public List<CharDataRestModel> Dim3 { get; set; } = null;
        public List<CharDataRestModel> Dim4 { get; set; } = null;
        public bool IsExclusive { get; set; }
        public bool IsExact { get; set; }
        public string MatchType { get; set; }
        public string Available { get; set; }
        public string ReasonUnavailable { get; set; }
    }

    public class AvailableCatalogItemRestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class TitleAvailableRestModel
    {
        public bool IsAvailable { get; set; }
        public bool IsExclusive { get; set; }
    }

    public class DimensionRestModel
    {
        public List<CharMetaDataValueRestModel> Dim1 { get; set; } = null;
        public List<CharMetaDataValueRestModel> Dim2 { get; set; } = null;
        public List<CharMetaDataValueRestModel> Dim3 { get; set; } = null;
        public List<CharMetaDataValueRestModel> Dim4 { get; set; } = null;

    }

    public class DateMathResultModel
    {
        public DateMathResultModel()
        {
            ParentCalcs = new List<DateMathRelRestModel>();
        }

        public string Result;
        public long DateMathCalcId;
        public bool IsCalculated;
        public DateTime? CompareToDate;
        public string DateOption;
        public DateMathCalcRestModel ChildCharacteristic;
        public List<DateMathRelRestModel> ParentCalcs;
    }

    public class DateMathRestModel
    {
        public string EntityTitle;
        public int EntityTypeId;
        public int Id;
        public string TagLabel;
        public string Label;
        public int CharacteristicId;

        public DateMathCalcRestModel ToCalc()
        {
            return new DateMathCalcRestModel
            {
                EntityTitle = EntityTitle,
                EntityTypeId = EntityTypeId,
                Id = Id,
                CharacteristicId = CharacteristicId,
                Label = Label,
                TagLabel = TagLabel
            };
        }

        public DateMathRelRestModel ToRel()
        {
            return new DateMathRelRestModel
            {
                EntityTitle = EntityTitle,
                EntityTypeId = EntityTypeId,
                Id = Id,
                CharacteristicId = CharacteristicId,
                Label = Label,
                TagLabel = TagLabel
            };
        }
    }

    public class DateMathCalcRestModel : DateMathRestModel
    {
        public string Type;
    }

    public class DateMathRelRestModel : DateMathRestModel
    {
        public int DateMathRelId;
        public int? YearQuantity;
        public int? MonthQuantity;
        public int? WeekQuantity;
        public int? DayQuantity;
        public string DayUnit;
        public bool? IsPriorTo;
        public int SortOrder;
    }

    public class AvailabilityCalculationSearchModel : AvailabilityCalculationSearchBaseModel
    {
        public bool? IsExact { get; set; }
        public bool? IsWindowingEnforced { get; set; }
        public bool? ShowUnavailable { get; set; }
    }

    public class EntityBatchRecordResponseRestModel : BatchRecordResponseRestModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityRestModel Record { get; set; }
    }

    public class RelationshipBatchRecordResponseRestModel : BatchRecordResponseRestModel
    {
        public RelationshipBatchRecordResponseRestModel()
        {
            CharTypeId = 0;
        }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityRelationshipRestModel Relationship { get; set; }
    }

    public class BatchRecordResponseRestModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        [JsonIgnore]
        public int CharTypeId { get; set; }
    }

    public class EntityBatchRequestRestModel
    {
        public string Method { get; set; }
        public EntityBatchOptionsRestModel BatchOptions { get; set; } = EntityBatchOptionsRestModel.Default;
        public Dictionary<int, List<EntityExRestModel>> Records { get; set; }
        public List<EntityRelationshipRestModel> Relationships { get; set; }
    }

    public class EntityBatchOptionsRestModel
    {
        public bool CancelIfRecordFails { get; set; } = false;

        public static EntityBatchOptionsRestModel Default { get; } =
            new EntityBatchOptionsRestModel
            {
                CancelIfRecordFails = false
            };
    }

    public class EntityBatchResponseRestModel
    {
        public int BatchId { get; set; }
        public string BatchStatus { get; set; }
    
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityBatchResultsResponseRestModel BatchResults { get; private set; }
    
    
        public void AddRecords(IEnumerable<EntityBatchRecordResponseRestModel> entityBatchRecords)
        {
            BatchResults ??= new EntityBatchResultsResponseRestModel();
            BatchResults.Records ??= new Dictionary<int, List<EntityBatchRecordResponseRestModel>>();
        	
            foreach (var entityBatchRecord in entityBatchRecords)
            {
                if (!BatchResults.Records.ContainsKey(entityBatchRecord.CharTypeId))
                {
                	BatchResults.Records.Add(entityBatchRecord.CharTypeId, new List<EntityBatchRecordResponseRestModel>());
                }
                
                BatchResults.Records[entityBatchRecord.CharTypeId].Add(entityBatchRecord);
            }
        }
        
        public void AddRelationships(IEnumerable<RelationshipBatchRecordResponseRestModel> relBatchRecords)
        {
            BatchResults ??= new EntityBatchResultsResponseRestModel();
            BatchResults.Relationships ??= new List<RelationshipBatchRecordResponseRestModel>();
            
            foreach (var relBatchRecord in relBatchRecords)
            {
                BatchResults.Relationships.Add(relBatchRecord);
            }
        }
    }

    public class EntityBatchResultsResponseRestModel
    {
        public Dictionary<int, List<EntityBatchRecordResponseRestModel>> Records { get; set; }
        public List<RelationshipBatchRecordResponseRestModel> Relationships { get; set; }
    }
}