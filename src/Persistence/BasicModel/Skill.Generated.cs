// <copyright file="Skill.Generated.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

//------------------------------------------------------------------------------
// <auto-generated>
//     This source code was auto-generated by a roslyn code generator.
// </auto-generated>
//------------------------------------------------------------------------------

// ReSharper disable All

namespace MUnique.OpenMU.Persistence.BasicModel;

using MUnique.OpenMU.Persistence.Json;

/// <summary>
/// A plain implementation of <see cref="Skill"/>.
/// </summary>
public partial class Skill : MUnique.OpenMU.DataModel.Configuration.Skill, IIdentifiable, IConvertibleTo<Skill>
{
    
    /// <summary>
    /// Gets or sets the identifier of this instance.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the raw collection of <see cref="Requirements" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("requirements")]
    public ICollection<AttributeRequirement> RawRequirements { get; } = new List<AttributeRequirement>();
    
    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override ICollection<MUnique.OpenMU.DataModel.Configuration.Items.AttributeRequirement> Requirements
    {
        get => base.Requirements ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Configuration.Items.AttributeRequirement, AttributeRequirement>(this.RawRequirements);
        protected set
        {
            this.Requirements.Clear();
            foreach (var item in value)
            {
                this.Requirements.Add(item);
            }
        }
    }

    /// <summary>
    /// Gets the raw collection of <see cref="ConsumeRequirements" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("consumeRequirements")]
    public ICollection<AttributeRequirement> RawConsumeRequirements { get; } = new List<AttributeRequirement>();
    
    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override ICollection<MUnique.OpenMU.DataModel.Configuration.Items.AttributeRequirement> ConsumeRequirements
    {
        get => base.ConsumeRequirements ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Configuration.Items.AttributeRequirement, AttributeRequirement>(this.RawConsumeRequirements);
        protected set
        {
            this.ConsumeRequirements.Clear();
            foreach (var item in value)
            {
                this.ConsumeRequirements.Add(item);
            }
        }
    }

    /// <summary>
    /// Gets the raw collection of <see cref="QualifiedCharacters" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("qualifiedCharacters")]
    public ICollection<CharacterClass> RawQualifiedCharacters { get; } = new List<CharacterClass>();
    
    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override ICollection<MUnique.OpenMU.DataModel.Configuration.CharacterClass> QualifiedCharacters
    {
        get => base.QualifiedCharacters ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Configuration.CharacterClass, CharacterClass>(this.RawQualifiedCharacters);
        protected set
        {
            this.QualifiedCharacters.Clear();
            foreach (var item in value)
            {
                this.QualifiedCharacters.Add(item);
            }
        }
    }

    /// <summary>
    /// Gets the raw object of <see cref="ElementalModifierTarget" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("elementalModifierTarget")]
    public AttributeDefinition RawElementalModifierTarget
    {
        get => base.ElementalModifierTarget as AttributeDefinition;
        set => base.ElementalModifierTarget = value;
    }

    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override MUnique.OpenMU.AttributeSystem.AttributeDefinition ElementalModifierTarget
    {
        get => base.ElementalModifierTarget;
        set => base.ElementalModifierTarget = value;
    }

    /// <summary>
    /// Gets the raw object of <see cref="MagicEffectDef" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("magicEffectDef")]
    public MagicEffectDefinition RawMagicEffectDef
    {
        get => base.MagicEffectDef as MagicEffectDefinition;
        set => base.MagicEffectDef = value;
    }

    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override MUnique.OpenMU.DataModel.Configuration.MagicEffectDefinition MagicEffectDef
    {
        get => base.MagicEffectDef;
        set => base.MagicEffectDef = value;
    }

    /// <summary>
    /// Gets the raw object of <see cref="MasterDefinition" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("masterDefinition")]
    public MasterSkillDefinition RawMasterDefinition
    {
        get => base.MasterDefinition as MasterSkillDefinition;
        set => base.MasterDefinition = value;
    }

    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override MUnique.OpenMU.DataModel.Configuration.MasterSkillDefinition MasterDefinition
    {
        get => base.MasterDefinition;
        set => base.MasterDefinition = value;
    }

    /// <inheritdoc />
    public override MUnique.OpenMU.DataModel.Configuration.Skill Clone(MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
    {
        var clone = new Skill();
        clone.AssignValuesOf(this, gameConfiguration);
        return clone;
    }
    
    /// <inheritdoc />
    public override void AssignValuesOf(MUnique.OpenMU.DataModel.Configuration.Skill other, MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
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

    /// <inheritdoc/>
    public Skill Convert() => this;
}
