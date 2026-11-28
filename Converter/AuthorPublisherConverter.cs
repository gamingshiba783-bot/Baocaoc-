using System.Collections.Generic;
using System.Linq;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.Converter
{
    public class AuthorConverter
    {
        public static AuthorDTO toDTO(Author a)
        {
            return new AuthorDTO
            {
                Ma = a.Id,
                TenTacGia = a.AuthorName ?? "",
                DiaChi = a.Address ?? "",
                NamSinh = a.BirthYear,
                SoSach = a.BookAuthors?.Count ?? 0
            };
        }

        public static List<AuthorDTO> ToDTOs(IEnumerable<Author> items) => items.Select(toDTO).ToList();

        public static Author ToEntity(AuthorDTO d)
        {
            return new Author
            {
                Id = d.Ma,
                AuthorName = d.TenTacGia.Trim(),
                Address = d.DiaChi.Trim(),
                BirthYear = d.NamSinh
            };
        }
    }

    public class PublisherConverter
    {
        public static PublisherDTO toDTO(Publisher p)
        {
            return new PublisherDTO
            {
                Ma = p.Id,
                TenNXB = p.PublisherName ?? "",
                DiaChi = p.Address ?? "",
                DienThoai = p.Phone ?? "",
                Email = p.Email ?? "",
                SoSach = p.Books?.Count ?? 0
            };
        }

        public static List<PublisherDTO> ToDTOs(IEnumerable<Publisher> items) => items.Select(toDTO).ToList();

        public static Publisher ToEntity(PublisherDTO d)
        {
            return new Publisher
            {
                Id = d.Ma,
                PublisherName = d.TenNXB.Trim(),
                Address = d.DiaChi.Trim(),
                Phone = d.DienThoai.Trim(),
                Email = d.Email.Trim()
            };
        }
    }
}
