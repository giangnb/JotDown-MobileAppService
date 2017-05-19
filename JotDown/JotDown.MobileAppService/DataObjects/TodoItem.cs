using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JotDown.MobileAppService.DataObjects
{
    public class TodoItem
    {
        [JsonProperty( PropertyName = "name" )]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; } = false;
    }
}
