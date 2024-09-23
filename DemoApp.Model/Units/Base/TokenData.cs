namespace DemoApp.Model.Units.Base
{
    /// <summary>
    /// Used to pack and unpack token data
    /// </summary>
    internal class TokenData
    {
        public Int32? Id { get; set; }
        public Guid? SessionKeyUniq { get; set; }
        public String? Email { get; internal set; }
    }
}
