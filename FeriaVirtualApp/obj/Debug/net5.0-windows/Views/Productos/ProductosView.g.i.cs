﻿#pragma checksum "..\..\..\..\..\Views\Productos\ProductosView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C77A5EA71B7F62C1C30871AF008369B07A816C2E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FeriaVirtualApp.Views.Productos {
    
    
    /// <summary>
    /// ProductosView
    /// </summary>
    public partial class ProductosView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 43 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TxtBuscar;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCrearProducto;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProductos;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FeriaVirtualApp;V1.0.0.0;component/views/productos/productosview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TxtBuscar = ((System.Windows.Controls.Label)(target));
            
            #line 44 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
            this.TxtBuscar.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
            this.txtSearch.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtSearch_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnCrearProducto = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
            this.BtnCrearProducto.Click += new System.Windows.RoutedEventHandler(this.BtnCrearProducto_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dgProductos = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 87 "..\..\..\..\..\Views\Productos\ProductosView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnActualizar_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

