   M S B A M L   `   `   `  ????G  CModul14_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MVVM.View	MVVM.View  5   	   /clr-namespace:MVVM.ConverterMVVM.Converter  5   	   /clr-namespace:MVVM.ViewModelMVVM.ViewModel  5   	   clr-namespace:MVVMMVVM  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	       MVVM.View.DetailView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MVVM.View     5   	   -convclr-namespace:MVVM.Converter     5   	   +vmclr-namespace:MVVM.ViewModel     5   	   #mainclr-namespace:MVVM     5	   	   6sys&clr-namespace:System;assembly=mscorlib     5
   	   -   5          ?Name$  
Wnd_Detail??5   	    ? Title$ Neue Person??5   	    ? SizeToContent$ Height=?5   	   $	??291??6!    ? 
ResizeMode$ NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Topmost$
 True??5   	      Sty_Wnd#??[  5   	    ? 	Resources 5      *   $MVVM.Converter.GenderToBoolConverter  gender2bool,  &MVVM.Converter.ColorToIndexerConverter  color2index  
Odp_Colors S? 
MethodName S? 
ObjectTypeU QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Type	 S? MethodParameters  Odp_ColorsProperties
 S? ObjectInstance  CtpError ?? Orientation ??Name ??Name  double_FontSize ? AllowsTransparency ? PlacementTarget ?? ElementName ?? Path ?? Mode ?? Padding??%?  &	       &	      &	 &     &	 ?     7  &	 0    7  7    5   
   6%     5   
   6'   S? 5   
   $ GetType??5      "  5      	 5      ??5       tpSystem.Windows.Media.Colors, PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35??6?   5"      S? 5%   
   $ GetProperties??5&      8
   5'      ?? 5*   
   .R?5+      ?? $ 
Horizontal=?6   .+?5,      ?? $ BdrAep??6?   
???  ??$??1q?6+   ._?5-      ?? $	 Aep??60   5.      ?? 5/      $??!??6   
???  ??8??  $	??3,0q?50      $
??Bold"?6)   $??Center=?6;   ? 51      $
 True??6   $??Slide=?62   $??Bottom=?52   G    6   ?? $ BdrAep????53      ?? $	 Aep??$  AdornedElement.IsMouseOver?$ OneWay=?.??54      ?? 
???????
???  ??$ 2q?55   D   8?? ??54       ?? $	 Aep??$8 2AdornedElement.(Validation.Errors)[0].ErrorContent?55   P   56      57      58      5:       ? DataContext 5=      $   MVVM.ViewModel.DetailViewModel  5>   
   .??5A      ? $??10q?6    ? ColumnDefinitions 5C   
   ?? 5D      $
??Auto ?6   ?? 5E      $??* ?6    ? RowDefinitions 5G   
   ?? 5H      $
??Auto ?6   ?? 5I      $
??Auto ?6   ?? 5J      $
??Auto ?6   ?? 5K      $
??Auto ?6   ?? 5L      $
??Auto ?6   ?? 5M      $
??Auto ?6   ?? 5N      $
??Auto ?6   ?? 5O      $??* ?6   .+?5S   
   ?? $??Vorname:??6   ?? 5T   
   $??	Nachname:??6   $??1??5U      ?? 5V   
   $??Geburtsdatum:??6   $??2??5W      ?? 5X   
   $??Verheiratet:??6   $??3??5Y      ?? 5Z   
   $??Lieblingsfarbe:??6   $??4??5[      ?? 5\   
   $??Geschlecht:??6   $??5??5]      $	??Top=?5^      ?? 5_   
   $??Kinder:??6   $??6??5`      ?? 5e   
   -   5         ??Name$ Tbx_Vorname??5e      $??1??5f       =? ErrorTemplate# [ 5h      ??5g      ?? *NeuePerson.Vorname+ ?? UpdateSourceTrigger$ PropertyChanged=? ?? ValidatesOnDataErrors$
 True??5h      ?? 5j   
   -   5        $ Tbx_Nachname??5j      $??1??5k      $??1??6"   # [ 5m      ??5l      ?? *NeuePerson.Nachname+$ PropertyChanged=?$
 True??5m      (  "System.Windows.Controls.DatePicker  5o   
   -   5          Name$ Dpr_Geburtsdatum??5o      $??1??5p      $??2??6%   # [ 5r         SelectedDate 5q      ?? *NeuePerson.Geburtsdatum+$ PropertyChanged=?$
 True??5r      ?? 5t   
   -   5         ??Name$ Cbx_Verheiratet??5t      $??1??5u      $??3??6#    d? 	IsChecked 5v      ?? *NeuePerson.Verheiratet+$ PropertyChanged=??? 5|   
   -   5         ??Name$ Cbb_Lieblingsfarbe??5|      $??1??5}      $??4??6#     ?? SelectedValuePath$
  Name??5      # [ 5?      ??5~      ?? ! ?? Source#! [ " ?? SelectedIndex" 5?      ?? *NeuePerson.Lieblingsfarbe+# ?? 	Converter## [ $ ?? ConverterParameter#$ [ $
 True????5?      ?? 5?      .R?5?      ?? $ 
Horizontal=?6!   .+?5?      ?? 
???   ?$??1q?65   $??20??6I   $??20??6T   $	??5,0q?6`   ._?5?      ?? $??20??6(   $??20??63   ??6?   ?? *Name+5?      ?? 5?      ??6$   ?? *Name+5?      5?      5?      ?? 5?   
   $??2q?6   $??1??5?      $??5??6%   .+?5?      	? $??M??6   % 	? 	GroupName$% 
Rbg_Gender??5?       5?      ?? *NeuePerson.Geschlecht+$ PropertyChanged=?## [    MVVM.Gender&   	Männlich#$ Z& 	? 5?      $??W??6   $% 
Rbg_Gender??5?       5?      ?? *NeuePerson.Geschlecht+$ PropertyChanged=?## [ '   Weiblich#$ Z' 	? 5?      $??D??6   $% 
Rbg_Gender??5?       5?      ?? *NeuePerson.Geschlecht+$ PropertyChanged=?## [ (   Divers#$ Z( 5?         MVVM.IntegerUpDown  5?   
   -   5        )  Name$) 
Iud_Kinder??5?      $??25??5?      $??6??5?      $??1??6(   $??2q?68   # [ 5?      *   Value* 5?      ?? *NeuePerson.Kinder+$ PropertyChanged=?$ TwoWay=?$
 True??5?      ? 5?   
   $??7??6   $??2??6!   $??Right=?5?      $	??0,5q?60   .+?5?      ?? -   5        + ??Name$+ Btn_Ok??5?      $??OK??5?      ??5?      ?? *OkCmd+??5?      ?? $ 
Wnd_Detail????5?      ?? 5?      , ?? 
TargetType", ??6     Sty_Btn_Base- ?? BasedOn#- [ 60   .?5?      ?? . ?? Property. ? {?/ ?? Value$/ False??66   0 ?? Triggers0 5?      ^? 5?      1 ^? 
Conditions1 5?   "   ?? 5?   &   2 ?? Binding2 60   ?? $ Tbx_Vorname??$ (Validation.HasError)?3 ?? Value	3 False6x   ?? 5?   &   2 60   ?? $ Tbx_Nachname??$ (Validation.HasError)?	3 False6y   ?? 5?   &   2 60   ?? $ Dpr_Geburtsdatum??$ (Validation.HasError)?	3 False6}   ?? 5?   &   2 60   ?? $ Cbb_Lieblingsfarbe??$ (Validation.HasError)?	3 False6   ?? 5?   &   2 60   ?? $ 
Iud_Kinder??$ (Validation.HasError)?	3 False6w   .0?5?   "   ?? . ? {?$
/ True??6>   5?      5?      5?      ?? 5?      -	   5        $+ Btn_Abbruch??5?      $??	Abbrechen??5?      ??5?      ?? *
AbbruchCmd+??5?      ?? $ 
Wnd_Detail??5?      5?      5?      