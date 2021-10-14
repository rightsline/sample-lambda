using System;
using System.Collections.Generic;

namespace RightsLine.Contracts.RestApi.V4
{
    public class SchedulingRightsetListModel
    {
        public List<SchedulingRightset> SchedulingRightsets { get; set; } = new List<SchedulingRightset>();
    }

    public class SchedulingRightset
    {
        public string BoxsetDelayUnit { get; set; }
        public int? AllEpisodesAvailableUntil { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string BoxsetDurationUnit { get; set; }
        public string BoxsetRulesNotes { get; set; }
        public string BoxSetTriggeredByASubsequentSeason { get; set; }
        public int? BoxsetWindowLasts { get; set; }
        public int? BoxsetWindowStarts { get; set; }
        public string BoxsetWindowTriggered { get; set; }
        public string BoxsetAuthenticationNotes { get; set; }
        public string BoxsetFvodAvodAuthenticationRequired { get; set; }
        public string BundlingRequirementsBoxset { get; set; }

        public string BundlingRequirementsCatchup { get; set; }
        public string BundlingRequirementsStacking { get; set; }
        public string BundlingRequirementsStandalone { get; set; }

        public string ParentCatalogItemID { get; set; }

        public string CandidateRights { get; set; }
        public string CatalogItemID { get; set; }
        public string CatalogItemTitle { get; set; }
        public string CatchupRulesNotes { get; set; }
        public string CatchupWindowLasts { get; set; }
        public string CatchupLimitedToSpecificEpisodes { get; set; }
        public string CatchupWindowTriggered { get; set; }
        public string DateNotes { get; set; }
        public int DealID { get; set; }
        public string DeliveryPlatformNotes { get; set; }
        public string DeliveryPlatformNotesBoxsetRule { get; set; }
        public string DeliveryPlatformNotesStackingRule { get; set; }
        public string DeliveryPlatformStandalone { get; set; }
        public string DistributionChannel { get; set; }
        public string DurationUnit { get; set; }

        public string DealLastUpdatedBy { get; set; }
        public string ExcludedDays { get; set; }
        public string ExhibitionNotes { get; set; }
        public string EntityTemplate { get; set; }
        public string FridayExhibition72HourPeriod { get; set; }
        public string FridayExhibitionMondayPeriod { get; set; }
        public string FullLicensePeriodStandalone { get; set; }
        public string GpmsID { get; set; }
        public string Language { get; set; }

        public string LastUpdatedBy { get; set; }
        public string LengthOfExhibitionPeriod { get; set; }
        public string LicenseTermDatesAreEstimated { get; set; }
        public string LimitedToSpecificEpisodesStandalone { get; set; }
        public string ListSpecificEpisodesStandalone { get; set; }
        public string MaximumExploitationDays { get; set; }
        public int? MaximumNumberOfEpisodesAvailableAtOneTimeStandalone { get; set; }
        public int? MaximumNumberOfBoxsetEpisodesAvailableAtOneTime { get; set; }
        public int? MaximumNumberOfPrimetimeRuns { get; set; }
        public int? MaximumNumberOfEpisodesAvailableAtOneTime { get; set; }
        public string MediaBoxsetRules { get; set; }

        public string MediaRights { get; set; }
        public string MediaNLRule { get; set; }
        public string MediaStackingRule { get; set; }
        public string MediaStandalone { get; set; }

        public string NonLinearAuthenticationNotes { get; set; }
        public string NonLinearFvodAvodAuthenticationRequired { get; set; }
        public string NPVRServiceNotAuthorized { get; set; }
        public int? NumberOfExhibitionPeriods { get; set; }
        public int? NumberOfRunsPerExhibitionPeriod { get; set; }
        public string PermittedDeliveryPlatformsBoxset { get; set; }
        public string PermittedDeliveryPlatformsCatchup { get; set; }
        public string PermittedDeliveryPlatformsStacking { get; set; }
        public string PermittedDeliveryPlatformsStandalone { get; set; }
        public string PrimaryChannels { get; set; }
        public string PrimetimeDefinition { get; set; }
        public string RightsType { get; set; }
        public int? RuleNumber { get; set; }
        public string RunsPerChannel { get; set; }
        public string RunsPerYear { get; set; }
        public string RunsSharedAcrossTitles { get; set; }
        public string SelectedEpisodes { get; set; }
        public string ShortDescription { get; set; }
        public string StackingAuthenticationNotes { get; set; }
        public string StackingDurationUnit { get; set; }
        public string StackingEndTrigger { get; set; }
        public string StackingFvodAvodAuthenticationRequired { get; set; }
        public string StackingRulesNotes { get; set; }
        public string StackingWindowTriggered { get; set; }
        public string StandaloneAuthenticationNotes { get; set; }
        public DateTime? StandaloneEndDate { get; set; }
        public string StandaloneFvodAvodAuthenticationRequired { get; set; }
        public string StandaloneRulesNotes { get; set; }
        public DateTime? StandaloneStardDate { get; set; }
        public string StartOverNotAuthorized { get; set; }
        public string Territory { get; set; }
        public string TimeshiftingRights { get; set; }
        public string TriggeredByASubsequentSeasonCatchup { get; set; }
        public string UnlimitedRunsLinear { get; set; }
        public string UnlimitedRunsLinearPerExhibitionPeriod { get; set; }

        public string WhichTransmissionBoxsetRule { get; set; }
        public string WhichTransmissionCatchupRule { get; set; }
        public string WhichTransmissionStackingRule { get; set; }
        public string Xref { get; set; }
        public string RightsetIDs { get; set; }
    }
}