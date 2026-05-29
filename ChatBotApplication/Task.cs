using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEChatBotApplication
{
    /// <summary>
    /// Represents a task in the task management system.
    /// This model class is used to store and manage task data
    /// for the POEchatBotApplication.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the title of the task.
        /// This is a required field that provides a brief identifier for the task.
        /// </summary>
        /// <remarks>
        /// The title is displayed in the accent color on task cards.
        /// This field cannot be empty when creating or updating a task.
        /// </remarks>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the detailed description of the task.
        /// This is an optional field that provides additional information
        /// about what needs to be done.
        /// </summary>
        /// <remarks>
        /// The description is displayed as secondary text on task cards
        /// and can contain multiple lines of text.
        /// This field is optional and can be left empty.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date for the task completion.
        /// This field uses a DatePicker control for selection in the UI.
        /// </summary>
        /// <remarks>
        /// The reminder date is displayed with an icon indicator on task cards.
        /// This field helps users track deadlines and manage time-sensitive tasks.
        /// Default value is DateTime.MinValue if not specified.
        /// </remarks>
        public DateTime ReminderDate { get; set; }
    }
}
