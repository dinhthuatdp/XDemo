﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XDemo.Droid.Renderers.ExtendedElements;

[assembly: ExportRenderer(typeof(XDemo.UI.Controls.ExtendedElements.RadioButton.RadioButton), typeof(RadioButtonRenderer))]
namespace XDemo.Droid.Renderers.ExtendedElements
{
    //  using NativeRadioButton = RadioButton;

    /// <summary>
    /// Class RadioButtonRenderer.
    /// </summary>
    public class RadioButtonRenderer : ViewRenderer<UI.Controls.ExtendedElements.RadioButton.RadioButton, RadioButton>
    {
        private ColorStateList _defaultTextColor;

        public RadioButtonRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<UI.Controls.ExtendedElements.RadioButton.RadioButton> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var radButton = new RadioButton(Context);
                _defaultTextColor = radButton.TextColors;

                radButton.CheckedChange += radButton_CheckedChange;

                SetNativeControl(radButton);
            }

            Control.Text = e.NewElement.Text;
            //Control.TextSize = 14;
            Control.Checked = e.NewElement.Checked;
            UpdateTextColor();

            if (e.NewElement.FontSize > 0)
            {
                Control.TextSize = (float)e.NewElement.FontSize;
            }

            if (!string.IsNullOrEmpty(e.NewElement.FontName))
            {
                Control.Typeface = TrySetFont(e.NewElement.FontName);
            }
        }

        /// <summary>
        /// Handles the CheckedChange event of the radButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CompoundButton.CheckedChangeEventArgs"/> instance containing the event data.</param>
        private void radButton_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.Checked = e.IsChecked;
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(UI.Controls.ExtendedElements.RadioButton.RadioButton.Checked):
                    Control.Checked = Element.Checked;
                    break;
                case nameof(UI.Controls.ExtendedElements.RadioButton.RadioButton.Text):
                    Control.Text = Element.Text;
                    break;
                case nameof(UI.Controls.ExtendedElements.RadioButton.RadioButton.TextColor):
                    UpdateTextColor();
                    break;
                case nameof(UI.Controls.ExtendedElements.RadioButton.RadioButton.FontName):
                    if (!string.IsNullOrEmpty(Element.FontName))
                    {
                        Control.Typeface = TrySetFont(Element.FontName);
                    }
                    break;
                case nameof(UI.Controls.ExtendedElements.RadioButton.RadioButton.FontSize) :
                    if (Element.FontSize > 0)
                    {
                        Control.TextSize = (float)Element.FontSize;
                    }
                    break;
            }
        }

        /// <summary>
        ///     Tries the set font.
        /// </summary>
        /// <param name="fontName">Name of the font.</param>
        /// <returns>Typeface.</returns>
        private Typeface TrySetFont(string fontName)
        {
            var tf = Typeface.Default;

            try
            {
                tf = Typeface.CreateFromAsset(Context.Assets, fontName);

                return tf;
            }
            catch (Exception ex)
            {
                Console.Write("not found in assets {0}", ex);
                try
                {
                    tf = Typeface.CreateFromFile(fontName);

                    return tf;
                }
                catch (Exception ex1)
                {
                    Console.Write(ex1);

                    return Typeface.Default;
                }
            }
        }

        /// <summary>
        /// Updates the color of the text
        /// </summary>
        private void UpdateTextColor()
        {
            if (Control == null || Element == null)
                return;

            if (Element.TextColor == Xamarin.Forms.Color.Default)
                Control.SetTextColor(_defaultTextColor);
            else
                Control.SetTextColor(Element.TextColor.ToAndroid());
        }
    }
}
