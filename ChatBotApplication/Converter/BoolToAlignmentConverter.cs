using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace POEChatBotApplication.Converters
{
    /// <summary>
    /// Converts a boolean value to a HorizontalAlignment value for chat message positioning.
    /// This converter is used in the chatbot interface to align user messages to the right
    /// and bot messages to the left, creating a typical chat bubble layout.
    /// </summary>
    /// <remarks>
    /// This class implements the IValueConverter interface and is used in XAML bindings.
    /// It supports one-way binding only (Convert is implemented, ConvertBack throws exception).
    /// </remarks>
    public class BoolToAlignmentConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a HorizontalAlignment value.
        /// </summary>
        /// <param name="value">
        /// The boolean value from the binding source.
        /// <para>True indicates the message is from the user.</para>
        /// <para>False indicates the message is from the bot.</para>
        /// </param>
        /// <param name="targetType">The type of the binding target property (should be HorizontalAlignment).</param>
        /// <param name="parameter">An optional converter parameter (not used in this implementation).</param>
        /// <param name="culture">The culture to use in the converter (not used in this implementation).</param>
        /// <returns>
        /// <para>HorizontalAlignment.Right - when value is true (user messages)</para>
        /// <para>HorizontalAlignment.Left - when value is false (bot messages)</para>
        /// </returns>
        /// <remarks>
        /// This creates a chat-style layout where:
        /// - User messages appear on the right side (sent messages)
        /// - Bot messages appear on the left side (received messages)
        /// </remarks>
        /// <example>
        /// In XAML:
        /// <code>
        /// &lt;TextBlock Text="{Binding Message}"
        ///            HorizontalAlignment="{Binding IsUser, Converter={StaticResource BoolToAlignmentConverter}}"/&gt;
        /// </code>
        /// </example>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Align user messages to the right, bot messages to the left
            // User message = right alignment (like sent messages in chat apps)
            // Bot message = left alignment (like received messages)
            return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        /// <summary>
        /// Converts a HorizontalAlignment value back to a boolean value.
        /// This method is not implemented because the conversion is one-way only.
        /// </summary>
        /// <param name="value">The HorizontalAlignment value from the binding target.</param>
        /// <param name="targetType">The type to convert to (should be boolean).</param>
        /// <param name="parameter">An optional converter parameter (not used).</param>
        /// <param name="culture">The culture to use in the converter (not used).</param>
        /// <returns>This method does not return a value.</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown because two-way binding is not supported by this converter.
        /// The alignment is derived from the message sender type, not the other way around.
        /// </exception>
        /// <remarks>
        /// ConvertBack is intentionally not implemented because:
        /// 1. The alignment is determined by who sent the message (user/bot)
        /// 2. Changing alignment shouldn't change the message sender type
        /// 3. This converter is designed for one-way binding only
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
