using MimeKit.Cryptography;
using System.Data.SQLite;
using System.IO;

namespace Mime.DAL
{
    public class MimeContext : DefaultSecureMimeContext
    {
        public MimeContext()
            : base(OpenDatabase("C:\\Users\\tnguyen482\\source\\repos\\Mime\\Mime\\App_Data\\certdb.db"))
        {
        }

        static IX509CertificateDatabase OpenDatabase(string fileName)
        {
            var builder = new SQLiteConnectionStringBuilder();
            builder.DateTimeFormat = SQLiteDateFormats.Ticks;
            builder.DataSource = fileName;

            if (!File.Exists(fileName))
                SQLiteConnection.CreateFile(fileName);

            var sqlite = new SQLiteConnection(builder.ConnectionString);
            sqlite.Open();

            return new SqliteCertificateDatabase(sqlite, "password");
        }
    }
}