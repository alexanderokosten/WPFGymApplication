﻿#pragma checksum "..\..\..\View\UpdateTrainerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "686F1372DBC834C44098BE21B195F227E3D8488CF372B9295E4000D188500A1B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GymApp.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace GymApp.View {
    
    
    /// <summary>
    /// UpdateTrainerWindow
    /// </summary>
    public partial class UpdateTrainerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PatronymicTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BirthdayTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CoachingExperienceTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PalicularQualitiesTextBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\UpdateTrainerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditStudentsButton;
        
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
            System.Uri resourceLocater = new System.Uri("/GymApp;component/view/updatetrainerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\UpdateTrainerWindow.xaml"
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
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.NameTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NameTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SurnameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.SurnameTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SurnameTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PatronymicTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.PatronymicTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PatronymicTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BirthdayTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.BirthdayTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.BirthdayTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CoachingExperienceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.CoachingExperienceTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CoachingExperienceTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PalicularQualitiesTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.PalicularQualitiesTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PalicularQualitiesTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EditStudentsButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\View\UpdateTrainerWindow.xaml"
            this.EditStudentsButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 56 "..\..\..\View\UpdateTrainerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
