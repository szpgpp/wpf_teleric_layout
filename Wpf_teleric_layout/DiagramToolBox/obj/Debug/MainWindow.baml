   M S B A M L   `   `   `  ����I  EDiagramToolBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DiagramToolBoxDiagramToolBox  5   	       DiagramToolBox.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   o kTelerik.Windows.Controls.Diagrams, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.Diagrams.Extensions, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q	 mTelerik.Windows.Controls.Navigation, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l
 hTelerik.Windows.Controls.Input, Version=2018.3.1016.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	   2localclr-namespace:DiagramToolBox     	 
 5   	     � Title$  
MainWindow��5   	   .��5      �  � DataContext 5   
   "   DiagramToolBox.MainViewModel  5	       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � 	Resources 5   
    �� Source�� 5      $3 -/DiagramToolBox;component/MyToolBoxStyle.xaml?�6!   %    .+�5   
   D  >Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramToolbox  -   5          Name$ toolbox��5   $   $��0��65      Title$ Gallery��5       $��Stretch=�5          ToolboxGroupTemplate#��[  5          Header 5       �� *SelectedItem.Header+ �� RelativeSource �� *Self+��5       �� *Items+y�5       �� *	IsChecked+	 �� ElementName$	 toolboxButton��   BooleanToVisibilityConverter
 �� 	Converter#
 [ �� 5"   
   -   5        $	��xsp��5"   "   $��1��6   $
��auto��6-   
���  ��$��40��6K   $	��Top=�6W   .+�5#      �� -   5         ��Name$ button��5#      $	��100��6%   $��40��61   $��Button��6=   6N   5$      )  #Telerik.Windows.Controls.RadDiagram  5%   
   -   5          Name$ diagram��5%      $��2��6.   $	��500��6;   5'      5(      