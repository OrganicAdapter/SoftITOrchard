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

            var viewModel = new EditTaskViewModel
            {
                Deadline = part.Deadline,
                ElapsedTime = part.ElapsedTime,
                EstimatedTime = part.EstimatedTime,
                Title = part.Title,
                PossibleParents = possibleParents
            };

            if (part.ParentRecord != null)
                viewModel.ParentTitle = part.ParentRecord.Title;

            return viewModel;
        }

        public void UpdateTaskForContentItem(ContentItem contentItem, EditTaskViewModel viewModel)
        {
            var taskPart = contentItem.As<TaskPart>();
            taskPart.Deadline = viewModel.Deadline;
            taskPart.ElapsedTime = viewModel.ElapsedTime;
            taskPart.EstimatedTime = viewModel.EstimatedTime;
            taskPart.Title = viewModel.Title;

            if (viewModel.ParentTitle != null)
                taskPart.ParentRecord = _contentManager.Query(ContentTypes.Task)
                    .List<TaskPart>()
                    .FirstOrDefault(task => task.Title.Equals(viewModel.ParentTitle))
                    .Record;
        }
    }
}