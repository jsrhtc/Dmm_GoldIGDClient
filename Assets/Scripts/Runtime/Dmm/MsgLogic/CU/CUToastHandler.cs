﻿using Dmm.Constant;
using Dmm.Dialog;
using Dmm.Msg;

namespace Dmm.MsgLogic.CU
{
    public class CUToastHandler : MessageHandlerAdapter<com.morln.game.gd.command.Toast>
    {
        private readonly IDialogManager _dialogManager;

        public CUToastHandler(IDialogManager dialogManager)
            : base(Server.GServer, Msg.CmdType.CU.TOAST_V6)
        {
            _dialogManager = dialogManager;
        }

        protected override void DoHandle(com.morln.game.gd.command.Toast msg)
        {
            var text = msg.content;
            if (string.IsNullOrEmpty(text))
                return;

            switch (msg.type)
            {
                case ToastType.Normal:
                    _dialogManager.ShowToast(text, 3);
                    break;

                case ToastType.Error:
                    _dialogManager.ShowToast(text, 3, true);
                    break;

                case ToastType.MessageBox:
                    _dialogManager.ShowMessageBox(text);
                    break;

                case ToastType.ConfirmBox:
                    _dialogManager.ShowConfirmBox(text);
                    break;
            }
        }
    }
}