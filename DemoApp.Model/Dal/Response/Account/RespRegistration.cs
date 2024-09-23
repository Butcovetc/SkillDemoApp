using DemoApp.Model.Dal.Response.Base;

namespace DemoApp.Model.Dal.Response.Account
{
    /// <summary>
    /// Regisration result
    /// </summary>
    public class RespRegistration:ResponseBase
    {
        /// <summary>
        /// registered account id
        /// </summary>
        public int Id { get; set; }
    }
}
