using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Baibaocao.net.Model.Entity;

namespace Baibaocao.net.DataAccess
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books {  get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DbConnection.connectionString, ServerVersion.AutoDetect(DbConnection.connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("book");
            modelBuilder.Entity<Publisher>().ToTable("publisher");
            modelBuilder.Entity<Author>().ToTable("author");
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<BookAuthor>().ToTable("bookauthor");
            modelBuilder.Entity<BookCategory>().ToTable("bookcategory");

            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherID);

            modelBuilder.Entity<BookAuthor>().HasOne(x => x.Book).WithMany(b => b.BooksAuthors).HasForeignKey(x => x.BookID);
            modelBuilder.Entity<BookAuthor>().HasOne(x => x.Author).WithMany(a => a.BookAuthors).HasForeignKey(x => x.AuthorID);

            modelBuilder.Entity<BookCategory>().HasOne(x => x.Book).WithMany(b => b.BookCategories).HasForeignKey(x => x.BookID);
            modelBuilder.Entity<BookCategory>().HasOne(x => x.Category).WithMany(c => c.bookCategories).HasForeignKey(x => x.CategoryID);

            modelBuilder.Entity<Book>().Ignore(b => b.Bookname);
        }
    }
}
