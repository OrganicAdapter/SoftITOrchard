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
    public class ProjectPartDriver : ContentPartDriver<ProjectPart>
    {
        protected override string Prefix
        {
            get
            {
                return ContentTypes.Task;
            }
        }

        protected override DriverResult Display(ProjectPart part, string displayType, dynamic shapeHelper)
        {
            return null;
        }

        protected override DriverResult Editor(ProjectPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Project_Edit", () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Project",
                    Model: part,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(ProjectPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part, shapeHelper);
        }
    }
}