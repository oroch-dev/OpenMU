﻿// <copyright file="AddKalimaPlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

using MUnique.OpenMU.DataModel.Configuration.Items;

namespace MUnique.OpenMU.Persistence.Initialization.Updates;

using System.Runtime.InteropServices;
using MUnique.OpenMU.DataModel.Configuration;
using MUnique.OpenMU.PlugIns;

/// <summary>
/// This adds the items required to enter the kalima map.
/// </summary>
[PlugIn(PlugInName, PlugInDescription)]
[Guid("0C99155F-1289-4E73-97F0-47CB67C3716F")]
public class AddKalimaPlugIn : UpdatePlugInBase
{
    /// <summary>
    /// The plug in name.
    /// </summary>
    internal const string PlugInName = "Add Kalima";

    /// <summary>
    /// The plug in description.
    /// </summary>
    internal const string PlugInDescription = "This adds the items required to enter the kalima map.";

    /// <inheritdoc />
    public override UpdateVersion Version => UpdateVersion.AddKalima;

    /// <inheritdoc />
    public override string DataInitializationKey => VersionSeasonSix.DataInitialization.Id;

    /// <inheritdoc />
    public override string Name => PlugInName;

    /// <inheritdoc />
    public override string Description => PlugInDescription;

    /// <inheritdoc />
    public override bool IsMandatory => true;

    /// <inheritdoc />
    public override DateTime CreatedAt => new(2024, 06, 09, 18, 0, 0, DateTimeKind.Utc);

    /// <inheritdoc />
#pragma warning disable CS1998
    protected override async ValueTask ApplyAsync(IContext context, GameConfiguration gameConfiguration)
#pragma warning restore CS1998
    {
        this.CreateLostMap(context, gameConfiguration);
        this.CreateSymbolOfKundun(context, gameConfiguration);
    }

    private void CreateLostMap(IContext context, GameConfiguration gameConfiguration)
    {
        var itemDefinition = context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Lost Map";
        itemDefinition.Number = 28;
        itemDefinition.Group = 14;
        itemDefinition.DropsFromMonsters = false;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.MaximumItemLevel = 7;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        gameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateSymbolOfKundun(IContext context, GameConfiguration gameConfiguration)
    {
        var itemDefinition = context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Symbol of Kundun";
        itemDefinition.Number = 29;
        itemDefinition.Group = 14;
        itemDefinition.DropLevel = 0;
        itemDefinition.DropsFromMonsters = true;
        itemDefinition.Durability = 5;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.MaximumItemLevel = 7;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        gameConfiguration.Items.Add(itemDefinition);
    }
}