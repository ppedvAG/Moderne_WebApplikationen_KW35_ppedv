   M S B A M L   `   `   `  ????G  CModul14_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MVVM.View	MVVM.View  5   	   /clr-namespace:MVVM.ViewModelMVVM.ViewModel  5   	   /clr-namespace:MVVM.ConverterMVVM.Converter  5   	       MVVM.View.ListView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MVVM.View     5   	   +vmclr-namespace:MVVM.ViewModel     5   	   -convclr-namespace:MVVM.Converter     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5	   	     ? Title$  Personendatenbank??5   	   $	??450??6#   $	??800??60      Sty_Wnd#??[  5   	    ? DataContext 5      "   MVVM.ViewModel.ListViewModel  5   
    ? 	Resources 5      *   $MVVM.Converter.ColorToBrushConverter  color2brush??%   &	         5   
   6%   5      .??5      ]? $??5q?6   .+?5   
   o? $	??Top=?6   .@?5      m? $??Datei??6   .@?5      m? -   5         m?Name$ Mei_Beenden??5      $??Beenden??5       m? Command 5      ?? *SchliessenCmd+5      5      ? 5!   
   $??Bottom=?6   $??Right=?5"      $??	10,0,10,5q?5#      .+?5$      ?? -   5         ??Name$ Btn_Neu??5$      $??Neue Person??5%      ??5&      ?? *NeuCmd+?? 5(      -   5        $ Btn_Aendern??5(      $??Ändere Person??5)      ??5*      ?? *
AendernCmd+??5+      ??  ?? ElementName$ Dgd_Personen?? ?? Path$ SelectedItem??? 5,      -   5        $ Btn_Loeschen??5,      $??Lösche Person??5-      ??5.      ?? *LoeschenCmd+??5/      ?? $ Dgd_Personen??$ SelectedItem?50      &   System.Windows.Controls.DataGrid  59   
   -   5          Name$ Dgd_Personen??59      $??10q?5:      	   
IsReadOnly$
	 True??5<      
   AutoGenerateColumns$
 False??5=      ??5;      ?? *Personenliste+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5?      +  %Microsoft.Xaml.Behaviors.EventTrigger  5@         	EventName$ MouseDoubleClick??6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5A      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   ?? *
AendernCmd+   CommandParameter 5B   ,   ?? $ Dgd_Personen??$ SelectedItem?5C         Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Vorname??6%    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ?? *	Vorname+6R     5I      $ Nachname??6%   $ *
 6T    67   ?? *
Nachname+6T     5J      $ 
Geschlecht??6%   $
 Auto
 6X    69   ?? *
Geschlecht+6X     5K      $ Geburtsdatum??6%   $
 Auto
 6u    6;   ?? *Geburtsdatum+ ?? StringFormat$ 
dd.MM.yyyy??6u     5L      $ Kinder??6%   $
 Auto
 6P    65   ?? *Kinder+6P     5M      $ Lieblingsfarbe??6%   $
 Auto
 6`    6=   ?? *Lieblingsfarbe+ 	  	CellStyle 5O      ?? 5P       ?? 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .?5Q      ??  ?? Property ? ?? ?? Value 6;   ?? *Lieblingsfarbe+ ?? 	Converter# [ 5R      5T      4  .System.Windows.Controls.DataGridCheckBoxColumn  5U      $ Verheiratet??6)   $
 Auto
 6^    6>   ?? *Verheiratet+6^   5W      5X      5Z      