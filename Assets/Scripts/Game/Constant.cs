using ProjectindieFarm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class Constant
    {


        public static readonly ITool ToolHand = new ToolHand();
        public static readonly ITool ToolSeed = new ToolSeed();
        public static readonly ITool ToolWateringCan = new ToolWateringCan();
        public static readonly ITool ToolSeedRadish = new ToolSeedRadish();
        public static readonly ITool ToolShovel = new ToolShovel();

        public static string DisplayName(string tool)
        {
            if (tool == ToolHand.Name)
            {
                return "手";
            }
            else if (tool == ToolShovel.Name)
            {
                return "铁锹";
            }
            else if (tool == ToolWateringCan.Name)
            {
                return "水壶";
            }
            else if (tool == ToolSeedRadish.Name)
            {
                return "萝卜";
            }
            else if (tool == ToolSeed.Name)
            {
                return "种子";
            }
            return "";
        }
    }
}