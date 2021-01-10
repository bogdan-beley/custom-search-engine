using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Models
{
    public class GoogleCustomSearchRootObject
    {
        public int Id { get; set; }
        public GoogleCustomSearchItem[] Items { get; set; }
    }
}
