using System.Collections.Generic;
using QFramework;

namespace ProjectindieFarm
{
    public class Config
    {

        public static Item Hand = new Item()
        {
            IconName = "ToolHand_0",
            Count = new BindableProperty<int>(1),
            Countable = false,
            IsPlant = false,
            Name = "hand",
            PlantPrefabName = "",
        }.Self(item => item.Tool = new ToolHand()
        {
            Item = item
        });

        public static Item Shovel = new Item()
        {
            IconName = "ToolShovel_0",
            Count = new BindableProperty<int>(1),
            Countable = false,
            IsPlant = false,
            Name = "shovel",
            PlantPrefabName = "",
        }.Self(item =>
        {
            item.Tool = new ToolShovel()
            {
                Item = item
            };
        });


        public static Item Seed = new Item()
        {
            IconName = "ToolSeed_0",
            Count = new BindableProperty<int>(6),
            Countable = true,
            IsPlant = true,
            Name = "seed",
            PlantPrefabName = "Plant",
        }.Self(item => item.Tool = new ToolSeed()
        {
            Item = item
        });

        public static Item WateringCan = new Item()
        {
            IconName = "ToolWater_0",
            Count = new BindableProperty<int>(1),
            Countable = false,
            IsPlant = false,
            Name = "watering_can",
            PlantPrefabName = "Plant",
        }.Self(item => item.Tool = new ToolWateringCan()
        {
            Item = item
        });

        public static Item SeedRadish = new Item()
        {
            IconName = "ToolSeedRadish_0",
            Count = new BindableProperty<int>(6),
            Countable = true,
            IsPlant = true,
            Name = "seed_radish",
            PlantPrefabName = "PlantRadish",
            //Tool = new ToolSeedRadish()// Constant.ToolSeedRadish
        }.Self(item => item.Tool = new ToolSeed()
        {
            Item = item
        });

        public static Item SeedChineseCabbage = new Item()
        {
            IconName = "ToolSeedChineseCabbage_0",
            Count = new BindableProperty<int>(6),
            Countable = true,
            IsPlant = true,
            Name = "seed_chinese_cabbage",
            PlantPrefabName = "PlantChineseCabbage",
            //Tool =  new ToolSeedChineseCabbage()// Constant.ToolChineseCabbage
        }.Self(item => item.Tool = new ToolSeed() 
        {
            Item = item
        });


        public static List<Item> Items = new List<Item>()
        {
            Hand,
            Shovel,
            Seed,
            WateringCan,
            SeedRadish,
            SeedChineseCabbage,
        };

    }
}