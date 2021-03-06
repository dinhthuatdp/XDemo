﻿using System.Collections.Generic;
using Xamarin.Forms;

namespace XDemo.UI.Controls.ExtendedElements
{
    /// <inheritdoc />
    /// <summary>
    /// Class ButtonGroup.
    /// </summary>
    public class ButtonGroup : ContentView
    {
        /// <summary>
        /// The view background color property
        /// </summary>
        public static readonly BindableProperty ViewBackgroundColorProperty =
            BindableProperty.Create(nameof(ViewBackgroundColor), typeof(Color), typeof(ButtonGroup), Color.Default,
                BindingMode.TwoWay);

        /// <summary>
        /// The background color property
        /// </summary>
        public static readonly BindableProperty ItemBackgroundColorProperty =
            BindableProperty.Create(nameof(ItemBackgroundColor), typeof(Color), typeof(ButtonGroup), Color.Default,
                BindingMode.TwoWay);

        /// <summary>
        /// The selected background color property
        /// </summary>
        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(ButtonGroup), Color.Default,
                BindingMode.TwoWay);

        /// <summary>
        /// The text color property
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
            typeof(Color), typeof(ButtonGroup), Color.Default, BindingMode.TwoWay);

        /// <summary>
        /// The selected text color property
        /// </summary>
        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(ButtonGroup), Color.Default,
                BindingMode.TwoWay);

        /// <summary>
        /// The border color property
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor),
            typeof(Color), typeof(ButtonGroup), Color.Default, BindingMode.TwoWay);

        /// <summary>
        /// The selected border color property
        /// </summary>
        public static readonly BindableProperty SelectedBorderColorProperty =
            BindableProperty.Create(nameof(SelectedBorderColor), typeof(Color), typeof(ButtonGroup), Color.Transparent,
                BindingMode.TwoWay);

        /// <summary>
        /// The selected frame background color property
        /// </summary>
        public static readonly BindableProperty SelectedFrameBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedFrameBackgroundColor), typeof(Color), typeof(ButtonGroup),
                Color.Transparent, BindingMode.TwoWay);

        /// <summary>
        /// The selected index property
        /// </summary>
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex),
            typeof(int), typeof(ButtonGroup), default(int), BindingMode.TwoWay);

        /// <summary>
        /// The items property property
        /// </summary>
        public static readonly BindableProperty ItemsPropertyProperty = BindableProperty.Create(nameof(Items),
            typeof(List<string>), typeof(ButtonGroup), default(List<string>), BindingMode.TwoWay);

        /// <summary>
        /// The font property
        /// </summary>
        public static readonly BindableProperty FontProperty =
            BindableProperty.Create(nameof(Font), typeof(Font), typeof(ButtonGroup), Font.Default);

        /// <summary>
        /// The rounded property
        /// </summary>
        public static readonly BindableProperty RoundedProperty =
            BindableProperty.Create(nameof(Rounded), typeof(bool), typeof(ButtonGroup), false);

        /// <summary>
        /// The is number property
        /// </summary>
        public static readonly BindableProperty IsNumberProperty =
            BindableProperty.Create(nameof(IsNumber), typeof(bool), typeof(ButtonGroup), false);

        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create(nameof(BorderRadius), typeof(int), typeof(ButtonGroup), 0);


        /// <summary>
        /// The button layout
        /// </summary>
        private readonly WrapLayout _buttonLayout;

        /// <summary>
        /// The spacing
        /// </summary>
        private const int DefaultSpacing = 5;

        /// <summary>
        /// The padding
        /// </summary>
        private const int DefaultPadding = 5;

        /// <summary>
        /// The button border width
        /// </summary>
        private const int DefaultButtonBorderWidth = 1;

        /// <summary>
        /// The frame padding
        /// </summary>
        private const int DefaultFramePadding = 1;

        /// <summary>
        /// The button border radius
        /// </summary>
        private const int DefaultButtonBorderRadius = 5;

        /// <summary>
        /// The button height
        /// </summary>
        private const int DefaultButtonHeight = 44;

        /// <summary>
        /// The button height wp
        /// </summary>
        private const int DefaultButtonHeightWp = 72;

        /// <summary>
        /// The button half height
        /// </summary>
        private const int DefaultButtonHalfHeight = 22;

        /// <summary>
        /// The button half height wp
        /// </summary>
        private const int DefaultButtonHalfHeightWp = 36;

        #region Properties

        public int BorderRadius
        {
            get => (int) GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the view background.
        /// </summary>
        /// <value>The color of the view background.</value>
        public Color ViewBackgroundColor
        {
            get => (Color) GetValue(ViewBackgroundColorProperty);
            set
            {
                SetValue(ViewBackgroundColorProperty, value);
                _buttonLayout.BackgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color which will fill the background of a VisualElement. This is a bindable property.
        /// </summary>
        /// <value>The color that is used to fill the background of a VisualElement. The default is <see cref="P:Xamarin.Forms.Color.Default" />.</value>
        /// <remarks>To be added.</remarks>
        public Color ItemBackgroundColor
        {
            get => (Color) GetValue(ItemBackgroundColorProperty);
            set
            {
                SetValue(ItemBackgroundColorProperty, value);

                if (_buttonLayout == null)
                {
                    return;
                }

                for (var iBtn = 0; iBtn < _buttonLayout.Children.Count; iBtn++)
                {
                    SetSelectedState(iBtn, iBtn == SelectedIndex);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected background.
        /// </summary>
        /// <value>The color of the selected background.</value>
        public Color SelectedBackgroundColor
        {
            get => (Color) GetValue(SelectedBackgroundColorProperty);
            set
            {
                SetValue(SelectedBackgroundColorProperty, value);

                if (_buttonLayout == null)
                {
                    return;
                }

                for (var iBtn = 0; iBtn < _buttonLayout.Children.Count; iBtn++)
                {
                    SetSelectedState(iBtn, iBtn == SelectedIndex);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get => (Color) GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the selected text.
        /// </summary>
        /// <value>The color of the selected text.</value>
        public Color SelectedTextColor
        {
            get => (Color) GetValue(SelectedTextColorProperty);
            set => SetValue(SelectedTextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get => (Color) GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the selected border.
        /// </summary>
        /// <value>The color of the selected border.</value>
        public Color SelectedBorderColor
        {
            get => (Color) GetValue(SelectedBorderColorProperty);
            set => SetValue(SelectedBorderColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the selected frame background.
        /// </summary>
        /// <value>The color of the selected frame background.</value>
        public Color SelectedFrameBackgroundColor
        {
            get => (Color) GetValue(SelectedFrameBackgroundColorProperty);
            set => SetValue(SelectedFrameBackgroundColorProperty, value);
        }


        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get => (Font) GetValue(FontProperty);
            set => SetValue(FontProperty, value);
        }

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex
        {
            get => (int) GetValue(SelectedIndexProperty);
            set
            {
                SetSelectedState(SelectedIndex, false);
                SetValue(SelectedIndexProperty, value);

                if (value < 0 || value >= _buttonLayout.Children.Count)
                {
                    return;
                }

                SetSelectedState(value, true);
            }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<string> Items
        {
            get => (List<string>) GetValue(ItemsPropertyProperty);
            set
            {
                SetValue(ItemsPropertyProperty, value);

                foreach (var item in Items)
                {
                    AddButton(item);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ButtonGroup"/> is rounded.
        /// </summary>
        /// <value><c>true</c> if rounded; otherwise, <c>false</c>.</value>
        public bool Rounded
        {
            get => (bool) GetValue(RoundedProperty);
            set => SetValue(RoundedProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is number.
        /// </summary>
        /// <value><c>true</c> if this instance is number; otherwise, <c>false</c>.</value>
        public bool IsNumber
        {
            get => (bool) GetValue(IsNumberProperty);
            set => SetValue(IsNumberProperty, value);
        }

        #endregion

        /// <summary>
        /// The clicked command
        /// </summary>
        private readonly Command _clickedCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonGroup"/> class.
        /// </summary>
        public ButtonGroup()
        {
            _buttonLayout = new WrapLayout
            {
                Spacing = DefaultSpacing,
                Padding = DefaultPadding,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Center;
            //Padding = new Thickness(Spacing);
            Content = _buttonLayout;
            _clickedCommand = new Command(SetSelectedButton);
        }

        /// <summary>
        /// Adds the button.
        /// </summary>
        /// <param name="text">The text.</param>
        public void AddButton(string text)
        {
            var button = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = ItemBackgroundColor,
                BorderColor = BorderColor,
                TextColor = TextColor,
                BorderWidth = DefaultButtonBorderWidth,
                CornerRadius =
                    Rounded
                        ? BorderRadius
                        : 0,
                //HeightRequest = Device.OnPlatform(defaultButon, BUTTON_HEIGHT, BUTTON_HEIGHT_WP),
                //MinimumHeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP),
                Font = Font,
                Command = _clickedCommand,
                CommandParameter = _buttonLayout.Children.Count,
            };

            if (IsNumber)
            {
                button.Text = $"{text}";
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        button.WidthRequest = 44;
                        button.MinimumWidthRequest = 44;
                        break;
                    case Device.Android:
                        button.WidthRequest = 44;
                        button.MinimumWidthRequest = 44;
                        break;
                    case Device.UWP:
                        button.WidthRequest = 72;
                        button.MinimumWidthRequest = 72;
                        break;
                }
            }
            else
            {
                button.Text = $"  {text}  ";
            }

            var frame = new ContentView
            {
                BackgroundColor = ViewBackgroundColor,
                Padding = DefaultFramePadding,
                //OutlineColor = OutlineColor,
                //HasShadow = false,
                Content = button,
            };

            _buttonLayout.Children.Add(frame);

            SetSelectedState(_buttonLayout.Children.Count - 1, _buttonLayout.Children.Count - 1 == SelectedIndex);
        }

        /// <summary>
        /// Sets the selected button.
        /// </summary>
        /// <param name="o">The o.</param>
        private void SetSelectedButton(object o)
        {
            SelectedIndex = (int) o;
        }

        /// <summary>
        /// Sets the state of the selected.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="isSelected">if set to <c>true</c> [is selected].</param>
        private void SetSelectedState(int index, bool isSelected)
        {
            if (index < 0 || _buttonLayout.Children.Count <= index)
            {
                return; //Out of bounds
            }

            var frame = (ContentView) _buttonLayout.Children[index];

            //frame.HasShadow = isSelected;

            frame.BackgroundColor = isSelected ? SelectedFrameBackgroundColor : ViewBackgroundColor;

            var button = (Button) frame.Content;

            button.BackgroundColor = isSelected ? SelectedBackgroundColor : ItemBackgroundColor;
            button.TextColor = isSelected ? SelectedTextColor : TextColor;
            button.BorderColor = isSelected ? SelectedBorderColor : BorderColor;
        }
    }
}