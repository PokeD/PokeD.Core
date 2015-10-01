﻿using System;

using PokeD.Core.Wrappers;

namespace PokeD.Core.Packets
{
    public static class SCONResponse
    {
        public delegate ProtobufPacket CreatePacketInstance();

        public static readonly CreatePacketInstance[] Packets;

        static SCONResponse()
        {
            var typeNames = Enum.GetValues(typeof(SCONPacketTypes));
            Packets = new CreatePacketInstance[typeNames.Length];

            foreach (SCONPacketTypes packetName in typeNames)
            {
                var name = $"{packetName}Packet";

                var packet = AppDomainWrapper.GetTypeFromNameAndAbstract<ProtobufPacket>(name);
                Packets[(int) packetName] = () => packet;
            }
        }
    }
}
