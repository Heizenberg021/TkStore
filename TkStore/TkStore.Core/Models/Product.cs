using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TkStore.Core.Models
{
    public class Product : BaseEntity
    {

        [StringLength(30)]
        [DisplayName("ProductName")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,50000)]
        public string Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public object ID { get; set; }
    }
}
