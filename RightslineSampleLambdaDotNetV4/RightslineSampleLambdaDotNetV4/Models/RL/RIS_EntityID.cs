using RightsLine.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace RightsLine.Contracts.Data.Entities
{
    [DataContract]
    [Serializable]
    [TypeConverter(typeof(RIS_EntityIDTypeConverter))]
    public class RIS_EntityID
    {
        [DataMember]
        public int DivID { get; set; }
        [DataMember]
        public int CharTypeID { get; set; }
        [DataMember]
        public int RecID { get; set; }



        public RIS_EntityID()
        {
            this.DivID = 0;
            this.CharTypeID = 0;
            this.RecID = 0;
        }
        public RIS_EntityID(int divID, int charTypeID, int RecID)
        {
            this.DivID = divID;
            this.CharTypeID = charTypeID;
            this.RecID = RecID;
        }

        #region Static
        static RIS_EntityID()
        {
            _parserRegex = new Regex(@"d(\d+)c(\d+)r(\-?\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private static Regex _parserRegex;

        public static RIS_EntityID Parse(string input)
        {
            var match = _parserRegex.Match(input);
            if (match.Success && match.Groups.Count == 4)
            {
                int divID = 0;
                int charTypeID = 0;
                int recID = 0;

                if (int.TryParse(match.Groups[1].Value, out divID)
                    && int.TryParse(match.Groups[2].Value, out charTypeID)
                    && int.TryParse(match.Groups[3].Value, out recID))
                {
                    return new RIS_EntityID(divID, charTypeID, recID);
                }
            }
            return RIS_EntityID.Empty;
        }

        public override string ToString()
        {
            return string.Format("d{0}c{1}r{2}", this.DivID, this.CharTypeID, this.RecID);
        }

        public static bool operator ==(RIS_EntityID a, RIS_EntityID b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(RIS_EntityID a, RIS_EntityID b)
        {
            return !(a == b);
        }

        public static RIS_EntityID Empty
        {
            get
            {
                return new RIS_EntityID(0, 0, 0);
            }
        }


        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            if (obj is RIS_EntityID)
            {
                return this.Equals(obj as RIS_EntityID);
            }
            return false;
        }

        public bool Equals(RIS_EntityID other)
        {
            if (object.ReferenceEquals(this, other))
                return true;
            if (other == null)
                return false;

            return other.DivID == this.DivID
                && other.CharTypeID == this.CharTypeID
                && other.RecID == this.RecID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + this.DivID.GetHashCode();
                hash = hash * 23 + this.CharTypeID.GetHashCode();
                hash = hash * 23 + this.RecID.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}
