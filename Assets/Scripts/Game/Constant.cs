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
                return "��";
            }
            else if (tool == ToolShovel.Name)
            {
                return "����";
            }
            else if (tool == ToolWateringCan.Name)
            {
                return "ˮ��";
            }
            else if (tool == ToolSeedRadish.Name)
            {
                return "�ܲ�";
            }
            else if (tool == ToolSeed.Name)
            {
                return "����";
            }
            return "";
        }
    }
}