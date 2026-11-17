using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;

namespace Lab7
{
    internal class MySqlRepository : ILibraryRepository
    {
        private string connectionString;
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public MySqlRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private MySqlConnection CreateConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            //conn.Open();

            return conn;
        }

        // The shared SELECT + LEFT JOIN SQL used by all read methods
        // An optional WHERE clause is appended by each calling method
        private const string BASE_SELECT_SQL =
            @"SELECT
                li.item_id,
                li.title,
                li.author,
                li.publication_year,
                li.is_available,
                li.borrowed_date,
                li.item_type,
                b.isbn  AS book_isbn,
                b.publisher,
                b.page_count,
                b.genre,
                e.isbn  AS ebook_isbn,
                e.download_url,
                e.file_format,
                e.file_size_mb,
                e.download_limit
            FROM library_items li
            LEFT JOIN books  b ON b.item_id = li.item_id
            LEFT JOIN ebooks e ON e.item_id = li.item_id";

        // -----------------------
        // ID generation (simple)
        // -----------------------
        private string GenerateItemId(LibraryItem item)
        {
            // NOTE: This uses DB to find the next numeric suffix per prefix.
            // It’s safe enough for this exercise; for production use,
            // use an AUTO_INCREMENT key or a separate sequence table.

            string prefix = "I";
            if (item is Book) prefix = "B";
            else if (item is EBook) prefix = "E";

            int next = GetNextIdNumber(prefix);
            return prefix + next.ToString("D4");
        }

        private int GetNextIdNumber(string prefix)
        {
            // Looks for existing IDs like B0001 and returns max+1. For your coursework, you can use Auto Increment for simplicity
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"SELECT COALESCE(MAX(CAST(SUBSTRING(item_id, 2) AS UNSIGNED)), 0)
                          FROM library_items
                          WHERE item_id LIKE CONCAT(@prefix, '%');";

                    cmd.Parameters.AddWithValue("@prefix", prefix);

                    int max = Convert.ToInt32(cmd.ExecuteScalar());
                    return max + 1;
                }
            }
        }

        public void Add(LibraryItem item)
        {
            if (item == null) throw new Exception("Item cannot be null");

            if (string.IsNullOrWhiteSpace(item.ItemID))
                item.ItemID = GenerateItemId(item);

            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Base insert
                        using (MySqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.Transaction = tx;
                            cmd.CommandText =
                                @"INSERT INTO library_items
                                  (item_id, title, author, publication_year, is_available, borrowed_date, item_type)
                                  VALUES
                                  (@item_id, @title, @author, @year, @is_available, @borrowed_date, @item_type);";

                            cmd.Parameters.AddWithValue("@item_id", item.ItemID);
                            cmd.Parameters.AddWithValue("@title", item.Title);
                            cmd.Parameters.AddWithValue("@author", item.Author);
                            cmd.Parameters.AddWithValue("@year", item.PublicationYear);
                            cmd.Parameters.AddWithValue("@is_available", item.IsAvailable ? 1 : 0);
                            cmd.Parameters.AddWithValue("@borrowed_date",
                                item.BorrowedDate.HasValue ? item.BorrowedDate.Value : (object)DBNull.Value);

                            if (item is Book) cmd.Parameters.AddWithValue("@item_type", "BOOK");
                            else if (item is EBook) cmd.Parameters.AddWithValue("@item_type", "EBOOK");
                            else throw new Exception("Unsupported item type");

                            cmd.ExecuteNonQuery();
                        }

                        // Derived insert
                        if (item is Book book)
                        {
                            using (MySqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = tx;
                                cmd.CommandText =
                                    @"INSERT INTO books
                                      (item_id, isbn, publisher, page_count, genre)
                                      VALUES
                                      (@item_id, @isbn, @publisher, @page_count, @genre);";

                                cmd.Parameters.AddWithValue("@item_id", item.ItemID);
                                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                                cmd.Parameters.AddWithValue("@page_count", book.PageCount);
                                cmd.Parameters.AddWithValue("@genre", book.Genre);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (item is EBook ebook)
                        {
                            using (MySqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = tx;
                                cmd.CommandText =
                                    @"INSERT INTO ebooks
                                      (item_id, isbn, download_url, file_format, file_size_mb, download_limit)
                                      VALUES
                                      (@item_id, @isbn, @download_url, @file_format, @file_size_mb, @download_limit);";

                                cmd.Parameters.AddWithValue("@item_id", item.ItemID);
                                cmd.Parameters.AddWithValue("@isbn", ebook.ISBN);
                                cmd.Parameters.AddWithValue("@download_url", ebook.DownloadURL);
                                cmd.Parameters.AddWithValue("@file_format", ebook.FileFormat);
                                cmd.Parameters.AddWithValue("@file_size_mb", ebook.FileSizeMB);
                                cmd.Parameters.AddWithValue("@download_limit", ebook.DownloadLimit);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // LibraryManager already checks IsAvailable before calling Delete,
        // so no availability check is needed here.
        // ON DELETE CASCADE in the DB removes the books/ebooks row too.
        // Returns true if a row was deleted, false if item was not found.
        public bool Delete(string itemId)
        {
            throw new NotImplementedException();
        }

        public LibraryItem FindByID(string itemId)
        {
            throw new NotImplementedException();
        }

        public LibraryItem FindByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        //  Map a DataReader row to a Book or EBook object
        // Reused by GetAll, FindByID, FindByISBN, Search, and filtered lists
        private LibraryItem MapRowToItem(MySqlDataReader reader)
        {
            string itemId = reader.GetString("item_id");
            string title = reader.GetString("title");
            string author = reader.GetString("author");
            int year = reader.GetInt32("publication_year");
            bool isAvailable = reader.GetBoolean("is_available");
            string itemType = reader.GetString("item_type");

            // BorrowedDate can be NULL in the database
            DateTime? borrowedDate = reader.IsDBNull(reader.GetOrdinal("borrowed_date"))
                                     ? (DateTime?)null
                                     : reader.GetDateTime("borrowed_date");

            LibraryItem result;

            if (itemType == "BOOK")
            {
                string bookIsbn = reader.GetString("book_isbn");
                string publisher = reader.IsDBNull(reader.GetOrdinal("publisher"))
                                       ? "" : reader.GetString("publisher");
                int pageCount = reader.IsDBNull(reader.GetOrdinal("page_count"))
                                       ? 0 : reader.GetInt32("page_count");
                string genre = reader.IsDBNull(reader.GetOrdinal("genre"))
                                       ? "" : reader.GetString("genre");

                result = new Book(itemId, bookIsbn, title, author, year,
                                  publisher, pageCount, genre);
            }
            else // EBOOK
            {
                string ebookIsbn = reader.GetString("ebook_isbn");
                string downloadUrl = reader.IsDBNull(reader.GetOrdinal("download_url"))
                                       ? "" : reader.GetString("download_url");
                string fileFormat = reader.IsDBNull(reader.GetOrdinal("file_format"))
                                       ? "" : reader.GetString("file_format");
                double fileSizeMb = reader.IsDBNull(reader.GetOrdinal("file_size_mb"))
                                       ? 0 : reader.GetDouble("file_size_mb");

                result = new EBook(itemId, ebookIsbn, title, author, year,
                                   downloadUrl, fileFormat, fileSizeMb);
            }

            // Apply borrow status to the created object
            result.IsAvailable = isAvailable;
            result.BorrowedDate = borrowedDate;

            return result;
        }

        public List<LibraryItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> results = new List<Book>();

            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql =
                    @"SELECT
                        li.item_id,
                        li.title,
                        li.author,
                        li.publication_year,
                        li.is_available,
                        li.borrowed_date,
                        li.item_type,
                        b.isbn  AS book_isbn,
                        b.publisher,
                        b.page_count,
                        b.genre,
                        NULL AS ebook_isbn,
                        NULL AS download_url,
                        NULL AS file_format,
                        NULL AS file_size_mb,
                        NULL AS download_limit
                    FROM library_items li
                    INNER JOIN books b ON b.item_id = li.item_id
                    ORDER BY li.item_id;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // MapRowToItem returns a LibraryItem; safe cast to Book
                        LibraryItem item = MapRowToItem(reader);
                        if (item is Book book)
                            results.Add(book);
                    }
                }
            }

            return results;
        }

        public List<EBook> GetAllEBooks()
        {
            throw new NotImplementedException();
        }

        public int GetAvailableCount()
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM library_items WHERE is_available = 1;";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<LibraryItem> GetAvailableItems()
        {
            throw new NotImplementedException();
        }

        public int GetBorrowedCount()
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM library_items WHERE is_available = 0;";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<LibraryItem> GetBorrowedItems()
        {
            List<LibraryItem> results = new List<LibraryItem>();

            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = BASE_SELECT_SQL +
                             " WHERE li.is_available = 0 ORDER BY li.item_id;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        results.Add(MapRowToItem(reader));
                }
            }

            return results;
        }

        public int GetCount()
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM library_items;";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int GetBookCount()
        {
            throw new NotImplementedException();
        }

        public int GetEBookCount()
        {
            throw new NotImplementedException();
        }

        public int GetNewestYear()
        {
            throw new NotImplementedException();
        }

        public int GetOldestYear()
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = "SELECT COALESCE(MIN(publication_year), 0) FROM library_items;";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        // Book  overdue period: 21 days  (matches Book.GetBorrowDuration())
        // EBook overdue period: 14 days  (matches EBook.GetBorrowDuration())
        public List<LibraryItem> GetOverdueItems()
        {
            List<LibraryItem> results = new List<LibraryItem>();

            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = BASE_SELECT_SQL +
                             @" WHERE li.is_available  = 0
                                  AND li.borrowed_date IS NOT NULL
                                  AND (
                                        (li.item_type = 'BOOK'
                                            AND li.borrowed_date < DATE_SUB(NOW(), INTERVAL 21 DAY))
                                     OR (li.item_type = 'EBOOK'
                                            AND li.borrowed_date < DATE_SUB(NOW(), INTERVAL 14 DAY))
                                      )
                                ORDER BY li.borrowed_date;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        results.Add(MapRowToItem(reader));
                }
            }

            return results;
        }

        public bool ISBNExists(string isbn)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql =
                    @"SELECT EXISTS(
                        SELECT 1 FROM books  WHERE isbn = @isbn
                        UNION ALL
                        SELECT 1 FROM ebooks WHERE isbn = @isbn
                      ) AS isbn_exists;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    long result = (long)cmd.ExecuteScalar();
                    return result == 1;
                }
            }
        }

        public List<LibraryItem> Search(string searchTerm)
        {
            List<LibraryItem> results = new List<LibraryItem>();

            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                string sql = BASE_SELECT_SQL +
                             @" WHERE LOWER(li.title)  LIKE CONCAT('%', LOWER(@term), '%')
                                   OR LOWER(li.author) LIKE CONCAT('%', LOWER(@term), '%')
                                ORDER BY li.title;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@term", searchTerm);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            results.Add(MapRowToItem(reader));
                    }
                }
            }

            return results;
        }
    }
}
