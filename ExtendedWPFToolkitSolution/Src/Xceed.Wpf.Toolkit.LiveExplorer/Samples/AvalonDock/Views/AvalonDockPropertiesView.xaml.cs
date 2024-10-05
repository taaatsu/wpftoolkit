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

/*************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2024 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ************************************************************************************/

using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.LiveExplorer.Samples.AvalonDock.Views
{
  public partial class AvalonDockPropertiesView : DemoView
  {
    public AvalonDockPropertiesView()
    {
      InitializeComponent();
    }
  }

  public class GenericResourceDictionary : ResourceDictionary
  {
    public GenericResourceDictionary()
    {
      this.Source = new Uri( @"/" +
#if NETCORE
          "Xceed.Wpf.AvalonDock.NETCore" +
#else
          "Xceed.Wpf.AvalonDock" +
#endif
          ";component/Themes/generic.xaml", UriKind.Relative );
    }
  }
}
