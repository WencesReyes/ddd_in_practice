using System.Collections;

namespace Core.Tests.MoneySpecs
{
    public class MoneyTheoryData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3, 0, 0, 0 };
            yield return new object[] { 0, 0, 0, 1, 0, 1 };
            yield return new object[] { 1, 1, 0, 0, 0, 1 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
