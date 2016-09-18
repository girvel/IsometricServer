﻿using System;
using Isometric.CommonStructures;

namespace Isometric.Core.Modules.PlayerModule.Leaders
{
    [Serializable]
    public class LeaderPattern
    {
        public delegate void BonusResourcesTickAction(Leader leader, ref Resources resources);

        public Action<Leader> Tick { get; set; }
        public BonusResourcesTickAction BonusTick { get; set; }

        public LeaderPattern() {}

        public LeaderPattern(Action<Leader> tick)
        {
            Tick = tick;
        }

        public void CheckVersion()
        {

        }
    }
}
