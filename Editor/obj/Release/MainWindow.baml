   M S B A M L   `   `   `  ���� K  GIsometric.Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Isometric.EditorIsometric.Editor  Q-clr-namespace:Isometric.Editor.CustomControlsIsometric.Editor.CustomControls  !    Isometric.Editor.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Isometric.Editor     HcustomControls-clr-namespace:Isometric.Editor.CustomControls     -     �Name$  MainWindow1�� � Title$ Isometric Editor��$��366.78��$	��544��.��� $��0,0,0,1q� � RowDefinitions �� $	��24* ��� $
��307* �.+�o� -    o�Name$ TopMenu�����	#FFF3F3F3.@�m� $
��File��$��24��
���   �.@�m� -    m�Name$ NewMenuItem��$	��New��m� -   $ OpenMenuItem��$
��Open��m� -   $ SaveMenuItem��$
��Save���� -    ��Name$ MainTabControl��$��1�� J� RenderTransformOrigin$ 0.5,0.5&�.@��� -    ��Name$ BuildingsTabItem��$��	Buildings��.��� ���	#FFE5E5E5$��0,0,0,-6q� � ColumnDefinitions �� $
��125* ��� $	��88* ��� $
��313* �.+��� -   	 ��Name$	 BuildingsListBox��$
��Left=�$	��232��$��	10,10,0,0q�$	��Top=�$	��107��$ 0.5,0.5&��� -	   
 ��Name$
 AddBuildingButton��$��0��$	��Add��$
��Left=�$��
10,247,0,0q�$	��Top=�$��50��$��22���� -
   $
 RemoveBuildingButton��$��0��$��Remove��$
��Left=�$��
65,249,0,0q�$	��Top=�$��52��$��22���� -    ��Name$ 	NameLabel��$
��Name��$
��Left=�$��11,8,0,0q�$	��Top=�$��26��$��42��$��1���� -   $ ResourcesLabel��$��	Resources��$
��Left=�$��
53,103,0,0q�$	��Top=�$��26��$��63��$��2���� -   $ IdLabel��$��Id��$
��Left=�$��	11,41,0,0q�$	��Top=�$��26��$��22��$��1���� -   $ 	TypeLabel��$
��Type��$
��Left=�$��	10,72,0,0q�$	��Top=�$��26��$��43��$��1���� -   $ 
PriceLabel��$��Price��$
��Left=�$��
10,139,0,0q�$	��Top=�$��26��$��36��$��1���� -   $ UpgradesLabel��$��	Upgrades:��$
��Left=�$��
11,165,0,0q�$	��Top=�$��1��$��26��$��64���� -    ��Name$ NameTextBox��$
��Left=�$��23��$��	12,10,0,0q� �� TextWrapping$
 Wrap=�$
��Name��$	��Top=�$	��292��$��2���� -   $ 	IdTextBox��$
��Left=�$��23��$��	12,43,0,0q�$
 Wrap=�$��Id��$	��Top=�$	��224�� �� 
IsReadOnly . $ 0.554,2.736&�$��2���� -   $
 IdIncrementButton��$��+��$
��Left=�$��
245,44,0,0q�$	��Top=�$��22��$��2��$��22���� -   $
 IdDecrementButton��$��-��$
��Left=�$��
272,44,0,0q�$	��Top=�$��23��$ 
0.08,0.182&�$��2��$��22���� -    ��Name$ BuildingTypeComboBox��$
��Left=�$��	12,76,0,0q�$	��Top=�$	��120�� �� AlternationCount$ 1��$��22��$��2��6   0Isometric.Editor.CustomControls.ResourcesTextBox  -     Name$ ResourcesTextBox��6   0Isometric.Editor.CustomControls.ResourcesTextBox   TextChanged$" ResourcesTextBox_TextChanged��$
��Left=�$��
12,107,0,0q�$
 Wrap=�$	��Top=�$	��283��
�������$��20��$��2��  -   $ PriceTextBox��$ PriceTextBox_TextChanged��$
��Left=�$��
12,140,0,0q�$
 Wrap=�$	��Top=�$	��283��
�������$��20��$��2���� -   $	 UpgradesListBox��$
��Left=�$	��104��$��
12,165,0,0q�$	��Top=�$	��152��$��2���� -   $ UpgradesComboBox��$
��Left=�$��171,169,0,0q�$	��Top=�$	��124��$ 1��$��22��$��2���� -   $
 UpgradesAddButton��$	��Add��$
��Left=�$��171,196,0,0q�$	��Top=�$��65��$��2��$��22���� -   $
 UpgradesRemoveButton��$��Remove��$
��Left=�$��171,223,0,0q�$	��Top=�$��65��$��2��$��22���� -   $ ConstantsTabItem��$��	Constants��.��� ���	#FFE5E5E5$ 0.5,0.5&�.+��� -    ��Name$ ConstantsStackPanel��$
��Left=�$	��280��$	��Top=�$	��526��