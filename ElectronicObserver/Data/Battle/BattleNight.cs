﻿using ElectronicObserver.Data.Battle.Phase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data.Battle {

	public abstract class BattleNight : BattleData {

		public PhaseNightBattle NightBattle { get; protected set; }

	}
}
