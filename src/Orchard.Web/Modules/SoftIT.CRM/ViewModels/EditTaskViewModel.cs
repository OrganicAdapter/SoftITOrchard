using SoftIT.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.ViewModels
{
    public class EditTaskViewModel
    {
        public DateTime Deadline { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public string ParentId { get; set; }
        public string ProjectId { get; set; }
        public bool IsSubtask { get; set; }
        public IEnumerable<TaskPart> PossibleParents { get; set; }
        public IEnumerable<ProjectPart> Projects { get; set; }
    }
}