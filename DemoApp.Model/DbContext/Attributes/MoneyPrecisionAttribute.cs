using Microsoft.EntityFrameworkCore;

namespace DemoApp.Model.DbContext.Attributes
{

    /// <summary>
    /// Prescition settings attribute
    /// </summary>
    public class MoneyPrecisionAttribute : PrecisionAttribute
    {
        public MoneyPrecisionAttribute() : base(18, 2)
        {
        }
    }
}
