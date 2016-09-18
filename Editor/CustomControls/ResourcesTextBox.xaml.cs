﻿using System.Windows.Controls;
using System.Windows.Media;
using Isometric.CommonStructures;
using Isometric.Editor.Extensions;

namespace Isometric.Editor.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для ResourcesTextBox.xaml
    /// </summary>
    public partial class ResourcesTextBox
    {
        public Resources GameResources { get; private set; }



        public ResourcesTextBox()
        {
            InitializeComponent();

            TextChanged += ResourcesTextBox_OnTextChanged;
        }



        private void ResourcesTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Background = Brushes.White;
            if (Text == string.Empty || !IsEnabled)
            {
                return;
            }

            Resources resources;

            if (Text.TryParse(out resources))
            {
                GameResources = resources;
            }
            else
            {
                Background = Brushes.MistyRose;
            }
        }
    }
}