using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using SoftIT.CRM.Models;
using SoftIT.CRM.Constants;

namespace SoftIT.CRM
{
    public class TaskMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table TaskPartRecord
            SchemaBuilder.CreateTable(typeof(TaskPartRecord).Name, table => table
                .ContentPartRecord()
                .Column("Deadline", DbType.String)
                .Column("EstimatedSeconds", DbType.Int32)
                .Column("ElapsedSeconds", DbType.Int32)
                .Column("IsSubtask", DbType.Boolean)
                .Column("Parent_Id", DbType.Int32)
                .Column("Project_Id", DbType.Int32)
            );

            //Creating ContentType for Task
            ContentDefinitionManager.AlterTypeDefinition(ContentTypes.Task, cfg => cfg
                .Creatable(true)
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart(typeof(TaskPart).Name));

            return 1;
        }
    }
}