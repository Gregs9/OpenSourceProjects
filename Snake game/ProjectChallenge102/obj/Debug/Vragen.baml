   M S B A M L   `   `   `  ����  ProjectChallenge102     ProjectChallenge102.Vragen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Vragen��5   	    � Icon$ Afbeeldingen/icon.ico��6   $	��285��65   $	��600��6B    � WindowStyle$
 None=�6N    � 
ResizeMode$ NoResize=�6a   ���	#FFC7BBD1.��5      � ��5   
   �� 5       �� ImageSource$% Afbeeldingen/Vragen-Venster.png��6   .+�5	   
   �� -   5         ��Name$ LBLAntwoord��5	      $��Antwoord��6%   $
��Left=�68   $	��Top=�6S   $��
24,151,0,0q�6k   �� 5
   
   -   5        $ LBLOnderwerpTitel��5
      $��
Onderwerp:��6+   $
��Left=�6@   $	��Top=�6[   $��	10,26,0,0q�6s   �� 5   
   -   5        $ LBLMoeilijkheidTitel��5      $��Moeilijkheid:��6.   $
��Left=�6F   $	��Top=�6a   $��	10,47,0,0q�6y   �� 5   
   -   5         ��Name$ CMDVolgende��5      $��Volgende��6&   $
��Left=�69   $	��Top=�6T   $	��138��6l   $��430,213,0,0q�6x   $��62��6�   $y�	Collapsed=�6�    J� 	AllowDrop . $��0q�6�   $��30(�6  ��6�   Z� ��5      �� 5      $ Afbeeldingen/CMDLarge.png��6   5      �� 5   
   -   5        $ CMDBevestig��5      $��Bevestig��6&   $
��Left=�69   $	��Top=�6T   $	��138��6l   $��430,213,0,0q�6x   $��62��6�   $y�	Collapsed=�6�    . $��0q�6�   $��30(�6  ��6�   Z� ��5      �� 5      $ Afbeeldingen/CMDLarge.png��6   5      �� 5   
   -   5         ��Name$ TXTAntwoord��5      	 �� CharacterCasing$	 Lower=�6'   $��23��6?   
 �� TextWrapping$

 Wrap=�6K   $#��Hier schrijf je het antwoord.��6_   $	��547��6�   $��
26,179,0,0q�6�   
������� � ToolTip$/ )Hier schrijf je het antwoord op de vraag.��6�   $��Center=�6�   $��Stretch=�6  $
��Left=�62  $��14(�6M  $��0q�6[  $	��Top=�6o  �� 5   
   -   5        $ LBLVraag��5      $"��Hier komt de vraag te staan.��6"   $
��Left=�6I   $	��Top=�6d   $��
26,106,0,0q�6|   $��16(�6�   $��Verdana)�6�   �� 5   
   -   5        $ LBLOnderwerp��5      $��{onderwerp}��6&   $
��Left=�6>   $	��Top=�6Y   $��	92,26,0,0q�6q   $# Dit is het gekozen onderwerp.��6�   �� 5   
   -	   5        $ LBLMoeilijkheid��5      $��{moeilijkheid}��6)   $
��Left=�6D   $	��Top=�6_   $��	92,47,0,0q�6w   $# Dit is uw moeilijkheidsgraad.��6�   � 5   
   -
   5         �Name$ PGBTijd��5      $
��Left=�6'   $��24��6B   $��
269,41,0,0q�6N   $	��Top=�6b   $	��300��6z    � Value$ 75Q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�    � Maximum$ 75Q�6�   ���	#FFD6D600���	#FF444444$
��5,20q�6�   $* $Dit is de tijd die u nog over heeft.��6  z�5      V� 5      .~�5      �� �� 5       �� AngleX$ -7.595Q�6$   �� 5      T� 5        T� X$ 1.867Q�6)   5!      5#      �� 5$   
   -   5        $ LBLVraagAantal��5$      $��
Vraag 0/10��6(   $
��Left=�6=   $	��Top=�6X   $��
500,14,0,0q�6p   �� 5%   
   -   5        $ TXTFouteVragen��5%      $
��Left=�6*   $	��254��6E   $

 Wrap=�6R   $
��Naam��6f   $	��Top=�6r   $	��195��6�   $��	587,5,0,0q�6�   $y�	Collapsed=�6�   �� 5&   
   -   5        $ CMDStart��5&      $��Start��6#   $
��Left=�63   $��221,213,0,0q�6N   $	��Top=�6c   $	��138��6{   $��62��6�   $( "Druk om de vragenreeks te starten.��6�   $��30(�6�   $��0q�6�   ��6�   Z� ��5'      �� 5(      $ Afbeeldingen/CMDLarge.png��6   5*      �� 5+   
   -   5        $ 
CMDSluiten��5+      $��Sluiten��6%   $
��Left=�67   $��221,213,0,0q�6R   $	��Top=�6g   $	��138��6   $��62��6�   $y�	Collapsed=�6�    . $��0q�6�   $��30(�6  ��6�   Z� ��5,      �� 5-      $ Afbeeldingen/CMDLarge.png��6   5/      �� 50   
   -   5        $ CMDInfo��50      $��i��6"   $
��Left=�6.   $��
24,213,0,0q�6I   $	��Top=�6]   $��50��6u   $��63��6�   $6 0Druk voor meer informatie i.v.m. de vragenlijst.��6�   $��40(�6�   $��0q�6  
�������$��Times New Roman)�6)  $��Center=�6F  $��Center=�6j  ��6�   Z� ��51      �� 52      $ Afbeeldingen/CMDLarge.png��6   54      �� 55   
   -   5        $ LBLJuisteAntwoord��55      $�� ��6+   $
��Left=�66   $	��Top=�6Q   $��
24,206,0,0q�6i   �� 56   
   -   5        $ LBLWiskundeTip��56      $y�	Collapsed=�6(   $C��=Tip: Geef het antwoord in de vorm van een breuk. (0.5 -> 1/2)��6?   $
��Left=�6�   $	��Top=�6�   $��	26,75,0,0q�6�   $��16(�6�   $��Verdana)�6�   58      59      