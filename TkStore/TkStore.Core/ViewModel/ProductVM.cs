using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TkStore.Core.Models;

namespace TkStore.Core.VIewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<productCategory> ProductCategories { get; set; }  
    }
}
