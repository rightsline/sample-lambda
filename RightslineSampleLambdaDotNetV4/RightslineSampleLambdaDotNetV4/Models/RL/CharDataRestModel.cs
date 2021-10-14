namespace RightsLine.Contracts.RestApi.Common
{
    public abstract class CharDataRestModel
    {
        public CharDataRestModel()
        {

        }
        public CharDataRestModel(string value)
        {
            // string value is most common case
            this.Value = value;
        }
        public int? Id { get; set; }

        public string Value { get; set; }

        public string Xref { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.Value) && string.IsNullOrEmpty(this.Xref) && !Id.HasValue;
        }
    }
}
