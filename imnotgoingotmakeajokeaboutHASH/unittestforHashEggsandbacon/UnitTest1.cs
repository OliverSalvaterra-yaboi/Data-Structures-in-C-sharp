using System;
using Xunit;
using imnotgoingotmakeajokeaboutHASH;

namespace unittestforHashEggsandbacon
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            mapohash<string, int> socialsecurity = new mapohash<string, int>();
            socialsecurity.add("johnwick", 420);
            socialsecurity.add("datboi", 144);
            socialsecurity.add("juice", 0);
            Assert.Equal(420, socialsecurity["johnwick"]);
        }

        [Fact]
        public void Test2()
        {
            mapohash<string, int> socialsecurity = new mapohash<string, int>();
            socialsecurity.add("KeanuReeves", 420);
            socialsecurity.add("Juicewrld", 6);
            Assert.True(socialsecurity.remove("Juicewrld"));
        }

        [Fact]
        public void Test3()
        {
            mapohash<string, int> socialsecurity = new mapohash<string, int>();
            socialsecurity.add("johnwick", 420);
            socialsecurity.add("datboi", 144);
            socialsecurity.add("juice", 0);
            Assert.NotNull(socialsecurity["datboi"]);
        }

        [Fact]
        public void Test4()
        {
            mapohash<string, int> antisocialsocialsecurity = new mapohash<string, int>();
            antisocialsocialsecurity.add("johnwick", 420);
            antisocialsocialsecurity.add("datboi", 144);
            antisocialsocialsecurity.add("juice", 0);
            Assert.NotNull(antisocialsocialsecurity.enumer());
        }
    }
}
