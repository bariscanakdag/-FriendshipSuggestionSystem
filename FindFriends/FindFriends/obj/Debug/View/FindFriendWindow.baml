   M S B A M L   `   `   `  ����F  BFindFriends, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FindFriends.ViewFindFriends.View  5   	   '    !FindFriends.View.FindFriendWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FindFriends.View     5   	     � Title$  FindFriendWindow��5   	   $	��800��6"   $	��974��6/   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��10,67,76,421q�6W    J� RenderTransformOrigin$ 0.5,0.5&�6m   ��63   �� *NetworkList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Sıra��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *	NetworkID+  5      $ 	Numarası��6%    68   �� *
Numarasi+  5      $ Arkdaş1��6%    66   �� *Ark1+  5      $ Arkdaş2��6%    66   �� *Ark2+  5      $ 	Arkdaş3 ��6%    67   �� *Ark3+  5      $ 	Arkdaş4 ��6%    67   �� *Ark4+  5      $ 	Arkdaş5 ��6%    67   �� *Ark5+  5      $ 	Arkdaş6 ��6%    67   �� *Ark6+  5      $ 	Arkdaş7 ��6%    67   �� *Ark7+  5      $ 	Arkdaş8 ��6%    67   �� *Ark8+  5      $ 	Arkdaş9 ��6%    67   �� *Ark9+  5      $ 
Arkdaş10 ��6%    68   �� *Ark10+5      �� 5   
   $��DOSYA
   AÇ��6   $
��Left=�6S   $	��Top=�6n   $��75��6�   $��34��6�   ��60   �� *DosyaAcCommand+6�     5   
    .  $��10,386,85,109q�6S   $ 0.5,0.5&�6j   ��60   �� *
ProfilList+ 5        5      $ Sıra��6%    64   �� *
ProfilID+  5       $ 	Numarası��6%    68   �� *
Numarasi+  5!      $ A1��6%    61   �� *A1+  5"      $ A2��6%    61   �� *A2+  5#      $	 A3 ��6%    62   �� *A3+  5$      $	 A4 ��6%    62   �� *A4+  5%      $	 A5 ��6%    62   �� *A5+  5&      $	 A6 ��6%    62   �� *A6+  5'      $	 A7 ��6%    62   �� *A7+  5(      $	 A8 ��6%    62   �� *A8+  5)      $	 A9 ��6%    62   �� *A9+  5*      $
 A10 ��6%    63   �� *A10+  5+      $
 A11 ��6%    63   �� *A11+  5,      $
 A12 ��6%    63   �� *A12+  5-      $
 A13 ��6%    63   �� *A13+  5.      $
 A14 ��6%    63   �� *A14+  5/      $
 A15 ��6%    63   �� *A15+52      �� 53   
   $
��Left=�61   $��22��6L   $��
260,20,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��120��6�   ��6   �� *ArananOgrenci+6�   �� 54   
   $��Arkadaş Bul��6   $
��Left=�6M   $��
404,22,0,0q�6h   $	��Top=�6|   $��75��6�   ��6'   �� *ArkadasBulCommand+6�   55      56      