   M S B A M L   `   `   `  ����A  =ALMSPL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ALMSPLALMSPL  5   	       ALMSPL.AddAttendance   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ALMSPL     5   	     � Title$  AddAttendance��5   	   $	��450��6   $	��800��6,   ���	#FF96B0CD.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��339* �6   �� 5      $
��455* �6   .+�5   
   �� $��Attendance Details��6   $
��Left=�6-   $��
305,24,0,0q�6H   $	��Top=�6\   
���  ��$��25(�6�   $��2��6�   �� 5   
   $��Employee ID��6   $
��Left=�6&   $��
27,107,0,0q�6A   $	��Top=�6U   �� 5   
   -   5         ��Name$ txtEmpId��5       �� 
IsReadOnly . $
��Left=�66   $��23��6Q   $��170,108,0,0q�6]    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��150��6�   �� 5   
   $��
Project ID��6   $
��Left=�6%   $��
27,150,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ txtPId��5      $
��Left=�6#   $��23��6>   $��170,151,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��150��6�   �� 5   
   $��Attendance Type��6   $
��Left=�6*   $��
27,191,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5        $��cmbAType��5      $
��Left=�6#   $��170,192,0,0q�6>   $	��Top=�6S   $	��150��6k   .@�5      �� $��Select��6    �� 
IsSelected . 6,   �� 5      $��Working From Office��6   �� 5      $��Working From Home��6   �� 5      $��Business Travel��6   5      �� 5   
   $��Attendance Date��6   $
��Left=�6*   $��
27,233,0,0q�6E   $	��Top=�6Y   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��txtDate��5      $
��Left=�6&   $��170,234,0,0q�6A   $	��Top=�6V   $��26��6n   $	��150��6z      DisplayDate$ 
2020-09-30��6�      SelectedDateFormat$ Short=�6�   �� 5   
   $��In-Time��6   $
��Left=�6"   $��
27,275,0,0q�6=   $	��Top=�6Q   �� 5    
   -   5        $��	txtInTime��5       $
��Left=�6#   $��23��6>   $��170,276,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��150��6�   �� 5!   
   $��Out-Time��6   $
��Left=�6#   $��
27,316,0,0q�6>   $	��Top=�6R    J� RenderTransformOrigin$ 
0.465,2.38&�6j   �� 5"   
   -   5        $��
txtOutTime��5"      $
��Left=�6$   $��23��6?   $��170,317,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��150��6�   �� 5$   
   -   5        $��Add Attendance��5$      $
��Left=�6*   $��
27,352,0,0q�6E   $	��Top=�6Y   $	��120��6q   $��25��6�   �� 5%   
   -   5        $��Update Attendance��5%      $
��Left=�6-   $��170,355,0,0q�6H   $	��Top=�6]   $	��150��6u   $��20��6�   �� 5&   
   -	   5        $��Delete Attendance��5&      $
��Left=�6-   $��11.905,355,0,0q�6H   $	��Top=�6`   $	��116��6x   $��19��6�   $��1��6�   �� 5'   
   $��Search Attendance��6   $
��Left=�6,   $��
27,380,0,0q�6G   $	��Top=�6[   �� 5(   
   -
   5        $ txtAId��5(      $
��Left=�6"   $��23��6=   $��170,383,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��150��6�   �� 5)   
   -   5        $��Search Attendance��5)      $
��Left=�6-   $��11.905,387,0,0q�6H   $	��Top=�6`   $	��120��6x   $��1��6�   &   System.Windows.Controls.DataGrid  5+   
   -   5        $��dgAttendance��5+   u   $
��Left=�6   $	��226��6.   $��11.8,108,0,0q�6;   $	��Top=�6Q   $	��431��6i   $��1��6�   ��6�   �� 6�   �� 5,   
   -   5        $ ��AttendanceApproveRejectBtn��5,   ,   $��Pending Requests��6   $��1��6N   $
��Left=�6^   $��266.8,53,0,0q�6y   $	��Top=�6�   $	��124��6�   $��50��6�   6�   5/      50      