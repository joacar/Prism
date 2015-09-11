﻿using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Forms.Tests.Mocks;
using Prism.Services;
using Xunit;
using Xunit.Sdk;

namespace Prism.Forms.Tests
{
    public class PopupServiceFixture
    {

        [Fact]
        public async Task DisplayActionSheetExtensionNoButtons_ShouldThrowException()
        {
            var service = new PageDialogServiceMock("cancel");
            var argumentException = await Assert.ThrowsAsync<ArgumentException>(() => service.DisplayActionSheet(null, null));
            Assert.Equal(typeof(ArgumentException), argumentException.GetType());
        }

        [Fact]
        public async Task DisplayActionSheetExtension_CancelButtonPressed()
        {
            var service = new PageDialogServiceMock("cancel");
            var cancelButtonPressed = false;
            var cancelCommand = new DelegateCommand(() => cancelButtonPressed = true);
            var button = ActionSheetButton.CreateCancelButton("cancel", cancelCommand);
            await service.DisplayActionSheet(null, button);
            Assert.True(cancelButtonPressed);
        }

        [Fact]
        public async Task DisplayActionSheetExtension_DestroyButtonPressed()
        {
            var service = new PageDialogServiceMock("destroy");
            var destroyButtonPressed = false;
            var cancelCommand = new DelegateCommand(() => destroyButtonPressed = false);
            var button = ActionSheetButton.CreateCancelButton("cancel", cancelCommand);
            var destroyCommand = new DelegateCommand(() => destroyButtonPressed = true);
            var destroyButton = ActionSheetButton.CreateDestroyButton("destroy", destroyCommand);
            await service.DisplayActionSheet(null, button, destroyButton);
            Assert.True(destroyButtonPressed);
        }

        /// <summary>
        /// TODO: Is this test valid?
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DisplayActionSheetExtension_NoButtonPressed()
        {
            var service = new PageDialogServiceMock(null);
            var buttonPressed = false;
            var cancelCommand = new DelegateCommand(() => buttonPressed = true);
            var button = ActionSheetButton.CreateCancelButton("cancel", cancelCommand);
            var destroyCommand = new DelegateCommand(() => buttonPressed = true);
            var destroyButton = ActionSheetButton.CreateDestroyButton("destroy", destroyCommand);
            await service.DisplayActionSheet(null, button, destroyButton);
            Assert.False(buttonPressed);
        }

        [Fact]
        public async Task DisplayActionSheetExtension_OtherButtonPressed()
        {
            var service = new PageDialogServiceMock("other");
            var buttonPressed = false;
            var command = new DelegateCommand(() => buttonPressed = true);
            var button = ActionSheetButton.CreateButton("other", command);
            await service.DisplayActionSheet(null, button);
            Assert.True(buttonPressed);
        }

        [Fact]
        public async Task DisplayActionSheetExtension_NullButtonAndOtherButtonPressed()
        {
            var service = new PageDialogServiceMock("other");
            var buttonPressed = false;
            var command = new DelegateCommand(() => buttonPressed = true);
            var button = ActionSheetButton.CreateButton("other", command);
            await service.DisplayActionSheet(null, button, null);
            Assert.True(buttonPressed);
        }
    }
}
