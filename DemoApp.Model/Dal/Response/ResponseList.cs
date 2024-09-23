using DemoApp.Model.Dal.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Model.Dal.Response
{
    /// <summary>
    /// Response list
    /// </summary>
    internal class ResponseList<TListItem> : ResponseBase
    {
        /// <summary>
        /// Items
        /// </summary>
        public required ICollection<TListItem> Items { get; set; }
    }
}
