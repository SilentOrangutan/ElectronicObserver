﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data.Battle.Phase {

	public class PhaseSearching : PhaseBase {


		public PhaseSearching( BattleData data )
			: base( data ) { }


		public override bool IsAvailable {
			get { return RawData.api_search() && RawData.api_formation(); }
		}

		public override void EmulateBattle( int[] hps, int[] damages ) {
			throw new NotImplementedException();
		}


		/// <summary>
		/// 自軍索敵結果
		/// </summary>
		public int SearchingFriend { get { return (int)RawData.api_search[0]; } }

		/// <summary>
		/// 敵軍索敵結果
		/// </summary>
		public int SearchingEnemy { get { return (int)RawData.api_search[1]; } }

		/// <summary>
		/// 自軍陣形
		/// </summary>
		public int FormationFriend {
			get {
				dynamic form = RawData.api_formation[0];
				return form is string ? int.Parse( (string)form ) : (int)form;
			}
		}

		/// <summary>
		/// 敵軍陣形
		/// </summary>
		public int FormationEnemy { get { return (int)RawData.api_formation[1]; } }

		/// <summary>
		/// 交戦形態
		/// </summary>
		public int EngagementForm { get { return (int)RawData.api_formation[2]; } }

	}
}
