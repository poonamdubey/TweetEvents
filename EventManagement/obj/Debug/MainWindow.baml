   M S B A M L   `   `   `  ����  EventManagement     EventManagement.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Event Management System��5   	   $	��700��6)   $
��1100��66    � WindowStartupLocation$ CenterScreen=�6C    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   ]� ��. .+�5	      o� $	��Top=�6   $
��Auto��6(   .@�5
      m� $��_File��6   .@�5      m� -   5        $��mnuExit��5      $��E_xit��6.   5      m� 5      $��_Edit��6   .@�5      m� -   5        $��mnuPreferences��5      $��_Preferences...��65   5      m� 5      $��_Help��6   .@�5      m� -   5        $��mnuAbout��5      $��_About��6/   5      5      � 5       � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      �� -   5        $��lblLoginMessage��5      $��0��63   $��Right=�6C   $��Please Log In��6_   �� 5       -   5        $��btnLogin��5       $��1��6-   $��	10 0 10 0q�6=   $��10 0 2 0q�6Q   $��Log In��6c   6t   5!      �� 5"      $��1��6   ��5$      �� 5%       �� ImageSource$* $images/EventManagementSystem_PD1.jpg��6%    j� Stretch$
 Fill=�6X   .@�5(      �� -   5         ��Name$ tabCustomer��5(      $��Customer Information��63   $y�Visible=�6Q   .��5)      � -   5         �Name$ grdCustomer��5)      $y�Visible=�64    5*      �� 5+   "   $
��184* �63   �� 5,   "   $	��19* �63   �� 5-   "   $	��55* �63   �� 5.   "   $	��89* �63   �� 5/   "   $
��741* �63   .+�52      �� -   5        	 ��Name$	 
lblMessage��52   $   $�� Customers List��68   $��Center=�6R   $��	10,24,7,0q�6o   $	��Top=�6�   $	��167��6�   
���   �
 J� RenderTransformOrigin$
 0.494,0.557&�53   5   $��27��6Y   $��22(�6e   $
��Bold"�6s   
���   ����#4FC42C6�   &   System.Windows.Controls.DataGrid  55      -	   5          Name$ grdCustomerList��55   '      
IsReadOnly . $
��Left=�6R   $��	10,56,0,0q�6m   $	��Top=�6�   $	��500��56   #   $
��1068��60      SelectionMode$ Single=�6=   $��5��6�   �� 59      -
   5        $��Customer Controls Window��59   %   $
��Left=�6H   $��
555,24,0,0q�6c   $	��Top=�6w   $	��176��6�   $��27��6�   $��4��6�   5>      5B      �� 5C      -   5        $ tabEventBooking��5C      $��Event Booking Information��67   $y�Visible=�6Z   .��5D      � -   5        $ grdEventBooking��5D       5E      �� 5F   "   $	��21* �63   �� 5G   "   $
��251* �63   .+�5I      �� -   5        $	 lblEventBookingMessage��5I   $   $�� Event Booking List��6D   $��Center=�6b   $��10,22,873,0q�6   $	��Top=�6�   $	��205��6�   
���   �$
 0.494,0.557&�5J   $   $��27��6H   $��22(�6T   $
��Bold"�6b   ���#4FC42C
���   �$��2��6�   �� 5L      -   5        $#��Event Booking Controls Window��5L   %   $
��Left=�6M   $��
806,22,0,0q�6h   $	��Top=�6|   $	��188��6�   $
 0.708,-11.9&�6�   $��29��6�   $��1��6�     5N      -   5        $ grdEventBookingList��5N   '    . $
��Left=�6V   $��	10,56,0,0q�6q   $	��Top=�6�   $	��526��5O      $
��1068��6   $ Single=�6,      AutoGenerateColumns .     CanUserResizeColumns . $��2��5P   K      Columns 5Q   "   0  *System.Windows.Controls.DataGridTextColumn  5R   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *	BookingID+  5S   &   $ 
Event Date��69    6M   �� *	EventDate+  5T   &   $ 
Start Time��69    6M   �� *	StartTime+  5U   &   $ End Time��69    6K   �� *	EndTime+  5V   &   $ 
Event Name��69    6M   �� *EventType.EventTypeName+  5W   &   $ Venue��69    6H   �� *Venue.BuildingName+  5X   &   $ Customer First Name��69    6V   �� *Customer.FirstName+  5Y   &   $ Customer Last Name��69    6U   �� *Customer.LastName+  5Z   &   $ Caterers��69    6K   �� *Caterer.CatererName+5_      5`      5a      �� 5b      -   5        $ tabUser��5b      $��User Profile Information��6/   $y�Visible=�6Q   .��5c      � -   5        $ grdUser��5c       5d      �� 5e   "   $	��79* �63   �� 5f   "   $��5* �63   �� 5g   "   $
��110* �63   �� 5h   "   $	��10* �63   �� 5i   "   $	��48* �63   �� 5j   "   $
��836* �63   .+�5l      �� -   5        $	 lblUserList��5l   $   $�� User Profiles List��69   $��Center=�6W   $��
10,22,37,0q�6t   $	��Top=�6�   $	��205��6�   
���   �$
 0.494,0.557&�5m   $   $��27��6H   $��22(�6T   $
��Bold"�6b   ���#4FC42C
���   �$��5��6�   �� 5o      -   5        $!��User Profile Control Window��5o   %   $
��Left=�6K   $��
638,22,0,0q�6f   $	��Top=�6z   $	��188��6�   $
 0.708,-11.9&�6�   $��29��6�   $��5��6�     5q      -   5        $ grdUserList��5q   '    . $
��Left=�6N   $��
10,56,0,-4q�6i      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 85 6}   $	��Top=�6�   $	��540��5r      $
��1068��6   $ Single=�6,    . $��6��6`   5w      5x      5y      5z      � 5{      $��2��6    5|      �� 5}      $��* �6+   �� 5~      $
��Auto �6+   .+�5�      �� -   5        $��lblStatusMessage��5�      $��0��64   $��Created by:- Poonam Dubey��6D   �� 5�      -   5        $��lblStatusDate��5�      $��1��61   $��Date: December-15, 2015��6A   5�      5�      5�      5�      5�      