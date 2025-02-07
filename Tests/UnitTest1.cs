using DesignPatterns;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Singleton.Instance.value = 1;

            Assert.Equal(1, Singleton.Instance.value);
        }
    }
}