﻿using Prism.Commands;

namespace Prism.Services
{
    /// <summary>
    /// Convenient contract to enable executing commands directly when using <see cref="IActionSheetService.DisplayActionSheet"/>
    /// </summary>
    public interface IActionSheetButton
    {
        /// <summary>
        /// The button will be used as destroy
        /// </summary>
        bool IsDestroy { get; }

        /// <summary>
        /// The button will be used as cancel
        /// </summary>
        bool IsCancel { get; }

        /// <summary>
        /// Text to display in the action sheet
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Command to execute when button is pressed
        /// </summary>
        DelegateCommand Callback { get; }
    }
}