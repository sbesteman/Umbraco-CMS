﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Umbraco.Core.Models;

namespace Umbraco.Web.Models.ContentEditing
{
    public abstract class TabbedContentItem<T, TPersisted> : ContentItemBasic<T, TPersisted>
        where T : ContentPropertyBasic
        where TPersisted : IContentBase
    {
        protected TabbedContentItem()
        {
            Tabs = new List<Tab<T>>();
        }

        /// <summary>
        /// Defines the tabs containing display properties
        /// </summary>
        [DataMember(Name = "tabs")]
        public IEnumerable<Tab<T>> Tabs { get; set; }

        // note
        // once a [DataContract] has been defined on a class, with a [DataMember] property,
        // one simply cannot ignore that property anymore - [IgnoreDataMember] on an overriden
        // property is ignored, and 'newing' the property means that it's the base property
        // which is used
        //
        // OTOH, Json.NET is happy having [JsonIgnore] on overrides, even though the base
        // property is [JsonProperty]. so, forcing [JsonIgnore] here, but really, we should
        // rething the whole thing.

        /// <summary>
        /// Override the properties property to ensure we don't serialize this
        /// and to simply return the properties based on the properties in the tabs collection
        /// </summary>
        /// <remarks>
        /// This property cannot be set
        /// </remarks>
        [IgnoreDataMember]
        [JsonIgnore] // fixme - see note on IgnoreDataMember vs JsonIgnore
        public override IEnumerable<T> Properties
        {
            get => Tabs.SelectMany(x => x.Properties);
            set => throw new NotImplementedException();
        }
    }
}
