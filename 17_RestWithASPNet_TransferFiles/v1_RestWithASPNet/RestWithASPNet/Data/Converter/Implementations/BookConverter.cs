using RestWithASPNet.Data.Converter.Contract;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Data.Converter.Implementations
{
    public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {

            if (origin == null) return null;

            return new Book
            {

                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title

            };

        }

        public List<Book> Parse(List<BookVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

        public BookVO Parse(Book origin)
        {

            if (origin == null) return null;

            return new BookVO
            {

                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title

            };

        }

        public List<BookVO> Parse(List<Book> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
