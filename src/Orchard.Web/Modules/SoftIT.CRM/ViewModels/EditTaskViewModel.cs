using SoftIT.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.ViewModels
{
    public class EditTaskViewModel
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public string ParentTitle { get; set; }
        public IEnumerable<TaskPart> PossibleParents { get; set; }
    }
}