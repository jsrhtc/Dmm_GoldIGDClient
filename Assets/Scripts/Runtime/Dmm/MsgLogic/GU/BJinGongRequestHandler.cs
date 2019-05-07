﻿using com.morln.game.gd.command;
using Dmm.DataContainer;
using Dmm.Msg;
using UnityEngine;

namespace Dmm.MsgLogic.GU
{
    public class BJinGongRequestHandler : MessageHandlerAdapter<BJinGongRequest>
    {
        private readonly IDataContainer<PlayingData> _playingData;

        public BJinGongRequestHandler(IDataRepository dataRepository) :
            base(Server.GServer, Msg.CmdType.GU.B_JINGONG_REQUEST_V6)
        {
            _playingData = dataRepository.GetContainer<PlayingData>(DataKey.PlayingData);
        }

        protected override void DoHandle(BJinGongRequest msg)
        {
            var msgPlayingData = msg.playing_data;
            if (msgPlayingData != null)
            {
                _playingData.Write(msgPlayingData, Time.time);
            }
        }
    }
}