﻿using System;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XDemo.iOS.Effects;
using XDemo.UI.Markup.Effects;

[assembly: ResolutionGroupName(UnderlineEffect.EffectNamespace)]
[assembly: ExportEffect(typeof(UnderlineIOSEffect), nameof(UnderlineEffect))]
namespace XDemo.iOS.Effects
{
    public class UnderlineIOSEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            SetUnderline(true);
        }

        protected override void OnDetached()
        {
            SetUnderline(false);
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == Label.TextProperty.PropertyName || args.PropertyName == Label.FormattedTextProperty.PropertyName)
            {
                SetUnderline(true);
            }
        }

        private void SetUnderline(bool underlined)
        {
            try
            {
                var label = (UILabel)Control;
                var text = (NSMutableAttributedString)label.AttributedText;
                var range = new NSRange(0, text.Length);

                if (underlined)
                {
                    text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
                }
                else
                {
                    text.RemoveAttribute(UIStringAttributeKey.UnderlineStyle, range);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot underline Label. Error: ", ex.Message);
            }
        }
    }
}
