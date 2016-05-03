﻿using NUnit.Framework;

using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Test
{
    [TestFixture]
    public class MonsterCachedTest
    {
        public MonsterCachedTest()
        {
            PokeApiV2.CacheData = true;
        }


        [Test]
        public void TestMonsterDataItems() { MonsterClass.MonsterDataItems(); }

        [Test]
        public void TestLoadStaticData() { MonsterClass.LoadStaticData(); }
    }
}