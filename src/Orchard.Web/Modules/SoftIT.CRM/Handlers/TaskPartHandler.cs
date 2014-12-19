using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment;
using SoftIT.CRM.Constants;
using SoftIT.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.Handlers
{
    public class TaskPartHandler : ContentHandler
    {
        public TaskPartHandler(IRepository<TaskPartRecord> repository, Work<IContentManager> contentManagerWork)
        {
            Filters.Add(StorageFilter.For(repository));

            OnActivated<TaskPart>((context, part) =>
                {
                    part.ChildrenField.Loader(() => contentManagerWork.Value.Query(ContentTypes.Task)
                        .List<TaskPart>()
                        .Where(taskPart => taskPart.ParentRecord.Id.Equals(part.Id)));
                });
        }
    }
}