﻿using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftIT.CRM
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript("AngularJS").SetUrl("External/angular.js");
            manifest.DefineScript("Task.Editor").SetUrl("task-editor.js").SetDependencies("AngularJS");
        }
    }
}