﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectindieFarm
{
    public class SoilData
    {
        public bool HasPlant { get; set; } = false;
        public bool Watered { get; set; } = false;

        public PlantStates PlantStates { get; set; } = PlantStates.Seed;

    }
}
