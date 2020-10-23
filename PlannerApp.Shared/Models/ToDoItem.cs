using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PlannerAppClient.Models
{
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public DateTime? AchievedDate { get; set; }
        public string PlanId { get; set; }
    }
}

