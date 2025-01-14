﻿// <auto-generated />
using System;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookStore.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20250114030244_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "George Orwell",
                            PublicationDate = new DateTime(1949, 6, 7, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 5,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 2,
                            Author = "J.K. Rowling",
                            PublicationDate = new DateTime(1997, 6, 25, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 7,
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            Id = 3,
                            Author = "J.R.R. Tolkien",
                            PublicationDate = new DateTime(1937, 9, 20, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 3,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Harper Lee",
                            PublicationDate = new DateTime(1960, 7, 10, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 8,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 5,
                            Author = "F. Scott Fitzgerald",
                            PublicationDate = new DateTime(1925, 4, 9, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 2,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Jane Austen",
                            PublicationDate = new DateTime(1813, 1, 27, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 6,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Markus Zusak",
                            PublicationDate = new DateTime(2005, 3, 13, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 4,
                            Title = "The Book Thief"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Gabriel Garcia Marquez",
                            PublicationDate = new DateTime(1967, 5, 29, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 9,
                            Title = "One Hundred Years of Solitude"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Herman Melville",
                            PublicationDate = new DateTime(1851, 10, 17, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 1,
                            Title = "Moby Dick"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Leo Tolstoy",
                            PublicationDate = new DateTime(1868, 12, 31, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 7,
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Ernest Hemingway",
                            PublicationDate = new DateTime(1952, 8, 31, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 3,
                            Title = "The Old Man and the Sea"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Charles Dickens",
                            PublicationDate = new DateTime(1861, 1, 12, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 5,
                            Title = "Great Expectations"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Virginia Woolf",
                            PublicationDate = new DateTime(1847, 10, 15, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 4,
                            Title = "Jane Eyre"
                        },
                        new
                        {
                            Id = 14,
                            Author = "Franz Kafka",
                            PublicationDate = new DateTime(1915, 12, 18, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 6,
                            Title = "The Metamorphosis"
                        },
                        new
                        {
                            Id = 15,
                            Author = "John Steinbeck",
                            PublicationDate = new DateTime(1937, 2, 5, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 2,
                            Title = "Of Mice and Men"
                        },
                        new
                        {
                            Id = 16,
                            Author = "Oscar Wilde",
                            PublicationDate = new DateTime(1890, 5, 11, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 8,
                            Title = "The Picture of Dorian Gray"
                        },
                        new
                        {
                            Id = 17,
                            Author = "Agatha Christie",
                            PublicationDate = new DateTime(1934, 11, 19, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 7,
                            Title = "Murder on the Orient Express"
                        },
                        new
                        {
                            Id = 18,
                            Author = "Arthur Conan Doyle",
                            PublicationDate = new DateTime(1887, 2, 28, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 5,
                            Title = "A Study in Scarlet"
                        },
                        new
                        {
                            Id = 19,
                            Author = "Emily Bronte",
                            PublicationDate = new DateTime(1847, 12, 23, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 3,
                            Title = "Wuthering Heights"
                        },
                        new
                        {
                            Id = 20,
                            Author = "Charlotte Bronte",
                            PublicationDate = new DateTime(1847, 10, 15, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 6,
                            Title = "Jane Eyre"
                        },
                        new
                        {
                            Id = 21,
                            Author = "George Orwell",
                            PublicationDate = new DateTime(1949, 6, 7, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 4,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 22,
                            Author = "J.K. Rowling",
                            PublicationDate = new DateTime(1998, 7, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 9,
                            Title = "Harry Potter and the Chamber of Secrets"
                        },
                        new
                        {
                            Id = 23,
                            Author = "J.R.R. Tolkien",
                            PublicationDate = new DateTime(1954, 7, 28, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 2,
                            Title = "The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = 24,
                            Author = "Harper Lee",
                            PublicationDate = new DateTime(1960, 7, 10, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 8,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 25,
                            Author = "F. Scott Fitzgerald",
                            PublicationDate = new DateTime(1934, 4, 11, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 1,
                            Title = "Tender is the Night"
                        },
                        new
                        {
                            Id = 26,
                            Author = "Jane Austen",
                            PublicationDate = new DateTime(1811, 10, 29, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 7,
                            Title = "Sense and Sensibility"
                        },
                        new
                        {
                            Id = 27,
                            Author = "Markus Zusak",
                            PublicationDate = new DateTime(2002, 7, 31, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 3,
                            Title = "The Messenger"
                        },
                        new
                        {
                            Id = 28,
                            Author = "Gabriel Garcia Marquez",
                            PublicationDate = new DateTime(1981, 5, 18, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 5,
                            Title = "Chronicle of a Death Foretold"
                        },
                        new
                        {
                            Id = 29,
                            Author = "Herman Melville",
                            PublicationDate = new DateTime(1924, 10, 11, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 4,
                            Title = "Billy Budd, Sailor"
                        },
                        new
                        {
                            Id = 30,
                            Author = "Leo Tolstoy",
                            PublicationDate = new DateTime(1878, 3, 31, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 6,
                            Title = "Anna Karenina"
                        },
                        new
                        {
                            Id = 31,
                            Author = "Ernest Hemingway",
                            PublicationDate = new DateTime(1929, 9, 26, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 2,
                            Title = "A Farewell to Arms"
                        },
                        new
                        {
                            Id = 32,
                            Author = "Charles Dickens",
                            PublicationDate = new DateTime(1839, 1, 15, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 8,
                            Title = "Oliver Twist"
                        },
                        new
                        {
                            Id = 33,
                            Author = "Virginia Woolf",
                            PublicationDate = new DateTime(1927, 5, 4, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 7,
                            Title = "To the Lighthouse"
                        },
                        new
                        {
                            Id = 34,
                            Author = "Franz Kafka",
                            PublicationDate = new DateTime(1925, 8, 14, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 1,
                            Title = "The Trial"
                        },
                        new
                        {
                            Id = 35,
                            Author = "John Steinbeck",
                            PublicationDate = new DateTime(1939, 4, 13, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 9,
                            Title = "The Grapes of Wrath"
                        },
                        new
                        {
                            Id = 36,
                            Author = "Oscar Wilde",
                            PublicationDate = new DateTime(1888, 12, 19, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 3,
                            Title = "The Happy Prince and Other Stories"
                        },
                        new
                        {
                            Id = 37,
                            Author = "Agatha Christie",
                            PublicationDate = new DateTime(1936, 1, 5, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 5,
                            Title = "The ABC Murders"
                        },
                        new
                        {
                            Id = 38,
                            Author = "Arthur Conan Doyle",
                            PublicationDate = new DateTime(1902, 3, 31, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 4,
                            Title = "The Hound of the Baskervilles"
                        },
                        new
                        {
                            Id = 39,
                            Author = "Emily Bronte",
                            PublicationDate = new DateTime(1846, 1, 19, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 6,
                            Title = "Poems by Currer, Ellis, and Acton Bell"
                        },
                        new
                        {
                            Id = 40,
                            Author = "Charlotte Bronte",
                            PublicationDate = new DateTime(1853, 12, 15, 17, 0, 0, 0, DateTimeKind.Utc),
                            Quantity = 2,
                            Title = "Villette"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
