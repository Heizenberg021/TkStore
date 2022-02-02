using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TkStore.Core.Models
{
    public class productCategory : BaseEntity
    {
        public string Category { get; set; }


        public productCategory Find(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
