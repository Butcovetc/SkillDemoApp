namespace DemoApp.Model.Exceptions.Api
{
    /// <summary>
    /// Argument missing exception
    /// </summary>
    public class ArgumetMissingException: BaseApiException
    {

        public void TrowIfNull(Object obj, String message) =>
            if (obj==null)
                throw new ArgumetMissingException(message)
        
    }
}
