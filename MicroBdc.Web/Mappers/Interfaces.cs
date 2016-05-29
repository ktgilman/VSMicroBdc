using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBdc.Web.Mappers
{
    public interface IMapToNew<TSource, TTarget>
    {
        TTarget Map(TSource source);
    }

    public interface IMapToExisting<TSource, TTarget>
    {
        void Map(TSource source, TTarget target);
    }
}
