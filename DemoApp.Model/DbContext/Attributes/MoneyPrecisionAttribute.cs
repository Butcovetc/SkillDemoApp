using Microsoft.EntityFrameworkCore;

namespace DemoApp.Model.DbContext.Attributes
{

    /// <summary>
    /// Prescition settings attribute
    /// </summary>
    internal class MoneyPrecisionAttribute : PrecisionAttribute
    {
        public MoneyPrecisionAttribute() : base(18, 2)
        {
        }
    }
}
