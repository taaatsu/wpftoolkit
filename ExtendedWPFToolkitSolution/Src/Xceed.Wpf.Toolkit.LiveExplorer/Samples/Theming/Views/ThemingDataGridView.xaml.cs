﻿/*************************************************************************************
   
   Toolkit for WPF

   Copyright (C) 2007-2024 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

/***************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2024 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md  

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  *************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.Toolkit.LiveExplorer.Samples.Theming.Helpers;
using Xceed.Wpf.Toolkit.LiveExplorer.Core;

namespace Xceed.Wpf.Toolkit.LiveExplorer.Samples.Theming.Views
{
  public partial class ThemingDataGridView : DemoView
  {

    #region Constructors

    public ThemingDataGridView()
    {
      this.InitializeAvailableThemes();
      this.Initialized += new EventHandler( OnInitialized );
      DataContext = this;
      InitializeComponent();
    }

    #endregion

    #region AvailableThemes Property

    internal List<ThemeChoiceViewModel> AvailableThemes
    {
      get { return ( List<ThemeChoiceViewModel> )GetValue( AvailableThemesProperty ); }
      set { SetValue( AvailableThemesProperty, value ); }
    }

    internal static readonly DependencyProperty AvailableThemesProperty =
        DependencyProperty.Register(
          "AvailableThemes",
          typeof( List<ThemeChoiceViewModel> ),
          typeof( ThemingDataGridView ),
          new PropertyMetadata( null ) );

    #endregion

    #region SelectedTheme Property

    internal ThemeChoiceViewModel SelectedTheme
    {
      get { return ( ThemeChoiceViewModel )GetValue( SelectedThemeProperty ); }
      set { SetValue( SelectedThemeProperty, value ); }
    }

    internal static readonly DependencyProperty SelectedThemeProperty =
        DependencyProperty.Register(
          "SelectedTheme",
          typeof( ThemeChoiceViewModel ),
          typeof( ThemingDataGridView ),
          new PropertyMetadata( null, OnSelectedThemePropertyChanged ) );

    private static void OnSelectedThemePropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      var self = ( ThemingDataGridView )d;

      var oldTheme = e.OldValue as ThemeChoiceViewModel;
      if( oldTheme != null )
      {
        oldTheme.IsSelected = false;
      }

      self._previewAdditionalText.Text = String.Empty;

      var newTheme = e.NewValue as ThemeChoiceViewModel;
      if( newTheme != null )
      {
        newTheme.IsSelected = true;
        ThemingSharedProperties.NotifyThemeChoiceSelected( newTheme );
      }
    }

    #endregion

    #region Methods (Private)

    private void OnInitialized( object sender, EventArgs e )
    {
      this.SelectedTheme = ThemingSharedProperties.GetLastThemeChoiceOrDefault( this.AvailableThemes );
    }

    private void InitializeAvailableThemes()
    {
      var themes = new List<ThemeChoiceViewModel> {
        new ThemeChoiceViewModel { DisplayName = "Material Design",
                          BaseName = ThemeBaseNames.Material,
                          ActionOnSelected = OnMaterialThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Office 2007 Blue",
                          BaseName = ThemeBaseNames.Office2007,
                          ActionOnSelected = OnOffice2007BlueThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Office 2007 Black",
                          BaseName = ThemeBaseNames.Office2007,
                          ActionOnSelected = OnOffice2007BlackThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Office 2007 Silver",
                          BaseName = ThemeBaseNames.Office2007,
                          ActionOnSelected = OnOffice2007SilverThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Windows 10",
                          BaseName = ThemeBaseNames.Windows10,
                          ActionOnSelected = OnWindows10ThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Metro Dark",
                          BaseName = ThemeBaseNames.MetroAccent,
                          ActionOnSelected = OnMetroThemeSelected,
                          IsDark = true,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Metro Light",
                          BaseName = ThemeBaseNames.MetroAccent,
                          ActionOnSelected = OnMetroThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Fluent Design Dark",
                          BaseName = ThemeBaseNames.Fluent,
                          IsDark = true,
                          ActionOnSelected = OnFluentThemeSelected,
                          IsPlus = true },
        new ThemeChoiceViewModel { DisplayName = "Fluent Design Light",
                          BaseName = ThemeBaseNames.Fluent,
                          ActionOnSelected = OnFluentThemeSelected,
                          IsPlus = true }
      };

      this.AvailableThemes = themes;
    }

    private ImageSource GetPreviewImage( string name )
    {
      var sb = new StringBuilder();
      sb.Append( "..\\OpenSourceImages\\" );
      sb.Append( name );
      sb.Append( ".png" );
      return new BitmapImage( new Uri( sb.ToString(), UriKind.RelativeOrAbsolute ) );
    }

    private void OnOffice2007SilverThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( "DataGrid_Office2007Silver" );
    }

    private void OnOffice2007BlackThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( "DataGrid_Office2007Black" );
    }

    private void OnOffice2007BlueThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( "DataGrid_Office2007Blue" );
    }

    private void OnWindows10ThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( "DataGrid_Windows10" );
    }

    private void OnMetroThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( model.IsDark ? "DataGrid_MetroDark" : "DataGrid_MetroLight" );
      _previewAdditionalText.Text = "The highlight color of this theme is configurable!";
    }

    private void OnMaterialThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( "DataGrid_Material" );
      _previewAdditionalText.Text = "The highlight colors of this theme are configurable!";
    }

    private void OnFluentThemeSelected( ThemeChoiceViewModel model )
    {
      _previewImage.Source = GetPreviewImage( model.IsDark ? "DataGrid_FluentDark" : "DataGrid_FluentLight" );
      _previewAdditionalText.Text = "The highlight color of this theme is configurable!";
    }

    #endregion

  }
}
