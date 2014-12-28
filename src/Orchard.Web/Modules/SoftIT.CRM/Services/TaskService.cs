using Orchard;
using Orchard.ContentManagement;
using SoftIT.CRM.Constants;
using SoftIT.CRM.Models;
using SoftIT.CRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.Services
{
    public interface ITaskService : IDependency
    {
        EditTaskViewModel BuildEditorViewModel(TaskPart part);
        void UpdateTaskForContentItem(ContentItem contentItem, EditTaskViewModel viewModel);
    }

    public class TaskService : ITaskService
    {
        private readonly IContentManager _contentManager;


        public TaskService(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }


        public EditTaskViewModel BuildEditorViewModel(TaskPart part)
        {
            var possibleParents = _contentManager.Query(ContentTypes.Task)
                .List<TaskPart>()
                .Where(taskPart => !taskPart.Id.Equals(part.Id))
                .ToList();

            var projects = _contentManager.Query(ContentTypes.Project)
                .List<ProjectPart>();

            var viewModel = new EditTaskViewModel
            {
                Deadline = part.Deadline,
                ElapsedTime = part.ElapsedTime,
                EstimatedTime = part.EstimatedTime,
                IsSubtask = part.IsSubtask,
                PossibleParents = possibleParents,
                Projects = projects
            };

            if (part.ParentRecord != null)
                viewModel.ParentId = part.ParentRecord.Id.ToString();

            if (part.ProjectRecord != null)
                viewModel.ProjectId = part.ProjectRecord.Id.ToString();

            return viewModel;
        }

        public void UpdateTaskForContentItem(ContentItem contentItem, EditTaskViewModel viewModel)
        {
            var taskPart = contentItem.As<TaskPart>();
            taskPart.Deadline = viewModel.Deadline;
            taskPart.ElapsedTime = viewModel.ElapsedTime;
            taskPart.EstimatedTime = viewModel.EstimatedTime;
            taskPart.IsSubtask = viewModel.IsSubtask;

            if (viewModel.ProjectId != "" && !viewModel.IsSubtask)
                taskPart.ProjectRecord = _contentManager.Query(ContentTypes.Project)
                    .List<ProjectPart>()
                    .FirstOrDefault(project => project.Id.ToString().Equals(viewModel.ProjectId))
                    .Record;

            if (viewModel.ParentId != "" && viewModel.IsSubtask)
                taskPart.ParentRecord = _contentManager.Query(ContentTypes.Task)
                    .List<TaskPart>()
                    .FirstOrDefault(task => task.Id.ToString().Equals(viewModel.ParentId))
                    .Record;
        }
    }
}