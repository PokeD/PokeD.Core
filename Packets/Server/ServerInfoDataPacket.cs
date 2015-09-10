﻿using System.Collections.Generic;

using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class ServerInfoDataPacket : Packet
    {
        public int CurrentPlayers { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public int MaxPlayers { get { return int.Parse(DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
        public string ServerName { get { return DataItems[2]; } set { DataItems[2] = value; } }
        public string ServerMessage { get { return DataItems[3]; } set { DataItems[3] = value; } }
        public string[] PlayerNames
        {
            get
            {
                if (DataItems.Count > 4)
                {
                    var list = new List<string>();
                    for (var i = 4; i < DataItems.Count; i++)
                        list.Add(DataItems[i]);

                    return list.ToArray();
                }

                return null;
            }
            set
            {
                if (value != null)
                {
                    for (var i = 0; i < value.Length; i++)
                        DataItems[4 + i] = value[i];
                }
            }
        }


        public override int ID => (int) PlayerPacketTypes.ServerInfoData;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            CurrentPlayers = reader.ReadVarInt();
            MaxPlayers = reader.ReadVarInt();
            ServerName = reader.ReadString();
            ServerMessage = reader.ReadString();
            PlayerNames = reader.ReadStringArray(reader.BytesLeft());

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteVarInt(CurrentPlayers);
            writer.WriteVarInt(MaxPlayers);
            writer.WriteString(ServerName);
            writer.WriteString(ServerMessage);
            writer.WriteStringArray(PlayerNames);

            return this;
        }
    }
}
