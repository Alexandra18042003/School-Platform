﻿#pragma checksum "..\..\..\Views\LoginOrCreateAccount.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F820E8CC1AC06E8BA25B137BA6739AA56542D315112F6B4752BC236A0C2890F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SchoolPlatform.Models.Converter;
using SchoolPlatform.ViewModels;
using SchoolPlatform.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SchoolPlatform.Views {
    
    
    /// <summary>
    /// LoginOrCreateAccount
    /// </summary>
    public partial class LoginOrCreateAccount : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserType;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContinueBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginBtn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ToHide;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserTypeLabel;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\LoginOrCreateAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Hidden;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SchoolPlatform;component/views/loginorcreateaccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\LoginOrCreateAccount.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 22 "..\..\..\Views\LoginOrCreateAccount.xaml"
            this.Password.PasswordChanged += new System.Windows.RoutedEventHandler(this.Password_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Views\LoginOrCreateAccount.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UserType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ContinueBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Views\LoginOrCreateAccount.xaml"
            this.ContinueBtn.Click += new System.Windows.RoutedEventHandler(this.ContinueBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LoginBtn = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Views\LoginOrCreateAccount.xaml"
            this.LoginBtn.Click += new System.Windows.RoutedEventHandler(this.ContinueBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ToHide = ((System.Windows.Controls.Label)(target));
            
            #line 48 "..\..\..\Views\LoginOrCreateAccount.xaml"
            this.ToHide.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ToHide_MouseLeftButtonDown_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UserTypeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Hidden = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

