   M S B A M L   `   `   `  ����K  GPicturesRenaming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PicturesRenamingPicturesRenaming  5   	   !    PicturesRenaming.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PicturesRenaming     5   	     � Title$  
MainWindow��5   	   $��736.676��6   $��986.408��6-   .��5	      � $��0,0,2,0q�6    J� OpacityMask �	#FF1A343C$	��690��64   $	��Top=�6A   .+�5
   
   �� -   5         ��Name$ image1��5
      $
��Left=�6    $	��350��6;   $��595,217,0,0q�6H   $	��Top=�6]   $	��350��6u   }�.  J� SnapsToDevicePixels . $
��Fill=�6�    5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FF615E5E��6#    � Offset$ 1Q�65   5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        	 ��Name$	 btnAdd��5      $	��Add��6!   $
��Left=�6/   $��874,132,0,0q�6J   $	��Top=�6_   $��75��6w   {�.  6�   �� 5   
   -   5        
 ��Name$
 loadText��5      $
��Left=�6$   $��22��6?   $��595,132,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��247��6�   {�.  6�   R� 5   
   -   5         R�Name$ 	treeView1��5      $
��Left=�6&   $	��332��6A   $��	43,36,0,0q�6N   $	��Top=�6a   $	��248��6y   �� 5   
   -   5         ��Name$ 	listView1��5      $
��Left=�6'   $	��332��6B   $��
313,36,0,0q�6O   $	��Top=�6c   $	��262��6{    �� View 5      �� 5      .P�5      �� 5      5       �� 5!   
   -   5        $
 TextBox1��5!      $
��Left=�6%   $��57��6@   $��595,623,0,0q�6L   $
 Wrap=�6a   $��Coordinates��6u   $	��Top=�6�   $	��229��6�   �� 5"   
   -   5        $	 BtnSortDate��5"      $��Sort By Date��6&   $
��Left=�6=   $��313,387,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5#   
   -   5         ��Name$ AddDateToFoto��5#      $��Add Date to Foto��6-   $
��Left=�6H   $��
595,36,0,0q�6c   $	��Top=�6w   $	��194��6�   $y�Hidden=�6�   	� 5$   
   -	   5         	�Name$ RBtn1��5$       	� 	GroupName$ SelectPicture��6&   $��Add Date To All Foto��6A   $
��Left=�6`   $��
606,72,0,0q�6{   $	��Top=�6�    d� 	IsChecked$
 TrueY�6�   {�.  $y�Hidden=�6�   	� 5%   
   -
   5        $ Rbtn2��5%      $ SelectPicture��6(   $��Add Date To Selected Foto��6C   $
��Left=�6g   $��606,102,0,0q�6�   $	��Top=�6�   {�.  $y�Hidden=�6�   �� 5&   
   -   5        $	 	BtnRename��5&      $��Rename By Date��6&   $
��Left=�6?   $��432,387,0,0q�6Z   $	��Top=�6o   $	��125��6�    J� RenderTransformOrigin$ 	0.92,0.85&�6�   $y�Hidden=�6�   �� 5'   
   -   5         ��Name$ Label1��5'      $�� ��6"   $
��Left=�6-   $��595,159,0,0q�6H   $	��Top=�6]   $	��247��6u   �� 5(   
   -   5        $	 BtnMap��5(      $	��Map��6!   $
��Left=�6/   $��874,169,0,0q�6J   $	��Top=�6_   $��75��6w   6�   5*      5+      