using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace TouristSpotCore.Lib.Http
{
    [JsonObject]
    public class ResponseBase
    {
        #region Constructors

        public ResponseBase()
        {
            ValidationMessages = new List<ModelState>();
        }

        #endregion

        #region Properties

        public int? Code { get; set; }

        public string Message { get; set; }

        public ICollection<ModelState> ValidationMessages { get; set; }

        public Exception Exception { get; set; }

        #endregion
    }
}