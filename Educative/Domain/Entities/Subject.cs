using Educative.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educative.Domain.Entities
{
    public class Subject : Auditable
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
