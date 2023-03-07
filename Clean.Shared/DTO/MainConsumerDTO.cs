using Clean.Shared.Main;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Shared.DTO
{
    public class MainConsumerDTO : MainConsumer
    {
        private MainConsumer? data;
        public Operation Operation { get; set; }
        public string? JsonData { get; set; }
        public string? TypeName { get; set; }
        [JsonIgnore]
        public MainConsumer? Data
        {
            get
            {
                if (data is not null) return data;
                if (string.IsNullOrWhiteSpace(JsonData)) return null;
                Type myType = Type.GetType(TypeName);
                return (MainConsumer?)JsonConvert.DeserializeObject(JsonData ?? "{}", myType);
            }
            set
            {
                data = value;
                JsonData = JsonConvert.SerializeObject(data ?? new object());
                TypeName = data?.GetType().FullName;
            }
        }
    }
    public enum Operation
    {
        Add, Edit, Delete, List
    }
}
