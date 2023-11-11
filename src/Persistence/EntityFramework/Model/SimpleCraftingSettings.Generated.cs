// <copyright file="SimpleCraftingSettings.Generated.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

//------------------------------------------------------------------------------
// <auto-generated>
//     This source code was auto-generated by a roslyn code generator.
// </auto-generated>
//------------------------------------------------------------------------------

// ReSharper disable All

namespace MUnique.OpenMU.Persistence.EntityFramework.Model;

using System.ComponentModel.DataAnnotations.Schema;
using MUnique.OpenMU.Persistence;

/// <summary>
/// The Entity Framework Core implementation of <see cref="MUnique.OpenMU.DataModel.Configuration.ItemCrafting.SimpleCraftingSettings"/>.
/// </summary>
[Table(nameof(SimpleCraftingSettings), Schema = SchemaNames.Configuration)]
internal partial class SimpleCraftingSettings : MUnique.OpenMU.DataModel.Configuration.ItemCrafting.SimpleCraftingSettings, IIdentifiable
{
    
    
    /// <summary>
    /// Gets or sets the identifier of this instance.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the raw collection of <see cref="RequiredItems" />.
    /// </summary>
    public ICollection<ItemCraftingRequiredItem> RawRequiredItems { get; } = new EntityFramework.List<ItemCraftingRequiredItem>();
    
    /// <inheritdoc/>
    [NotMapped]
    public override ICollection<MUnique.OpenMU.DataModel.Configuration.ItemCrafting.ItemCraftingRequiredItem> RequiredItems => base.RequiredItems ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Configuration.ItemCrafting.ItemCraftingRequiredItem, ItemCraftingRequiredItem>(this.RawRequiredItems);

    /// <summary>
    /// Gets the raw collection of <see cref="ResultItems" />.
    /// </summary>
    public ICollection<ItemCraftingResultItem> RawResultItems { get; } = new EntityFramework.List<ItemCraftingResultItem>();
    
    /// <inheritdoc/>
    [NotMapped]
    public override ICollection<MUnique.OpenMU.DataModel.Configuration.ItemCrafting.ItemCraftingResultItem> ResultItems => base.ResultItems ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Configuration.ItemCrafting.ItemCraftingResultItem, ItemCraftingResultItem>(this.RawResultItems);

    /// <inheritdoc />
    public override MUnique.OpenMU.DataModel.Configuration.ItemCrafting.SimpleCraftingSettings Clone(MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
    {
        var clone = new SimpleCraftingSettings();
        clone.AssignValuesOf(this, gameConfiguration);
        return clone;
    }
    
    /// <inheritdoc />
    public override void AssignValuesOf(MUnique.OpenMU.DataModel.Configuration.ItemCrafting.SimpleCraftingSettings other, MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
    {
        base.AssignValuesOf(other, gameConfiguration);
        this.Id = other.GetId();
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        var baseObject = obj as IIdentifiable;
        if (baseObject != null)
        {
            return baseObject.Id == this.Id;
        }

        return base.Equals(obj);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    
}
