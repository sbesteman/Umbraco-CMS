﻿using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Install.InstallSteps;
using Umbraco.Cms.Core.Install.Models;
using Umbraco.Cms.Infrastructure.Install.InstallSteps;

namespace Umbraco.Cms.Infrastructure.Install
{
    public sealed class InstallStepCollection
    {
        private readonly InstallHelper _installHelper;
        private readonly IEnumerable<InstallSetupStep> _orderedInstallerSteps;

        public InstallStepCollection(InstallHelper installHelper, IEnumerable<InstallSetupStep> installerSteps)
        {
            _installHelper = installHelper;

            // TODO: this is ugly but I have a branch where it's nicely refactored - for now we just want to manage ordering
            var a = installerSteps.ToArray();
            _orderedInstallerSteps = new InstallSetupStep[]
            {
                a.OfType<NewInstallStep>().First(),
                a.OfType<UpgradeStep>().First(),
                a.OfType<FilePermissionsStep>().First(),
                a.OfType<TelemetryIdentifierStep>().First(),
                a.OfType<DatabaseConfigureStep>().First(),
                a.OfType<DatabaseInstallStep>().First(),
                a.OfType<DatabaseUpgradeStep>().First(),

                // TODO: Add these back once we have a compatible Starter kit
                // a.OfType<StarterKitDownloadStep>().First(),
                // a.OfType<StarterKitInstallStep>().First(),
                // a.OfType<StarterKitCleanupStep>().First(),

                a.OfType<CompleteInstallStep>().First(),
            };
        }


        /// <summary>
        /// Get the installer steps
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The step order returned here is how they will appear on the front-end if they have views assigned
        /// </remarks>
        public IEnumerable<InstallSetupStep> GetAllSteps()
        {
            return _orderedInstallerSteps;
        }

        /// <summary>
        /// Returns the steps that are used only for the current installation type
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InstallSetupStep> GetStepsForCurrentInstallType()
        {
            return GetAllSteps().Where(x => x.InstallTypeTarget.HasFlag(_installHelper.GetInstallationType()));
        }
    }
}
