using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace JotDown.MobileAppService.DataObjects
{
    public class Item : EntityData
    {
        public string Account { get; set; }

        public string Name { get; set; }

        //[JsonIgnore]
        //[NotMapped]
        //public List<TodoItem> Todo
        //{
        //    get { return !IsNote?JsonConvert.DeserializeObject<List<TodoItem>>(Note):null; }
        //    set
        //    {
        //        Note = JsonConvert.SerializeObject(value);
        //        IsNote = false;
        //    }
        //}

        public string Note { get; set; } = "";

        public string Tag { get; set; }

        public bool Complete { get; set; }

        public bool IsNote { get; set; } = true;
    }
}
