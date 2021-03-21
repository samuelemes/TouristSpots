using System;
using System.Runtime.Serialization;

namespace TouristSpotCore.Lib.Http
{
    [DataContract]
    public class ResultBase<TData> : IResourceResult<TData>
        where TData : class
    {
        #region Properties

        [DataMember(Name = "exception")]
        public virtual Exception Exception { get; set; }

        #endregion

        [DataMember(Name = "success")]
        public virtual bool Success { get; set; }

        [DataMember(Name = "response")]
        public virtual ResponseBase Response { get; set; }

        [DataMember(Name = "data")]
        public virtual TData Data { get; set; }

        [DataMember(Name = "messages")]
        public virtual ResultMessageObject Messages { get; set; }
    }
}