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

namespace SoftIT.CRM {
    public class Migrations : DataMigrationImpl {

        public int Create() {
			// Creating table TaskPartRecord
			SchemaBuilder.CreateTable(typeof(TaskPartRecord).Name, table => table
				.ContentPartRecord()
				.Column("Title", DbType.String)
				.Column("Deadline", DbType.String)
				.Column("EstimatedSeconds", DbType.Int32)
				.Column("ElapsedSeconds", DbType.Int32)
				.Column("Parent_Id", DbType.Int32)
			);

            //Creating ContentType for Task
            ContentDefinitionManager.AlterTypeDefinition(ContentTypes.Task, cfg => cfg
                .Creatable(true)
                .WithPart(typeof(TaskPart).Name)
                .WithPart("CommonPart"));

            return 1;
        }
    }
}