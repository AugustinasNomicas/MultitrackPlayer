   M S B A M L   `   `   `  ����K  GMultitrackPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MultitrackPlayer.ControlsMultitrackPlayer.Controls  5      ?$clr-namespace:MultitrackPlayer.ViewsMultitrackPlayer.Views  5      I)clr-namespace:MultitrackPlayer.ViewModelsMultitrackPlayer.ViewModels  5      1    +MultitrackPlayer.Views.MultitrackPlayerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <controls'clr-namespace:MultitrackPlayer.Controls     5      6views$clr-namespace:MultitrackPlayer.Views     5      @
viewModels)clr-namespace:MultitrackPlayer.ViewModels     5        � 	Resources  5         	PlayThumb �� Padding��%�   &	        �� 5   
   .R�5      �� 
������ $ 0,0,8,0q�6.   ._�5      �� $��2��6   ���	#550000AA$��2��69   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��2 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5       $	��210 �6   �� 5"      $
��Auto �6   �� 5$      $��* �6   .+�5(   
   �� $��3��6   $��Stretch=�6%   
���   �$ 2q�6V   ._�5)      � .+�5*      �� $��Video output��6   
�������$��Center=�6B   $��Center=�6_   r� 5+      -   5         r�Name$ MediaElement��5+      $��Stretch=�65   6V   5,      5-      �� 5/   
   -   5         ��Name$ TracksScroller��53      $��	0,16,0,15q�5/      $	��Top=�50      $��2��51      $��Hidden=�52      $��Disabled=�54      .��56      '   !MultitrackPlayer.Views.TracksView  
������� � DataContext 6   �� *TracksViewModel+6G   57      �� 59   
   $��1��6   $��1��6'    �� ResizeDirection$ Columns=�64   $��Stretch=�6N   `� 5<   
   $��1��6   $��2��6#   .�5=      c� .@�5?      �� $
��Play��6   ��6(   �� *PlayCommand+�� 5@      $
��Stop��6   ��6(   �� *StopCommand+5A      c� 5B      .@�5C      �� $
��Time��6   6)   �� 5D      
�������$��1q�6-   ._�5E      �� 
���   �$��2q�5G        �� Padding$ 2q�5H       
�������$��14(�5J       $��Center=�5K       ��5E       �� *PlaybackPosition+	 �� StringFormat$	 
mm\:ss\.ff��5K       5L      5M      c� 5N      .@�5O      �� $
��Zoom��6   6)   �� 5P      
 � Minimum$

 0.55Q�6    � Maximum$ 3Q�6(   $	��100��6Q    � Value 64   �� *
ZoomFactor+6Q   5Q      5R      � 5U   
   $��2��6   $��2��6   $��0,2,0,0q�6,   .+�5V      �� -   5        $ MediaItemsScroller��5V   c   $
��Auto=�6   $
��Auto=�6>   ��.  .��5W      � .+�5X      �� .+�5Y      )   #MultitrackPlayer.Controls.TimeRuler  )   #MultitrackPlayer.Controls.TimeRuler   	MouseMove$ TimeRuler_OnMouseMove��5Z   -   
������� � Cursor$
 Hand��5\   -   $
��Bold"�5]   -   $��16��5^   -      Zoom 5_   -   �� *
ZoomFactor+ �� Mode$ OneWay=�   MillisecondsPerPixel 5`   -   �� *MillisecondsPerPixel+$ OneWay=�   Length 5a   -   �� *TotalLength+3   -MultitrackPlayer.Views.MediaItemsTimelineView  5c      $��0,1,0,0q�6k    67   �� *MediaItemsTimelineViewModel+6k   5d      )  #MultitrackPlayer.Controls.TimeThumb  5f      -   5          Name$ 	TimeThumb��5k   )   #��[  5f   )      MaxValue 5g   )   �� *TotalLength+   Value 5h   )   �� *PlaybackPosition+   Zoom 5i   )   �� *
ZoomFactor+$ OneWay=�   MillisecondsPerPixel 5j   )   �� *MillisecondsPerPixel+$ OneWay=�5k   )   5l      5m      5n      5q      5r      