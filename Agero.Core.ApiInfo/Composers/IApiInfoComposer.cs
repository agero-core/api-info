namespace Agero.Core.ApiInfo
{
    /// <summary>Sync API information composer</summary>
    public interface IApiInfoComposer
    {
        /// <summary>Returns API information</summary>
        ApiInformation Get();
    }
}