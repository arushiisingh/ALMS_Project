   M S B A M L   `   `   `  ����A  =ALMSPL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ALMSPLALMSPL  5   	       ALMSPL.ProjectAttendance   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ALMSPL     5   	     � Title$  ProjectAttendance��5   	   $	��450��6#   $	��800��60   ���	#FF8CB6C3.��5	      � .+�5
   
   �� $ ��Project Attendance Details��6   $
��Left=�65   $��
241,24,0,0q�6P   $	��Top=�6d   
���  ��$��25(�6�   �� 5   
   $��
Project ID��6   $
��Left=�6%   $��	27,87,0,0q�6@   $	��Top=�6S   �� 5   
   -   5         ��Name$ txtPId��5      $
��Left=�6#   $��23��6>   $��
102,88,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��150��6�   �� 5   
   -   5        $��Submit��5      $��273,87,383.6,0q�6"   $	��Top=�6:   $��26��6r   �� 5   
   -   5        $ txtMonth��5      $
��Left=�6%   $��23��6@   $��466,146,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��150��6�   �� 5   
   -   5        $��Search By Month��5      $��635,147,21.6,0q�6+   $	��Top=�6C   $��26��6�   �� 5   
   $��	From Date��6   $
��Left=�6$   $��
465,65,0,0q�6?   $	��Top=�6S   �� 5   
   $��To Date��6   $
��Left=�6"   $��
621,65,0,0q�6=   $	��Top=�6Q   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��txtDateFrom��5      $
��Left=�6*   $��
462,90,0,0q�6E   $	��Top=�6Y   $��26��6q   $	��150��6}      DisplayDate$ 
2020-09-30��6�      SelectedDateFormat$ Short=�6�     5   
   -   5        $��	txtDateTo��5      $
��Left=�6(   $��
622,88,0,0q�6C   $	��Top=�6W   $��26��6o   $	��150��6{   $ 
2020-09-30��6�   $ Short=�6�   �� 5   
   -   5        $��Search By Date��5      $��465,115,191.6,0q�6*   $	��Top=�6C   $��26��6�   �� 5   
   -   5        $��Search Between Dates��5      $��631,115,25.6,0q�60   $	��Top=�6H   $��26��6�   &   System.Windows.Controls.DataGrid  5   
   -	   5        $��dgProjectAttendance��5   s   $
��Left=�6   $	��242��6.   $��
12,174,0,0q�6;   $	��Top=�6O   $	��772��6g   ��6�   �� 5      5       