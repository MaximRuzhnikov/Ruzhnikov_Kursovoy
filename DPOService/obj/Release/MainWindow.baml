   M S B A M L   `   `   `  ???? E  ADPOService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DPOService
DPOService      DPOService.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'ucclr-namespace:DPOService     X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  -     ? Title$  
MainWindow??$	??700??$
??1280?? ? WindowStartupLocation$ CenterScreen=? ? WindowStyle$
 None=? ? AllowsTransparency . 
?????? .???  ? ColumnDefinitions ?? $	??250 ??? $??* ?.+???  ?? CornerRadius$ 	10 0 0 10??????  ?? 
StartPoint$ 0.5,0&? ?? EndPoint$ 0.5,1&?.???  ? Color$ #f2f2f2??	 ? Offset$	 0Q?? $ #e5e5e5??$	 1Q?._??? .+??? 
 ?? Orientation$
 
Horizontal=?$??Center=?$??0 35 0 0q?.+??? $ 10??$	??150??$	??150??._??? $??/DPOLogo.png???? $	??0.8??$??20 30q????#999999	?    
menuButton#??[   d? 	IsChecked$
 TrueY?.???? $
 
Horizontal=?.+?!  FontAwesome.Sharp.IconImage  ?  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=?  menuButtonIcon#??[ ?? $??Главная??  menuButtonText#??[ 	? #??[  .???? $
 
Horizontal=?.+?  $ ChartSimple=?#??[ ?? $??Статистика??#??[ 	? -    	?Name$ 
ExitButton??#??[  .???? $
 
Horizontal=?.+?  $ RightFromBracket=?#??[ ?? $??
Выход??#??[ ?? -   $??1??$ 	0 10 10 0?????? $	 1,0&?$	 0,1&?.??? $ #f2f2f2??$	 0Q?? $ #e5e5e5??$	 1Q?._??  ? RowDefinitions ?? $
??auto ??? $	??200 ??? $??* ?.+??? $
 
Horizontal=?$??Bottom=?$??Right=?$??	0 0 30 20q?? $??1??$??50 20 15 40q? ?? $??* ??? $??* ??? $??* ?.+?   DPOService.Cards  $??0??   Title$! Число клиентов??   Number$ 0??   Icon$
 User=?   BackGround1$ #5b0f20??   BackGround2$ #cda1ab??   EllipseBackGround1$ #c08a97??   EllipseBackGround2$ #27060e??  $??1??$  ??$  ??$ #5b0f20??$ #cda1ab??$ #c08a97??$ #27060e??  $??2??$  ??$  ??$ #5b0f20??$ #cda1ab??$ #c08a97??$ #27060e?? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q?   	Direction$	 -90Q?   RenderingBias$ Quality=?   ShadowDepth$ 2Q?? $??2??$??15 15 15 15q?.+??? ???#d9d9d9$ 15??._?&   System.Windows.Controls.DataGrid  -   $??	TabelMain??   AutoGenerateColumns .  
?????? ????    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID??   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50   $ ФИО??$	 150   $! Номер телефона??$	 150   $, &Дата начала обучения??$	 150   $2 ,Дата окончания обучения??$	 150 