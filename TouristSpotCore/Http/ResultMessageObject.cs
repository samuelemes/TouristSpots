using System.Collections.Generic;

namespace TouristSpotCore.Lib.Http
{
    public class ResultMessageObject
    {
        #region Constructors

        public ResultMessageObject()
        {
            App = new List<ResultMessage>();
        }

        #endregion

        #region Properties

        public IEnumerable<ResultMessage> App { get; set; }

        #endregion
    }
}