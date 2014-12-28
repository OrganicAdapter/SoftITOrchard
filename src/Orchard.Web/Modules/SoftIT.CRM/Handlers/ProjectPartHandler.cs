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
    public class ProjectPartHandler : ContentHandler
    {
        public ProjectPartHandler(IRepository<ProjectPartRecord> repository, Work<IContentManager> contentManagerWork)
        {
            Filters.Add(StorageFilter.For(repository));

            OnActivated<ProjectPart>((context, part) =>
                {
                    part.TasksField.Loader(() => contentManagerWork.Value.Query(ContentTypes.Task)
                        .List<TaskPart>()
                        .Where(taskPart => taskPart.ProjectRecord.Id.Equals(part.Id) && !taskPart.IsSubtask));
                });
        }
    }
}