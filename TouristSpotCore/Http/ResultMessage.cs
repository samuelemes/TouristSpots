using System.Runtime.Serialization;

namespace TouristSpotCore.Lib.Http
{
    [DataContract]
    public class ResultMessage
    {
        #region Properties

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        #endregion
    }
}