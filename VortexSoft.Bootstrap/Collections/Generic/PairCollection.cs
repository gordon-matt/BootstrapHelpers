using System.Collections.Generic;

namespace VortexSoft.Bootstrap.Collections.Generic
{
    internal class PairCollection<TFirst, TSecond> : List<Pair<TFirst, TSecond>>
    {
        public void Add(TFirst first, TSecond second)
        {
            this.Add(new Pair<TFirst, TSecond>
            {
                First = first,
                Second = second
            });
        }
    }
}