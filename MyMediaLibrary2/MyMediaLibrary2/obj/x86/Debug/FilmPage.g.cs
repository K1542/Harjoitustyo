﻿#pragma checksum "C:\Users\Jani\Source\Repos\TTOS0200\MyMediaLibrary2\MyMediaLibrary2\FilmPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "21EB9D3497BEB74207A43BAE008099C0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMediaLibrary2
{
    partial class FilmPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.FilmAddPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 12 "..\..\..\FilmPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.FilmAddPage).Click += this.FilmAddPage_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.FilmViewPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 13 "..\..\..\FilmPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.FilmViewPage).Click += this.FilmViewPage_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\FilmPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

