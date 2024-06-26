﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from RecipeTemplate.tt/>

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Core.Controller;
    using Eco.Gameplay.Settlements.ClaimStakes;
    using Eco.Gameplay.Items.Recipes;


    /// <summary>
    /// <para>Server side recipe definition for "HydroWheat".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class HydroWheatRecipe : RecipeFamily
    {
        public HydroWheatRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Hydro Wheat",  //noloc
                displayName: Localizer.DoStr("Hydro Wheat"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(WheatSeedItem), 4, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
					
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WheatItem>(10),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(FarmingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(HydroWheatRecipe), start: 10f, skillType: typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "HydroWheat"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Hydro Wheat"), recipeType: typeof(HydroWheatRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(HydrotableObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
