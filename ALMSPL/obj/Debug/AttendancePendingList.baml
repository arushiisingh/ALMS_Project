   M S B A M L   `   `   `  ����A  =ALMSPL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ALMSPLALMSPL  5   	   "    ALMSPL.AttendancePendingList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ALMSPL     5   	     � Title$  AttendancePendingList��5   	   $	��450��6'   $	��800��64   ���	#FF96B0CD.��5	      �  � ColumnDefinitions 5   
   �� 5      $
��339* �6   �� 5      $
��455* �6   .+�5   
   �� $��Attendance Details��6   $
��Left=�6-   $��
305,24,0,0q�6H   $	��Top=�6\   
���  ��$��25(�6�   $��2��6�   �� 5   
   $��Employee ID��6   $
��Left=�6&   $��
27,321,0,0q�6A   $	��Top=�6U    J� RenderTransformOrigin$ -2.103,0.261&�6m   �� 5   
   -   5         ��Name$ txtEmpId��5       �� 
IsReadOnly . $
��Left=�66   $��23��6Q   $��146,322,0,0q�6]    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��150��6�   �� 5   
   $��Attendance ID��6   $
��Left=�6(   $��
27,352,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ txtAId��5      $
��Left=�6#   $��23��6>   $��146,352,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��150��6�   �� 5   
   $��Status Of Attendance��6   $
��Left=�6/   $��110.8,322,0,0q�6J   $	��Top=�6a   $ 
1.31,6.337&�6y   $��1��6�   �� 5   
   -   5        $��	cmbSAType��5      $
��Left=�6$   $��266.8,323,0,0q�6?   $	��Top=�6V   $	��150��6n   $��1��6z   .@�5      �� $��Pending��6    �� 
IsSelected . 6-   �� 5      $��Approved��6   �� 5      $��Rejected��6   5      �� 5   
   -   5        $��Submit��5      $
��Left=�6"   $��110.8,384,0,0q�6=   $	��Top=�6T   $	��120��6l   $��24��6�   $��1��6�   �� 5   
   -   5        $��Search Attendance��5      $
��Left=�6-   $��146,386,0,0q�6H   $	��Top=�6]   $	��150��6u   $��24��6�   &   System.Windows.Controls.DataGrid  5!   
   -   5        $��dgAttendance��5!   r   $
��Left=�6   $	��211��6.   $��	27,97,0,0q�6;   $	��Top=�6N   $	��729��6f   $��2��6�   ��6�   �� 6�   �� 5"   
   -   5        $��Approved Attendance��5"      $
��Left=�6/   $��	29,67,0,0q�6J   $	��Top=�6]   $	��108��6u   6�   �� 5#   
   -   5        $��Rejected Attendance��5#      $
��Left=�6/   $��
186,67,0,0q�6J   $	��Top=�6^   $��75��6v   6�   5&      5'      