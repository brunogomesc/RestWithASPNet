using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Data.Converter.Contract
{
    public interface IParse<O,D>
    {

        D Parse(O origin);

        List<D> Parse(List<O> origin);

    }
}
