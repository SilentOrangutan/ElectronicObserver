﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34014
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Browser.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Browser.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   // KCRDBと競合しないように同じように処理
        ///try {
        ///	var hideStyle = {width:&quot;0px&quot;,height:&quot;0px&quot;,visibility:&quot;hidden&quot;,display:&quot;none&quot;};
        ///	var fillStyle = {margin:&quot;0px&quot;,padding:&quot;0px&quot;,position:&quot;fixed&quot;,left:&quot;0px&quot;,top:&quot;0px&quot;,width:&quot;100%&quot;,height:&quot;100%&quot;,overflow:&quot;hidden&quot;};
        ///	var jqBody=document.body;
        ///	$(jqBody).css(&quot;zoom&quot;,&quot;normal&quot;);
        ///	$(jqBody).css({margin:&quot;0px&quot;,padding:&quot;0px&quot;,overflow:&quot;hidden&quot;});
        ///	$(&quot;#spacing_top&quot;).css(hideStyle);
        ///	$(&quot;#adFlashWrap&quot;).css(fillStyle);
        ///	$(&quot;#wsFlashWrap&quot;).css(fillStyle);
        ///	$(&quot;#flashWrap&quot;).css(fillStyle); [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string FrameScript {
            get {
                return ResourceManager.GetString("FrameScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   // KCRDBと競合しないように同じように処理
        ///try {
        ///	var hideStyle = {width:&quot;0px&quot;,height:&quot;0px&quot;,visibility:&quot;hidden&quot;,display:&quot;none&quot;};
        ///	var fillStyle = {margin:&quot;0px&quot;,padding:&quot;0px&quot;,position:&quot;fixed&quot;,left:&quot;0px&quot;,top:&quot;0px&quot;,width:&quot;100%&quot;,height:&quot;100%&quot;,overflow:&quot;hidden&quot;};
        ///	$(document.body).css({margin:&quot;0px&quot;,padding:&quot;0px&quot;,overflow:&quot;hidden&quot;});
        ///	$(&quot;img&quot;).css(hideStyle);
        ///	//$(&quot;#dmm_ntgnavi&quot;).css(hideStyle);
        ///	$(&quot;#dmm-ntgnavi-renew&quot;).css(hideStyle);
        ///	$(&quot;#w&quot;).css(fillStyle);
        ///	$(&quot;#main-ntg&quot;).css(fillStyle);
        ///	$(&quot;#page&quot;).css(fillStyle);
        /// [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string PageScript {
            get {
                return ResourceManager.GetString("PageScript", resourceCulture);
            }
        }
    }
}
