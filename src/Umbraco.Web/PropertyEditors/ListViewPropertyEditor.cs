﻿using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Web.PropertyEditors
{
    /// <summary>
    /// Represents a list-view editor.
    /// </summary>
    [ValueEditor(Constants.PropertyEditors.Aliases.ListView, "List view", "listview", HideLabel = true, Group = "lists", Icon = "icon-item-arrangement")]
    public class ListViewPropertyEditor : PropertyEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewPropertyEditor"/> class.
        /// </summary>
        /// <param name="logger"></param>
        public ListViewPropertyEditor(ILogger logger)
            : base(logger)
        { }

        /// <inheritdoc />
        protected override ConfigurationEditor CreateConfigurationEditor() => new ListViewConfigurationEditor();
    }
}
