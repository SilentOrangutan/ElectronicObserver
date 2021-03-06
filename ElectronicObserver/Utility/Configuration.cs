﻿using Codeplex.Data;
using ElectronicObserver.Observer;
using ElectronicObserver.Utility.Storage;
using ElectronicObserver.Window.Dialog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicObserver.Utility {


	public sealed class Configuration {


		private static readonly Configuration instance = new Configuration();

		public static Configuration Instance {
			get { return instance; }
		}


		private const string SaveFileName = @"Settings\Configuration.xml";


		public delegate void ConfigurationChangedEventHandler();
		public event ConfigurationChangedEventHandler ConfigurationChanged = delegate { };


		[DataContract( Name = "Configuration" )]
		public class ConfigurationData : DataStorage {

			public class ConfigPartBase {
				//reserved
			}


			/// <summary>
			/// 通信の設定を扱います。
			/// </summary>
			public class ConfigConnection : ConfigPartBase {

				/// <summary>
				/// ポート番号
				/// </summary>
				public ushort Port { get; set; }

				/// <summary>
				/// 通信内容を保存するか
				/// </summary>
				public bool SaveReceivedData { get; set; }

				/// <summary>
				/// 通信内容保存：フィルタ
				/// </summary>
				public string SaveDataFilter { get; set; }

				/// <summary>
				/// 通信内容保存：保存先
				/// </summary>
				public string SaveDataPath { get; set; }

				/// <summary>
				/// 通信内容保存：Requestを保存するか
				/// </summary>
				public bool SaveRequest { get; set; }

				/// <summary>
				/// 通信内容保存：Responseを保存するか
				/// </summary>
				public bool SaveResponse { get; set; }

				/// <summary>
				/// 通信内容保存：SWFを保存するか
				/// </summary>
				public bool SaveSWF { get; set; }

				/// <summary>
				/// 通信内容保存：その他ファイルを保存するか
				/// </summary>
				public bool SaveOtherFile { get; set; }

				/// <summary>
				/// 通信内容保存：バージョンを追加するか
				/// </summary>
				public bool ApplyVersion { get; set; }

				/// <summary>
				/// システムプロキシに登録するか
				/// </summary>
				public bool RegisterAsSystemProxy { get; set; }

				/// <summary>
				/// 上流プロキシを利用するか
				/// </summary>
				public bool UseUpstreamProxy { get; set; }

				/// <summary>
				/// 是否在ssl链接上启用上游代理
				/// </summary>
				public bool EnableSslUpstreamProxy { get; set; }

				/// <summary>
				/// 上流プロキシのアドレス
				/// </summary>
				public string UpstreamProxyAddress { get; set; }

				/// <summary>
				/// 上流プロキシのポート番号
				/// </summary>
				public ushort UpstreamProxyPort { get; set; }

				/// <summary>
				/// kancolle-db.netに送信する
				/// </summary>
				public bool SendDataToKancolleDB { get; set; }

				/// <summary>
				/// kancolle-db.netのOAuth認証
				/// </summary>
				public string SendKancolleOAuth { get; set; }

				/// <summary>
				/// APIがに送信されます
				/// 21 apis which take 21 bits.
				/// </summary>
				public uint SendKancolleDBApis { get; set; }

				public ConfigConnection() {

					Port = 40620;
					SaveReceivedData = false;
					SaveDataFilter = "";
					SaveDataPath = @"KCAPI";
					SaveRequest = false;
					SaveResponse = true;
					SaveSWF = false;
					SaveOtherFile = false;
					ApplyVersion = false;
					RegisterAsSystemProxy = false;
					EnableSslUpstreamProxy = true;
					UseUpstreamProxy = false;
					UpstreamProxyAddress = @"127.0.0.1";
					UpstreamProxyPort = 0;

					SendDataToKancolleDB = false;
					SendKancolleOAuth = "";
					SendKancolleDBApis = 0x1FFFFF;
				}

			}
			/// <summary>通信</summary>
			[DataMember]
			public ConfigConnection Connection { get; private set; }


			public class ConfigUI : ConfigPartBase {
				/// <summary>
				/// メインフォント
				/// </summary>
				public SerializableFont MainFont { get; set; }

				/// <summary>
				/// サブフォント
				/// </summary>
				public SerializableFont SubFont { get; set; }

				#region - UI Colors -

				public int ThemeID { get; set; }
				public SerializableColor BackColor { get; set; }
				public SerializableColor ForeColor { get; set; }
				public SerializableColor SubForeColor { get; set; }
				public SerializableColor HighlightForeColor { get; set; }
				public SerializableColor HighlightColor { get; set; }
				public SerializableColor LineColor { get; set; }
				public SerializableColor ButtonBackColor { get; set; }
				public SerializableColor FailedColor { get; set; }
				public SerializableColor EliteColor { get; set; }
				public SerializableColor FlagshipColor { get; set; }
				public SerializableColor LateModelColor { get; set; }
				public SerializableColor Hp0Color { get; set; }
				public SerializableColor Hp25Color { get; set; }
				public SerializableColor Hp50Color { get; set; }
				public SerializableColor Hp75Color { get; set; }
				public SerializableColor Hp100Color { get; set; }
				public SerializableColor HpIncrementColor { get; set; }
				public SerializableColor HpDecrementColor { get; set; }
				public SerializableColor HpBackgroundColor { get; set; }

				#endregion

				#region - Fleet Color -

				public SerializableColor FleetReadyColor { get; set; }
				public SerializableColor FleetExpeditionColor { get; set; }
				public SerializableColor FleetSortieColor { get; set; }
				public SerializableColor FleetNotReadyColor { get; set; }
				public SerializableColor FleetDamageColor { get; set; }

				#endregion

				#region - Quest Color -

				public SerializableColor QuestOrganization { get; set; }
				public SerializableColor QuestSortie { get; set; }
				public SerializableColor QuestExercise { get; set; }
				public SerializableColor QuestExpedition { get; set; }
				public SerializableColor QuestSupplyDocking { get; set; }
				public SerializableColor QuestArsenal { get; set; }
				public SerializableColor QuestRenovated { get; set; }
				public SerializableColor QuestForeColor { get; set; }

				#endregion

				public bool NotExpeditionBlink { get; set; }

				public int HpBackgroundOffset { get; set; }

				public int HpThickness { get; set; }

				public ConfigUI() {
					//*/
					MainFont = new Font( "Meiryo UI", 12, FontStyle.Regular, GraphicsUnit.Pixel );
					SubFont = new Font( "Meiryo UI", 10, FontStyle.Regular, GraphicsUnit.Pixel );
					//*/
					ThemeID = 0;
					BackColor = new SerializableColor( Color.FromArgb( 255, 245, 245, 245 ) );
					ForeColor = new SerializableColor( SystemColors.ControlText );
					SubForeColor = new SerializableColor( Color.FromArgb( 0x88, 0x88, 0x88 ) );
					HighlightColor = new SerializableColor( Color.FromArgb( 255, 0xFF, 0xFF, 0xCC ) );
					HighlightForeColor = new SerializableColor( SystemColors.ControlText );
					LineColor = new SerializableColor( SystemColors.ControlDark );
					ButtonBackColor = new SerializableColor( SystemColors.Control );
					FailedColor = new SerializableColor( Color.Red );
					EliteColor = new SerializableColor( Color.FromArgb( 0xFF, 0x00, 0x00 ) );
					FlagshipColor = new SerializableColor( Color.FromArgb( 0xFF, 0x88, 0x00 ) );
					LateModelColor = new SerializableColor( Color.FromArgb( 0x00, 0x88, 0xFF ) );

					NotExpeditionBlink = true;

					Hp0Color = Color.FromArgb( 0xFF, 0, 0 );
					Hp25Color = Color.FromArgb( 0xFF, 0x88, 0 );
					Hp50Color = Color.FromArgb( 0xFF, 0xCC, 0 );
					Hp75Color = Color.FromArgb( 0, 0xCC, 0 );
					Hp100Color = Color.FromArgb( 0, 0x44, 0xCC );
					HpIncrementColor = Color.FromArgb( 0x44, 0xFF, 0 );
					HpDecrementColor = Color.FromArgb( 0x88, 0x22, 0x22 );
					HpBackgroundColor = Color.FromArgb( 0x88, 0x88, 0x88 );

					HpBackgroundOffset = 1;
					HpThickness = 4;

					FleetReadyColor = Color.FromArgb( 0x8A, 0xE0, 0x9D );
					FleetExpeditionColor = Color.FromArgb( 0x62, 0xC0, 0xFF );
					FleetSortieColor = Color.FromArgb( 0xE8, 0x49, 0x40 );
					FleetNotReadyColor = Color.FromArgb( 0xFD, 0xDF, 0x51 );

					FleetDamageColor = Color.FromArgb( 0xF0, 0x80, 0x80 );

					QuestOrganization = Color.FromArgb( 0xAA, 0xFF, 0xAA );
					QuestSortie = Color.FromArgb( 0xFF, 0xCC, 0xCC );
					QuestExercise = Color.FromArgb( 0xDD, 0xFF, 0xAA );
					QuestExpedition = Color.FromArgb( 0xCC, 0xFF, 0xFF );
					QuestSupplyDocking = Color.FromArgb( 0xFF, 0xFF, 0xCC );
					QuestArsenal = Color.FromArgb( 0xDD, 0xCC, 0xBB );
					QuestRenovated = Color.FromArgb( 0xDD, 0xCC, 0xFF );
					QuestForeColor = SystemColors.ControlText;

				}
			}
			/// <summary>UI</summary>
			[DataMember]
			public ConfigUI UI { get; private set; }


			/// <summary>
			/// ログの設定を扱います。
			/// </summary>
			public class ConfigLog : ConfigPartBase {

				/// <summary>
				/// ログのレベル
				/// </summary>
				public int LogLevel { get; set; }

				/// <summary>
				/// ログを保存するか
				/// </summary>
				public bool SaveLogFlag { get; set; }

				/// <summary>
				/// エラーレポートを保存するか
				/// </summary>
				public bool SaveErrorReport { get; set; }

				/// <summary>
				/// get or set if show mainD2's link.
				/// </summary>
				public bool ShowMainD2Link { get; set; }

				/// <summary>
				/// get or set if show cache log
				/// </summary>
				public bool ShowCacheLog { get; set; }

				/// <summary>
				/// get or set if output the ship graphic list
				/// </summary>
				public bool OutputGraphicList { get; set; }

				/// <summary>
				/// ファイル エンコーディングのID
				/// </summary>
				public int FileEncodingID { get; set; }

				/// <summary>
				/// ファイル エンコーディング
				/// </summary>
				[IgnoreDataMember]
				public Encoding FileEncoding {
					get {
						switch ( FileEncodingID ) {
							case 0:
								return new System.Text.UTF8Encoding( false );
							case 1:
								return new System.Text.UTF8Encoding( true );
							case 2:
								return new System.Text.UnicodeEncoding( false, false );
							case 3:
								return new System.Text.UnicodeEncoding( false, true );
							case 4:
								return Encoding.GetEncoding( 932 );
							default:
								return new System.Text.UTF8Encoding( false );

						}
					}
				}

				/// <summary>
				/// ネタバレを許可するか
				/// </summary>
				public bool ShowSpoiler { get; set; }

				public ConfigLog() {
					LogLevel = 2;
					SaveLogFlag = true;
					SaveErrorReport = true;
					FileEncodingID = 0;
					ShowMainD2Link = false;
					ShowCacheLog = true;
					OutputGraphicList = false;
					ShowSpoiler = true;
				}

			}
			/// <summary>ログ</summary>
			[DataMember]
			public ConfigLog Log { get; private set; }


			/// <summary>
			/// 動作の設定を扱います。
			/// </summary>
			public class ConfigControl : ConfigPartBase {

				/// <summary>
				/// 疲労度ボーダー
				/// </summary>
				public int ConditionBorder { get; set; }

				public ConfigControl() {
					ConditionBorder = 40;
				}
			}
			/// <summary>動作</summary>
			[DataMember]
			public ConfigControl Control { get; private set; }


			/// <summary>
			/// デバッグの設定を扱います。
			/// </summary>
			public class ConfigDebug : ConfigPartBase {

				/// <summary>
				/// デバッグメニューを有効にするか
				/// </summary>
				public bool EnableDebugMenu { get; set; }

				/// <summary>
				/// 起動時にAPIリストをロードするか
				/// </summary>
				public bool LoadAPIListOnLoad { get; set; }

				/// <summary>
				/// APIリストのパス
				/// </summary>
				public string APIListPath { get; set; }


				public ConfigDebug() {
					EnableDebugMenu = false;
					LoadAPIListOnLoad = false;
					APIListPath = "";
				}
			}
			/// <summary>デバッグ</summary>
			[DataMember]
			public ConfigDebug Debug { get; private set; }


			/// <summary>
			/// 起動と終了の設定を扱います。
			/// </summary>
			public class ConfigLife : ConfigPartBase {

				/// <summary>
				/// 終了時に確認するか
				/// </summary>
				public bool ConfirmOnClosing { get; set; }

				/// <summary>
				/// 最前面に表示するか
				/// </summary>
				public bool TopMost { get; set; }

				/// <summary>
				/// レイアウトファイルのパス
				/// </summary>
				public string LayoutFilePath { get; set; }

				/// <summary>
				/// 更新情報を取得するか
				/// </summary>
				public bool CheckUpdateInformation { get; set; }

				/// <summary>
				/// 是否锁定布局
				/// </summary>
				public bool IsLocked { get; set; }

				/// <summary>
				/// ステータスバーを表示するか
				/// </summary>
				public bool ShowStatusBar { get; set; }

				public ConfigLife() {
					ConfirmOnClosing = true;
					TopMost = false;
					LayoutFilePath = @"Settings\WindowLayout.zip";
					CheckUpdateInformation = true;
					IsLocked = false;
					ShowStatusBar = true;
				}
			}
			/// <summary>起動と終了</summary>
			[DataMember]
			public ConfigLife Life { get; private set; }


			/// <summary>
			/// [工廠]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigFormArsenal : ConfigPartBase {

				/// <summary>
				/// 艦名を表示するか
				/// </summary>
				public bool ShowShipName { get; set; }

				public ConfigFormArsenal() {
					ShowShipName = true;
				}
			}
			/// <summary>[工廠]ウィンドウ</summary>
			[DataMember]
			public ConfigFormArsenal FormArsenal { get; private set; }


			/// <summary>
			/// [司令部]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigFormHeadquarters : ConfigPartBase {

				public ConfigFormHeadquarters() {
				}
			}
			/// <summary>[司令部]ウィンドウ</summary>
			[DataMember]
			public ConfigFormHeadquarters FormHeadquarters { get; private set; }


			/// <summary>
			/// [艦隊]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigFormFleet : ConfigPartBase {

				/// <summary>
				/// 艦載機を表示するか
				/// </summary>
				public bool ShowAircraft { get; set; }

				/// <summary>
				/// 索敵式の計算方法
				/// </summary>
				public int SearchingAbilityMethod { get; set; }

				/// <summary>
				/// スクロール可能か
				/// </summary>
				public bool IsScrollable { get; set; }

				/// <summary>
				/// 艦名表示の幅を固定するか
				/// </summary>
				public bool FixShipNameWidth { get; set; }

				/// <summary>
				/// HPバーを短縮するか
				/// </summary>
				public bool ShortenHPBar { get; set; }

				/// <summary>
				/// next lv. を表示するか
				/// </summary>
				public bool ShowNextExp { get; set; }

				public ConfigFormFleet() {
					ShowAircraft = true;
					SearchingAbilityMethod = 0;
					IsScrollable = true;
					FixShipNameWidth = false;
					ShortenHPBar = false;
					ShowNextExp = true;
				}
			}
			/// <summary>[艦隊]ウィンドウ</summary>
			[DataMember]
			public ConfigFormFleet FormFleet { get; private set; }


			/// <summary>
			/// [任務]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigFormQuest : ConfigPartBase {

				/// <summary>
				/// 遂行中の任務のみ表示するか
				/// </summary>
				public bool ShowRunningOnly { get; set; }


				/// <summary>
				/// 一回限り(+その他)を表示
				/// </summary>
				public bool ShowOnce { get; set; }

				/// <summary>
				/// デイリーを表示
				/// </summary>
				public bool ShowDaily { get; set; }

				/// <summary>
				/// ウィークリーを表示
				/// </summary>
				public bool ShowWeekly { get; set; }

				/// <summary>
				/// マンスリーを表示
				/// </summary>
				public bool ShowMonthly { get; set; }

				/// <summary>
				/// 列の可視性
				/// </summary>
				public SerializableList<bool> ColumnFilter { get; set; }


				public ConfigFormQuest() {
					ShowRunningOnly = false;
					ShowOnce = true;
					ShowDaily = true;
					ShowWeekly = true;
					ShowMonthly = true;
					ColumnFilter = null;		//実際の初期化は FormQuest で行う
				}
			}
			/// <summary>[任務]ウィンドウ</summary>
			[DataMember]
			public ConfigFormQuest FormQuest { get; private set; }


			/// <summary>
			/// [艦船グループ]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigFormShipGroup : ConfigPartBase {

				public int SplitterDistance { get; set; }

				public bool AutoUpdate { get; set; }

				public bool ShowStatusBar { get; set; }

				public ConfigFormShipGroup() {
					SplitterDistance = 40;
					AutoUpdate = true;
					ShowStatusBar = true;
				}
			}
			/// <summary>[艦船グループ]ウィンドウ</summary>
			[DataMember]
			public ConfigFormShipGroup FormShipGroup { get; private set; }


			/// <summary>
			/// [ブラウザ]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigFormBrowser : ConfigPartBase {

				/// <summary>
				/// ブラウザの拡大率 10-1000(%)
				/// </summary>
				public int ZoomRate { get; set; }

				/// <summary>
				/// ブラウザをウィンドウサイズに合わせる
				/// </summary>
				[DataMember]
				public bool ZoomFit { get; set; }

				/// <summary>
				/// ログインページのURL
				/// </summary>
				public string LogInPageURL { get; set; }

				/// <summary>
				/// ブラウザを有効にするか
				/// </summary>
				public bool IsEnabled { get; set; }

				/// <summary>
				/// スクリーンショットの保存先フォルダ
				/// </summary>
				public string ScreenShotPath { get; set; }

				/// <summary>
				/// スクリーンショットのフォーマット
				/// 1=jpeg, 2=png
				/// </summary>
				public int ScreenShotFormat { get; set; }

				/// <summary>
				/// 適用するスタイルシート
				/// </summary>
				public string StyleSheet { get; set; }

				/// <summary>
				/// スクロール可能かどうか
				/// </summary>
				public bool IsScrollable { get; set; }

				/// <summary>
				/// スタイルシートを適用するか
				/// </summary>
				public bool AppliesStyleSheet { get; set; }

				/// <summary>
				/// ツールメニューの配置
				/// </summary>
				public DockStyle ToolMenuDockStyle { get; set; }

				/// <summary>
				/// ツールメニューの可視性
				/// </summary>
				public bool IsToolMenuVisible { get; set; }

				/// <summary>
				/// 再読み込み時に確認ダイアログを入れるか
				/// </summary>
				public bool ConfirmAtRefresh { get; set; }

				/// <summary>
				/// 直连swf时替换的embed元素
				/// </summary>
				public string EmbedHtml { get; set; }

				/// <summary>
				/// 是否显示URL地址
				/// </summary>
				public bool ShowURL { get; set; }

				/// <summary>
				/// flashのパラメータ指定 'wmode'
				/// </summary>
				public string FlashWmode { get; set; }

				/// <summary>
				/// flashのパラメータ指定 'quality'
				/// </summary>
				public string FlashQuality { get; set; }


				public ConfigFormBrowser() {
					ZoomRate = 100;
					ZoomFit = false;
					LogInPageURL = @"http://www.dmm.com/netgame_s/kancolle/";
					IsEnabled = true;
					ScreenShotPath = "ScreenShot";
					ScreenShotFormat = 2;
					StyleSheet = "\r\nbody {\r\n	margin:0;\r\n	overflow:hidden\r\n}\r\n\r\n#game_frame {\r\n	position:fixed;\r\n	left:50%;\r\n	top:-16px;\r\n	margin-left:-450px;\r\n	z-index:1\r\n}\r\n";
					IsScrollable = false;
					AppliesStyleSheet = true;
					ToolMenuDockStyle = DockStyle.Top;
					IsToolMenuVisible = true;
					ConfirmAtRefresh = true;
					EmbedHtml = "<embed width=\"800\" height=\"480\" wmode=\"{1}\" quality=\"{2}\" bgcolor=\"#000\" allowScriptAccess=\"always\" type=\"application/x-shockwave-flash\" src=\"{0}\">";
					ShowURL = true;
					FlashWmode = "direct";
					FlashQuality = "high";
				}
			}
			/// <summary>[ブラウザ]ウィンドウ</summary>
			[DataMember]
			public ConfigFormBrowser FormBrowser { get; private set; }



			/// <summary>
			/// 各[通知]ウィンドウの設定を扱います。
			/// </summary>
			public class ConfigNotifierBase : ConfigPartBase {

				public bool IsEnabled { get; set; }

				public bool ShowsDialog { get; set; }

				public string ImagePath { get; set; }

				public bool DrawsImage { get; set; }

				public string SoundPath { get; set; }

				public bool PlaysSound { get; set; }

				public bool DrawsMessage { get; set; }

				public int ClosingInterval { get; set; }

				public int AccelInterval { get; set; }

				public bool CloseOnMouseMove { get; set; }

				public Notifier.NotifierDialogClickFlags ClickFlag { get; set; }

				public Notifier.NotifierDialogAlignment Alignment { get; set; }

				public Point Location { get; set; }

				public bool HasFormBorder { get; set; }

				public bool TopMost { get; set; }

				public bool ShowWithActivation { get; set; }

				public SerializableColor ForeColor { get; set; }

				public SerializableColor BackColor { get; set; }


				public ConfigNotifierBase() {
					IsEnabled = true;
					ShowsDialog = true;
					ImagePath = "";
					DrawsImage = false;
					SoundPath = "";
					PlaysSound = false;
					DrawsMessage = true;
					ClosingInterval = 10000;
					AccelInterval = 0;
					CloseOnMouseMove = false;
					ClickFlag = Notifier.NotifierDialogClickFlags.Left;
					Alignment = Notifier.NotifierDialogAlignment.BottomRight;
					Location = new Point( 0, 0 );
					HasFormBorder = true;
					TopMost = true;
					ShowWithActivation = true;
					ForeColor = SystemColors.ControlText;
					BackColor = SystemColors.Control;
				}

			}


			/// <summary>
			/// [大破進撃通知]の設定を扱います。
			/// </summary>
			public class ConfigNotifierDamage : ConfigNotifierBase {

				public bool NotifiesBefore { get; set; }
				public bool NotifiesNow { get; set; }
				public bool NotifiesAfter { get; set; }
				public int LevelBorder { get; set; }
				public bool ContainsNotLockedShip { get; set; }
				public bool ContainsSafeShip { get; set; }
				public bool ContainsFlagship { get; set; }
				public bool NotifiesAtEndpoint { get; set; }
				public ConfigNotifierDamage()
					: base() {
					NotifiesBefore = false;
					NotifiesNow = true;
					NotifiesAfter = true;
					LevelBorder = 1;
					ContainsNotLockedShip = true;
					ContainsSafeShip = true;
					ContainsFlagship = true;
					NotifiesAtEndpoint = false;
				}
			}


			/// <summary>[遠征帰投通知]</summary>
			[DataMember]
			public ConfigNotifierBase NotifierExpedition { get; private set; }

			/// <summary>[建造完了通知]</summary>
			[DataMember]
			public ConfigNotifierBase NotifierConstruction { get; private set; }

			/// <summary>[入渠完了通知]</summary>
			[DataMember]
			public ConfigNotifierBase NotifierRepair { get; private set; }

			/// <summary>[疲労回復通知]</summary>
			[DataMember]
			public ConfigNotifierBase NotifierCondition { get; private set; }

			/// <summary>[大破進撃通知]</summary>
			[DataMember]
			public ConfigNotifierDamage NotifierDamage { get; private set; }



			public class ConfigWhitecap : ConfigPartBase {

				public bool ShowInTaskbar { get; set; }
				public bool TopMost { get; set; }
				public int BoardWidth { get; set; }
				public int BoardHeight { get; set; }
				public int ZoomRate { get; set; }
				public int UpdateInterval { get; set; }
				public int ColorTheme { get; set; }
				public int BirthRule { get; set; }
				public int AliveRule { get; set; }

				public ConfigWhitecap()
					: base() {
					ShowInTaskbar = true;
					TopMost = false;
					BoardWidth = 200;
					BoardHeight = 150;
					ZoomRate = 2;
					UpdateInterval = 100;
					ColorTheme = 0;
					BirthRule = ( 1 << 3 );
					AliveRule = ( 1 << 2 ) | ( 1 << 3 );
				}
			}
			[DataMember]
			public ConfigWhitecap Whitecap { get; private set; }


			public class ConfigCacheSettings : ConfigPartBase {
				public string CacheFolder { get; set; }
				public bool CacheEnabled { get; set; }
				public bool HackEnabled { get; set; }
				public bool HackTitleEnabled { get; set; }
				public int CacheEntryFiles { get; set; }
				public int CachePortFiles { get; set; }
				public int CacheSceneFiles { get; set; }
				public int CacheResourceFiles { get; set; }
				public int CacheSoundFiles { get; set; }
				public int CheckFiles { get; set; }
				public bool SaveApiStart2 { get; set; }
				public bool UseCacheJs { get; set; }

				public ConfigCacheSettings()
					: base() {
					CacheFolder = "MyCache";
					CacheEnabled = true;
					HackEnabled = true;
					HackTitleEnabled = true;
					CacheEntryFiles = 2;
					CachePortFiles = 2;
					CacheSceneFiles = 2;
					CacheResourceFiles = 2;
					CacheSoundFiles = 2;
					CheckFiles = 1;
					SaveApiStart2 = true;
					UseCacheJs = false;
				}
			}

            [DataMember]
            public ConfigCacheSettings CacheSettings { get; private set; }


			public class ConfigFormBattle : ConfigPartBase {
				public bool IsShortDamage { get; set; }

				public ConfigFormBattle()
					: base() {
					IsShortDamage = false;
				}
			}

			[DataMember]
			public ConfigFormBattle FormBattle { get; private set; }


			[DataMember]
			public string Version {
				get { return SoftwareInformation.VersionEnglish; }
				set { }	//readonly
			}


			public override void Initialize() {

				Connection = new ConfigConnection();
				UI = new ConfigUI();
				Log = new ConfigLog();
				Control = new ConfigControl();
				Debug = new ConfigDebug();
				Life = new ConfigLife();

				FormArsenal = new ConfigFormArsenal();
				FormFleet = new ConfigFormFleet();
				FormHeadquarters = new ConfigFormHeadquarters();
				FormQuest = new ConfigFormQuest();
				FormShipGroup = new ConfigFormShipGroup();
				FormBrowser = new ConfigFormBrowser();

				NotifierExpedition = new ConfigNotifierBase();
				NotifierConstruction = new ConfigNotifierBase();
				NotifierRepair = new ConfigNotifierBase();
				NotifierCondition = new ConfigNotifierBase();
				NotifierDamage = new ConfigNotifierDamage();

				Whitecap = new ConfigWhitecap();

                CacheSettings = new ConfigCacheSettings();
				FormBattle = new ConfigFormBattle();

			}
		}
		private static ConfigurationData _config;

		public static ConfigurationData Config {
			get { return _config; }
		}



		private Configuration()
			: base() {

			_config = new ConfigurationData();
		}


		internal void OnConfigurationChanged() {
			ConfigurationChanged();
		}


		public void Load() {
			var temp = (ConfigurationData)_config.Load( SaveFileName );
			if ( temp != null ) {
				_config = temp;
                if ( temp.CacheSettings.CacheEnabled ) {
                    Utility.Logger.Add( 2, string.Format( "CacheCore: 缓存设置载入。“{0}”", temp.CacheSettings.CacheFolder ) );
                }
			} else {
				MessageBox.Show( SoftwareInformation.SoftwareNameJapanese + " をご利用いただきありがとうございます。\r\n設定や使用方法については「ヘルプ」→「オンラインヘルプ」を参照してください。\r\nご使用の前に必ずご一読ください。",
					"初回起動メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
		}

		public void Save() {
			_config.Save( SaveFileName );
		}
	}


}
