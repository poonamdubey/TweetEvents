   M S B A M L   `   `   `  ����  EventManagement!    EventManagement.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  window��5	   )    � Title$ Login��5      $	��220��6   $	��400��6    
���� �� � WindowStartupLocation$ CenterScreen=�5   &   $��Arial)�5      $��15(�6-    J� RenderTransformOrigin$ 0.5,0.5&�5	   	   $��0��69    � ShowInTaskbar .  J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ Close��5      5   	   .��5      � $
��Auto��6   $
��Auto��6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��115 �6   �� 5      $	��285 �6   .+�5   
   �� $��Right=�6   $��0,0,0,0q�60   $��Center=�6A   $��1��6\   $��
User Name:��6i   $
��Wrap=�6{   �� 5   
   $��Right=�6   $��0,0,0,0q�60   $��Center=�6A   $��2��6\   $��	Password:��6i   $
��Wrap=�6z   �� 5!   
   -   5        	 ��Name$	 txtUsername��5"   P   $
��Left=�5!      $��5,7,0,0q�6-   $��Center=�6>   $	��225��6Y   $��1��6e   $��1��6u   
 �� TextWrapping$

 Wrap=�5"       �� MaxLines$ 1��6&    �� 	MaxLength$ 50��63   $��12(�6B   $��SDubey��6e   $��0��6s   $��24��6�   G� 5$   
   -   5         G�Name$ txtPassword��5%   $   $
��Left=�5$      $��4,7,0,1q�61   $��Center=�6B   $	��226��6^   $��1��6j   $��2��6z    G� 	MaxLength$ 32��6�   $��12(�5%       G� Password$ s12dubey��69   $��1��6M   $��23��6Z   �� 5'   
   -   5         ��Name$ btnLogin��5(   q   $
��Left=�5'   )   $��
23,0,0,-14q�6D   $��Bottom=�6X   $��72��6s   $��26��6~   $��Login��5(      $��1��6!   $��3��61   
���   �$��15(�6R    �� 	IsDefault . $��2��6�   �� 5*   
   -   5        $ 	btnCancel��5+   0   $��99,19,114,-14q�5*   *   $��72��6A   $��Cancel��6L   $��1��6]   $��3��6m   
���   �$��15(�5+       �� IsCancel . $��3��6C   $��26��6P   $	��Top=�6\   5/      50      