using RestWithASPNet.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNet.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
