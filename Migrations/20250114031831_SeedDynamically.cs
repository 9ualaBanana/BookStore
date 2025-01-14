using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedDynamically : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "George Orwell", new DateTime(1949, 6, 7, 17, 0, 0, 0, DateTimeKind.Utc), 5, "1984" },
                    { 2, "J.K. Rowling", new DateTime(1997, 6, 25, 17, 0, 0, 0, DateTimeKind.Utc), 7, "Harry Potter and the Sorcerer's Stone" },
                    { 3, "J.R.R. Tolkien", new DateTime(1937, 9, 20, 17, 0, 0, 0, DateTimeKind.Utc), 3, "The Hobbit" },
                    { 4, "Harper Lee", new DateTime(1960, 7, 10, 17, 0, 0, 0, DateTimeKind.Utc), 8, "To Kill a Mockingbird" },
                    { 5, "F. Scott Fitzgerald", new DateTime(1925, 4, 9, 17, 0, 0, 0, DateTimeKind.Utc), 2, "The Great Gatsby" },
                    { 6, "Jane Austen", new DateTime(1813, 1, 27, 17, 0, 0, 0, DateTimeKind.Utc), 6, "Pride and Prejudice" },
                    { 7, "Markus Zusak", new DateTime(2005, 3, 13, 17, 0, 0, 0, DateTimeKind.Utc), 4, "The Book Thief" },
                    { 8, "Gabriel Garcia Marquez", new DateTime(1967, 5, 29, 17, 0, 0, 0, DateTimeKind.Utc), 9, "One Hundred Years of Solitude" },
                    { 9, "Herman Melville", new DateTime(1851, 10, 17, 17, 0, 0, 0, DateTimeKind.Utc), 1, "Moby Dick" },
                    { 10, "Leo Tolstoy", new DateTime(1868, 12, 31, 17, 0, 0, 0, DateTimeKind.Utc), 7, "War and Peace" },
                    { 11, "Ernest Hemingway", new DateTime(1952, 8, 31, 17, 0, 0, 0, DateTimeKind.Utc), 3, "The Old Man and the Sea" },
                    { 12, "Charles Dickens", new DateTime(1861, 1, 12, 17, 0, 0, 0, DateTimeKind.Utc), 5, "Great Expectations" },
                    { 13, "Virginia Woolf", new DateTime(1847, 10, 15, 17, 0, 0, 0, DateTimeKind.Utc), 4, "Jane Eyre" },
                    { 14, "Franz Kafka", new DateTime(1915, 12, 18, 17, 0, 0, 0, DateTimeKind.Utc), 6, "The Metamorphosis" },
                    { 15, "John Steinbeck", new DateTime(1937, 2, 5, 17, 0, 0, 0, DateTimeKind.Utc), 2, "Of Mice and Men" },
                    { 16, "Oscar Wilde", new DateTime(1890, 5, 11, 17, 0, 0, 0, DateTimeKind.Utc), 8, "The Picture of Dorian Gray" },
                    { 17, "Agatha Christie", new DateTime(1934, 11, 19, 17, 0, 0, 0, DateTimeKind.Utc), 7, "Murder on the Orient Express" },
                    { 18, "Arthur Conan Doyle", new DateTime(1887, 2, 28, 17, 0, 0, 0, DateTimeKind.Utc), 5, "A Study in Scarlet" },
                    { 19, "Emily Bronte", new DateTime(1847, 12, 23, 17, 0, 0, 0, DateTimeKind.Utc), 3, "Wuthering Heights" },
                    { 20, "Charlotte Bronte", new DateTime(1847, 10, 15, 17, 0, 0, 0, DateTimeKind.Utc), 6, "Jane Eyre" },
                    { 21, "George Orwell", new DateTime(1949, 6, 7, 17, 0, 0, 0, DateTimeKind.Utc), 4, "1984" },
                    { 22, "J.K. Rowling", new DateTime(1998, 7, 1, 17, 0, 0, 0, DateTimeKind.Utc), 9, "Harry Potter and the Chamber of Secrets" },
                    { 23, "J.R.R. Tolkien", new DateTime(1954, 7, 28, 17, 0, 0, 0, DateTimeKind.Utc), 2, "The Fellowship of the Ring" },
                    { 24, "Harper Lee", new DateTime(1960, 7, 10, 17, 0, 0, 0, DateTimeKind.Utc), 8, "To Kill a Mockingbird" },
                    { 25, "F. Scott Fitzgerald", new DateTime(1934, 4, 11, 17, 0, 0, 0, DateTimeKind.Utc), 1, "Tender is the Night" },
                    { 26, "Jane Austen", new DateTime(1811, 10, 29, 17, 0, 0, 0, DateTimeKind.Utc), 7, "Sense and Sensibility" },
                    { 27, "Markus Zusak", new DateTime(2002, 7, 31, 17, 0, 0, 0, DateTimeKind.Utc), 3, "The Messenger" },
                    { 28, "Gabriel Garcia Marquez", new DateTime(1981, 5, 18, 17, 0, 0, 0, DateTimeKind.Utc), 5, "Chronicle of a Death Foretold" },
                    { 29, "Herman Melville", new DateTime(1924, 10, 11, 17, 0, 0, 0, DateTimeKind.Utc), 4, "Billy Budd, Sailor" },
                    { 30, "Leo Tolstoy", new DateTime(1878, 3, 31, 17, 0, 0, 0, DateTimeKind.Utc), 6, "Anna Karenina" },
                    { 31, "Ernest Hemingway", new DateTime(1929, 9, 26, 17, 0, 0, 0, DateTimeKind.Utc), 2, "A Farewell to Arms" },
                    { 32, "Charles Dickens", new DateTime(1839, 1, 15, 17, 0, 0, 0, DateTimeKind.Utc), 8, "Oliver Twist" },
                    { 33, "Virginia Woolf", new DateTime(1927, 5, 4, 17, 0, 0, 0, DateTimeKind.Utc), 7, "To the Lighthouse" },
                    { 34, "Franz Kafka", new DateTime(1925, 8, 14, 17, 0, 0, 0, DateTimeKind.Utc), 1, "The Trial" },
                    { 35, "John Steinbeck", new DateTime(1939, 4, 13, 17, 0, 0, 0, DateTimeKind.Utc), 9, "The Grapes of Wrath" },
                    { 36, "Oscar Wilde", new DateTime(1888, 12, 19, 17, 0, 0, 0, DateTimeKind.Utc), 3, "The Happy Prince and Other Stories" },
                    { 37, "Agatha Christie", new DateTime(1936, 1, 5, 17, 0, 0, 0, DateTimeKind.Utc), 5, "The ABC Murders" },
                    { 38, "Arthur Conan Doyle", new DateTime(1902, 3, 31, 17, 0, 0, 0, DateTimeKind.Utc), 4, "The Hound of the Baskervilles" },
                    { 39, "Emily Bronte", new DateTime(1846, 1, 19, 17, 0, 0, 0, DateTimeKind.Utc), 6, "Poems by Currer, Ellis, and Acton Bell" },
                    { 40, "Charlotte Bronte", new DateTime(1853, 12, 15, 17, 0, 0, 0, DateTimeKind.Utc), 2, "Villette" }
                });
        }
    }
}
