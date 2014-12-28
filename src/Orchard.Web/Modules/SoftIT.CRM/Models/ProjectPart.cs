using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.Models
{
    public class ProjectPart : ContentPart<ProjectPartRecord>
    {
        private readonly LazyField<IEnumerable<TaskPart>> _tasksField = new LazyField<IEnumerable<TaskPart>>();
        public LazyField<IEnumerable<TaskPart>> TasksField { get { return _tasksField; } }
        public IEnumerable<TaskPart> Tasks { get { return _tasksField.Value; } }

        [Required]
        public int Price
        {
            get { return Record.Price; }
            set { Record.Price = value; }
        }

        public string Procurer
        {
            get { return Record.Procurer; }
            set { Record.Procurer = value; }
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

        public string Status
        {
            get { return Record.Status; }
            set { Record.Status = value; }
        }
    }

    public class ProjectPartRecord : ContentPartRecord
    {
        public virtual int Price { get; set; }
        public virtual string Procurer { get; set; }
        public virtual string Deadline { get; set; }
        public virtual string Status { get; set; }
    }
}