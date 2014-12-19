using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Utilities;
using SoftIT.CRM.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.Models
{
    public class TaskPart : ContentPart<TaskPartRecord>, ITitleAspect
    {
        private readonly LazyField<IEnumerable<TaskPart>> _childrenField = new LazyField<IEnumerable<TaskPart>>();
        public LazyField<IEnumerable<TaskPart>> ChildrenField { get { return _childrenField; } }
        public IEnumerable<TaskPart> Children { get { return _childrenField.Value; } }

        public string Title
        {
            get { return Record.Title; }
            set { Record.Title = value; }
        }

        public DateTime Deadline
        {
            get 
            {
                DateTime deadline;

                if (DateTime.TryParse(Record.Deadline, out deadline))
                    return deadline;
                else
                    return DateTime.Now;
            }
            set { Record.Deadline = value.ToString("yyyy-MM-dd HH:mm"); }
        }

        public TimeSpan EstimatedTime
        {
            get { return TimeSpan.FromSeconds(Record.EstimatedSeconds); }
            set { Record.EstimatedSeconds = (int)value.TotalSeconds; }
        }

        public TimeSpan ElapsedTime
        {
            get { return TimeSpan.FromSeconds(Record.ElapsedSeconds); }
            set { Record.ElapsedSeconds = (int)value.TotalSeconds; }
        }

        public TaskPartRecord ParentRecord
        {
            get { return Record.Parent; }
            set { Record.Parent = value; }
        }
    }

    public class TaskPartRecord : ContentPartRecord
    {
        public virtual string Title { get; set; }
        public virtual string Deadline { get; set; }
        public virtual int EstimatedSeconds { get; set; }
        public virtual int ElapsedSeconds { get; set; }
        public virtual TaskPartRecord Parent { get; set; }
    }
}