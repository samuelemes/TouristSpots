namespace TouristSpotCore.Lib.Http
{
    public interface IResourceResult<TData>
        where TData : class
    {
        #region Properties

        bool Success { get; set; }

        ResponseBase Response { get; set; }

        ResultMessageObject Messages { get; set; }

        TData Data { get; set; }

        #endregion
    }
}