   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089o kTelerik.Windows.Controls.Diagrams, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.Diagrams.Extensions, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l	 hTelerik.Windows.Controls.Input, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7(   "Telerik.Windows.Controls.RadButton  �� 
TargetType   OpenCloseButtonStyle  RadButtonStyle �� BasedOn �� Property �� Value �� Stretch  ToolboxButtonForeground J� RenderTransformOrigin �� AngleD  >Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramToolbox  RadDiagramToolboxStyle �� 
TargetType �Name	 � RowDefinitions
 T� Y;  5Telerik.Windows.Controls.TabControl.RadTabControlBase   HeaderBackground  ToolboxHeaderBorderBrush  TitleBorderTickness ! ToolboxHeaderInnerBorderBrush  HeaderFontFamily  HeaderFontSize   TitleTemplate   Title   Name   CloseButtonStyle ^� ToolTip;  5Telerik.Windows.Controls.LocalizableResourceExtension
   Key 	 HeaderBorderTickness   HeaderTemplate   Header 
 SelectedContentBackground ��Name �� Orientation   OpenCloseButtonStyle  ViewGalleriesFontFamily  ViewGalleriesFontWeight  ViewGalleriesFontSize �� Triggers P� Property P� Value N� EnterActions g� Duration �� 
TargetName �� TargetProperty	 W� To N� ExitActions  ToolboxItemTemplate  (� Stretch.  (Telerik.Windows.Controls.RadDiagramShape! J� IsHitTestVisible"   Geometry# �� Padding$ �� TextAlignment  ToolboxGroupTemplate% �� ItemTemplate& �� ItemsSource;  5Telerik.Windows.Controls.BooleanToVisibilityConverter   BooleanToVisibilityConverterI  CTelerik.Windows.Controls.Diagrams.Extensions.RadDiagramToolboxGroup  RadDiagramToolboxGroupStyle8  2Telerik.Windows.Controls.Primitives.RadUniformGrid'   Columns'  !System.Windows.VisualStateManager(   VisualStateGroups%	  System.Windows.VisualStateGroup) 	  States 
  System.Windows.VisualState* 
  
Storyboard+ R� KeyTime, R� Value   System.Windows.Visibility " ToolboxItemMouseOverForeground  ToolboxItemForeground- ��Name  ToolboxGroupCornerRadius. �� CornerRadius   ToolboxGroupHoverBorderBrush  ToolboxGroupHoverBackground  ToolBoxGroupOpacity/ J� Opacity $  ToolboxGroupInnerBorderThickness   ToolboxGroupInnerBorderBrush " ToolboxGroupSelectedBackground # ToolboxGroupSelectedBorderBrush0 ��Name  ToolBoxGroupFontSize1 �� RelativeSource2 �� Path3 �� Mode�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      Itelerik1http://schemas.telerik.com/2008/xaml/presentation      	 5      %U  &	        7  7  '      7  7   7  7  7  7  7  7  7 	 7  7  7  7 
 7  7  7  7  &	 &    &	 �    7  &	 :    '  M    7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  �� 5      "    6   8   .�5   
   ��  � ��$ Center=�6.   �� 5   
    � ��$ 22��6%   �� 5   
    � ��$ 22��6&   �� 5	   
    � ��$	 4 6q�6$   �� 5
   
    � ��$ 3q�6#   �� 5   
    � �� 5      �� 5      .R�5      F� X������p,��pox�hP�H�%�hPјҝh����.%�P�H�w�P�����������������p,�$
 Fill=�5      $��10��5      $��7��5      8�� $ 0.5, 0.5&�5      z�5      �� 5      $	 -90Q�6.   5      5      5      5      �� 5      "   6   8   .�5    
   ��  �@ OpenCloseButtonStyle8  61   �� 5!   
    � �� 5"      �� 5#      "  6"   .R�5$      � $ RootGrid��6   	 5%      �� 5&      $
��Auto �6,   �� 5'      $
��Auto �6,   .+�5*      � $ hideablePart��6   $��1��65   	 5+      �� 5,   "   $
��Auto �60   �� 5-   "   $��* �60   �� 5.   "   $
��Auto �60   z�50      T� 51   "   $
 0Q�65   .+�54      �� $��1��6%   $��2��62   #��z��6C   #��z��6m   $��1 0 0 1q�6�   �� 55   "   #��z 6)   8�� $��1 1 0 1q�6�   ._�56   &   �� 8�� 8�� ._�57   *   �� #��z��58      #��z��59      8�� 8�� #��z 5<      $��Center=�5=      $
��Left=�5>      #��z 5?      5@   '   5A   #   �� 5C      $��1��6-   $	��2 3q�6:      5D      $ CloseButton��60   $��2��6E   #��z 6R    5E   "   _� 5F   &   ��6.     $ Close��5H      5I      � 5K      $��0��6   	 5L      �� 5M   "   $
��Auto �60   �� 5N   "   $��* �60   �� 5O   "   $
��Auto �60   .+�5Q      �� 8�� #��z 6]   $��1q�6�   ._�5R   "   �� 8�� 8��	 ._�5S   &   �� #��z��5T   -   #��z 5U   -   8��
 8�� #��z��5X   -   #��z��5Y   -   #��z��5Z   -   #��z 5[   -   5\   #   5]      �� 5_      $��1��6%   $��1q�62   8�� #��z��6~   ._�5`   "   �� $ SelectedTabContent��63   5a      �� 5c      $��2��6%   $��1q�62   #��z��6F   #��z��6p   ._�5d   "   �� $ 
Horizontal=�6-   $��Center=�6F   .+�5e   &      $ OpenCloseButton��68   #��z 6Q    5f   *   _� 5g   .   ��66     $ 
Open_Close��5i   '   �� 5j   &   $��5 0 0 0q�5k   -   8�� 8�� 8�� $��Center=�5p   -   8�� ��5l   -     $ Toolbox_ViewGalleries��5q   -   5r   #   5s      5t      5u       5v      P� 5w       �@ IsOpen .  5x      �� 5y   "   .��5z   &   �� .��5{   *   W� $ 
00:00:00.4D�6:   $ hideablePart��6P   $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5|   2   $ 0X�6�   5}   +   5~   '   5   #    5�      �� 5�   "   .��5�   &   �� .��5�   *   W� $ 00:00:00.32D�6:   $ hideablePart��6Q   $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5�   2   $
 -100X�6�   5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�      .R�5�   
   �� $	��100��5�      $��0 1 1 0q�5�      
������ ._�5�      � 	 5�      �� 5�      $��* �6$   �� 5�      $
��Auto �6$   .+�5�      (� $��64��6   $��50��5�      $��5 10 5 0q�5�      $��Center=�5�      $	��Top=�5�      $  Uniform=�5�      .��5�        $��15q�6.   $	��Top=�5�   2   $��Center=�5�   2   $��Center=�5�   2   ! .  " 5�   2   �� *
Geometry+5�   2   5�      �� 5�      $��1��6   $��0 0 0 5q�5�       $��Center=�5�       $��Segoe UI Semibold)�5�       $	# 4 0q�5�       $$ Center=�5�       $
��Wrap=�5�       ��5�       �� *Header+5�       5�      5�      5�      �� 5�      8%   & 5�   #   �� *Shapes+.R�5�   
   �� ��6   �� *Header+5�        5�      6+   �� 5�      "   6   8   .�5�   
   ��  � �� 5�      �� 5�      .R�5�        $	��Top=�6-   $' 4��6E   5�      5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � $ 	RootPanel��6   ( 5�      	  5�      CommonStates��.) 5�   "   
  
Normal��6.   
  5�   "   	MouseOver��.* 5�   &   �� .��5�   *   T� $ 0D�6H   $ MouseOverVisual��6U   $ 
Visibility�6}   ..�5�   .   i� $+ 0��6E   , 5�   2    5�   6   Visible=�6J   5�   /   5�   +   T� 5�   *   $ HeaderElement��6H   $ 
Foreground�6n   ..�5�   .   i� $+ 0��6E   8,  6Q   5�   +   5�   '   5�   #   5�      	  5�      SelectionStates��.) 5�   "   
  Selected��.* 5�   &   �� .��5�   *   T� $ SelectedVisual��6H   $ 
Visibility�6o   ..�5�   .   i� $+ 0��6E   , 5�   2    5�   6   Visible=�6J   5�   /   5�   +   T� 5�   *   $ HeaderElement��6H   $ 
Foreground�6n   ..�5�   .   i� $+ 0��6E   8,  6Q   5�   +   5�   '   5�   #   
  5�   "   NotSelected��.* 5�   &   �� .��5�   *   T� $ SelectedVisual��6H   $ 
Visibility�6o   ..�5�   .   i� $+ 0��6E   , 5�   2    5�   6   	Collapsed=�6L   5�   /   5�   +   T� 5�   *   $ HeaderElement��6H   $ 
Foreground�6n   ..�5�   .   i� $+ 0��6E   8,  6Q   5�   +   5�   '   5�   #   5�      	 5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5     � $ HeaderPanel��6   .+�5     �� #��z��6%   #��z��6O   #��z��6�   �� 5     $- MouseOverVisual��6%   $y�	Collapsed=�5  %   $��1q�5  %   8.  8�� 8�� 8/  ._�5
  "   �� 8�� 8��	 6m   5     �� 5     $- SelectedVisual��6%   $y�	Collapsed=�5  %   $��1q�5  %   8. 
 8�� 8�� ._�5  "   �� $��1q�6)   8�� 6=   5     �� 5     $0 HeaderElement��6-   #��z��5  %   #��z��5  %   #��z��5  %   #��z��5  %   8�� #��z��5  %   #��z��5  %   ��5  %   �� 1 �� *TemplatedParent+$2 
Foreground�$3 TwoWay=�5  %   5     � 5     $ ContentPanel��6   $��1��65   $��0��6E   $��0��6O   #y�zy�6Z   .+�5     �� $��OuterBorder��6%   $��2��68   ._�5   "   �� $��Visible=�6/   $
��Auto=�6W   $��5q�6z   $��1q�6�   .��5!  &   �� 5"  #   5#     5$     5%     5&     5(     5*     5+     