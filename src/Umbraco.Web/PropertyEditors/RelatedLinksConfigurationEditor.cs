﻿using System.Collections.Generic;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Web.PropertyEditors
{
    /// <summary>
    /// Represents the configuration editor for the related links value editor.
    /// </summary>
    public class RelatedLinksConfigurationEditor : ConfigurationEditor
    {
        // fixme - this is weird?!
        public override IDictionary<string, object> DefaultConfiguration => new Dictionary<string, object>
        {
            {"idType", "udi"}
        };
    }
}