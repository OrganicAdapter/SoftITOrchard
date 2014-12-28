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

namespace SoftIT.CRM.Migrations
{
    public class ProjectMigrations : DataMigrationImpl
    {
        public int Create()
        {
            //Creating table ProjectPartRecord
            SchemaBuilder.CreateTable(typeof(ProjectPartRecord).Name, table => table
                .ContentPartRecord()
                .Column("Price", DbType.Int32)
                .Column("Procurer", DbType.String)
                .Column("Deadline", DbType.String)
                .Column("Status", DbType.String)
            );

            //Creating ContentType for Project
            ContentDefinitionManager.AlterTypeDefinition(ContentTypes.Project, cfg => cfg
                .Creatable(true)
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart(typeof(ProjectPart).Name));

            return 1;
        }
    }
}