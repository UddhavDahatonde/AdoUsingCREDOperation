using AdoUsingCREDOperation.DAL;
using System.Data.SqlClient;
namespace AdoUsingCRUDOperation.DAL
{
    public class BookDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public BookDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
        public List<Book> GetAllBook()
        {

            List<Book> books = new List<Book>();
            cmd = new SqlCommand("select * from Book", con);
            con.Open();
             dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(dr["Id"]);
                    book.Name = dr["Name"].ToString();
                    book.Price = Convert.ToDecimal(dr["Price"]);
                    book.Author = dr["Author"].ToString();
                    book.Publishar = dr["Publishar"].ToString();
                    books.Add(book);
                }

            }
            con.Close();
            return books;
        }
        public Book GetbookById(int Id)
        {
            Book book = new Book();
            string qry = "select * from Book where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    book.Id = Convert.ToInt32(dr["Id"]);
                    book.Name = dr["Name"].ToString();
                    book.Price = Convert.ToDecimal(dr["Price"]);
                    book.Author = dr["Author"].ToString();
                    book.Publishar = dr["Publishar"].ToString();
                }

            }
            con.Close();
            return book;
        }
        public int AddBook(Book book)
        {
            string qry = "insert into Book values(@Name,@Price,@Auther,@Publishar)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Auther",book.Author);
            cmd.Parameters.AddWithValue("@Publishar", book.Publishar);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateBook(Book book)
        {
            string qry = "update Book set Name=@Name,Price=@Price,Auther=@Auther,Publishar=@Publishar where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Auther", book.Author);
            cmd.Parameters.AddWithValue("@Publishar", book.Publishar);
            cmd.Parameters.AddWithValue("@Id", book.Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteBook(int Id)
        {
            string qry = "delete from Book where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
