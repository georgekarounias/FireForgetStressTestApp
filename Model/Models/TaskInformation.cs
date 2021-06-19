using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Models
{
    public partial class TaskInformation
    {
        public int Id { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? Guid { get; set; }
        public string ServiceTaskName { get; set; }
        public decimal? TimeToComplete { get; set; }
        public bool? CompletionSuccess { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
