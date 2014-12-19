using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using SoftIT.CRM.Constants;
using SoftIT.CRM.Models;
using SoftIT.CRM.Services;
using SoftIT.CRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM.Drivers
{
    public class TaskPartDriver : ContentPartDriver<TaskPart>
    {
        private readonly ITaskService _taskService;

        protected override string Prefix
        {
            get
            {
                return ContentTypes.Task;
            }
        }


        public TaskPartDriver(ITaskService taskService)
        {
            _taskService = taskService;
        }


        protected override DriverResult Display(TaskPart part, string displayType, dynamic shapeHelper)
        {
            return null;
        }

        protected override DriverResult Editor(TaskPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Task_Edit", () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Task",
                    Model: _taskService.BuildEditorViewModel(part),
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(TaskPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            var viewModel = new EditTaskViewModel();
            updater.TryUpdateModel(viewModel, Prefix, null, null);

            if (part.ContentItem.Id != 0)
                _taskService.UpdateTaskForContentItem(part.ContentItem, viewModel);

            return Editor(part, shapeHelper);
        }
    }
}