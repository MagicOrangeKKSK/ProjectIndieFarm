using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{
    public class Config 
    {
        public static List<Item> Items = new List<Item>()
        {
            Hand,
            Shovel,
            Seed,
            WateringCan,
            SeedRadish,
            SeedChineseCabbage,
        };

        public static Item Hand = new Item()
        {
            IconName = "ToolHand_0",
            Count = 1,
            Countable = false,
            IsPlant = false,
            Name = "hand",
            PlantPrefabName = "",
            Tool = Constant.ToolHand
        };

        public static Item Shovel = new Item()
        {
            IconName = "ToolShovel_0",
            Count = 1,
            Countable = false,
            IsPlant = false,
            Name = "shovel",
            PlantPrefabName = "",
            Tool = Constant.ToolShovel
        };


        public static Item Seed = new Item()
        {
            IconName = "ToolSeed_0",
            Count = 1,
            Countable = true,
            IsPlant = true,
            Name = "seed",
            PlantPrefabName = "",
            Tool = Constant.ToolSeed
        };

        public static Item WateringCan = new Item()
        {
            IconName = "ToolWater_0",
            Count = 1,
            Countable = true,
            IsPlant = true,
            Name = "watering_can",
            PlantPrefabName = "Plant",
            Tool = Constant.ToolWateringCan
        };

        public static Item SeedRadish = new Item()
        {
            IconName = "ToolSeedRadish_0",
            Count = 1,
            Countable = true,
            IsPlant = true,
            Name = "seed_radish",
            PlantPrefabName = "",
            Tool = Constant.ToolSeedRadish
        };

        public static Item SeedChineseCabbage = new Item()
        {
            IconName = "ToolSeedChineseCabbage_0",
            Count = 1,
            Countable = true,
            IsPlant = true,
            Name = "seed_chinese_cabbage",
            PlantPrefabName = "",
            Tool = Constant.ToolChineseCabbage
        };

    }
}