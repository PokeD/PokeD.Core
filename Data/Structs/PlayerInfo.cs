﻿using System;

using PokeD.Core.Interfaces;

namespace PokeD.Core.Data.Structs
{
    public class PlayerInfo
    {
        public string Name { get; set; }
        public uint GameJoltID { get; set; }
        public string IP { get; set; }
        public ushort Ping { get; set; }
        public Vector3 Position { get; set; }
        public string LevelFile { get; set; }
    }

    public class PlayerInfoList
    {
        public int Length => _entries.Length;

        private PlayerInfo[] _entries;

        public PlayerInfoList(int length = 0)
        {
            _entries = new PlayerInfo[length];
        }

        public PlayerInfo this[int index]
        {
            get
            {
                if (_entries.Length < index + 1)
                    return null;

                return _entries[index];
            }
            set
            {
                if (_entries.Length < index + 1)
                    Array.Resize(ref _entries, index + 1);

                _entries[index] = value;
            }
        }

        public static PlayerInfoList FromReader(IPacketDataReader reader)
        {
            var count = reader.ReadVarInt();

            var value = new PlayerInfoList();
            for (var i = 0; i < count; i++)
                value[i] = new PlayerInfo
                {
                    Name = reader.ReadString(),
                    GameJoltID = reader.ReadUInt(),
                    IP = reader.ReadString(),
                    Ping = reader.ReadUShort(),
                    Position = Vector3.FromReaderByte(reader),
                    LevelFile = reader.ReadString()
                };


            return value;
        }

        public void ToStream(IPacketStream stream)
        {
            stream.WriteVarInt(Length);

            foreach (var entry in _entries)
            {
                stream.WriteString(entry.Name);
                stream.WriteUInt(entry.GameJoltID);
                stream.WriteString(entry.IP);
                stream.WriteUShort(entry.Ping);
                entry.Position.ToStreamByte(stream);
                stream.WriteString(entry.LevelFile);
            }
        }
    }
}