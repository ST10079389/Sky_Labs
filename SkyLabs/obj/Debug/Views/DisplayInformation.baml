   M S B A M L   `   `   `  ����B  >SkyLabs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SkyLabs.ViewsSkyLabs.Views  5      &     SkyLabs.Views.DisplayInformation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:SkyLabs.Views     5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  61   $	��650��5      $	��940��6,     N� Title$  Request Tests��5	      .��5
      ��  �� CornerRadius$ 45��6   ���#27396b._�5   
   � .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns .  $��66,202,66,202q�6E      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *	FirstName+6[     5      $ Surname��6)   $	 110 6V    6:   �� *	Surname+6V     5      $	 Age��6)   $ 50 6N    66   �� *Age+6N     5      $ Gender��6)   $ 50 6T    69   �� *Gender+6T     5      $ Mobile Number��6)   $	 140 6a    6@   �� *MobileNumber+6a     5      $ Time Sample Was Taken��6)   $	 180 6l    6H   �� *TimeSampleTaken+6l     5      $ Date Of Birth��6)   $ * 6`    6@   �� *DateOfBirth+6`   5      �� 5      -   5         ��Name$ welcomeText��5      $��Enter Results��6)   $
��Left=�6A   $��	231,0,0,0q�6\   $	��Top=�6o   $	��440��6�   $��72(�6�   
�������
������ 
���   �$��91��6�   �� 5      -   5        	 ��Name$	 patientNameBox��5      $
��Left=�6/   $��250,132,0,0q�6J   $	��Top=�6`   $	��624��6x   $��47��6�   $��30(�6�   6�   �� 5      $��Patient Name:��6   $
��Left=�6,   $��
27,127,0,0q�6G   $	��Top=�6[   $��57��6s   $	��202��6   
�������$��30(�6�   �� 5      -   5        
 ��Name$
 
exportText��5      $��	Text File��6)   $
��Left=�6=   $��157,467,0,0q�6X   $	��Top=�6m   $��58��6�   $	��255��6�   ���	#FF6000C6
�������
���   �$��24(�6�   �� 5      -   5        $
 
exportJson��5      $��	Json File��6)   $
��Left=�6=   $��562,467,0,0q�6X   $	��Top=�6m   $��58��6�   $	��255��6�   ���	#FF0300DA
�������
���   �$��24(�6�   5      5      5      