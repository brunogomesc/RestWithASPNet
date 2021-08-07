using RestWithASPNet.Hypermedia;
using RestWithASPNet.Hypermedia.Abstract;
using RestWithASPNet.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNet.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string Gender { get; set; }

        public bool Enabled { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
