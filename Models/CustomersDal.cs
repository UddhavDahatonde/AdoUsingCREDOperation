using System.Data.SqlClient;

namespace AdoUsingCREDOperation.Models
{
    public class CustomersDal
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlDataReader dr;
       SqlCommand cmd;
        public CustomersDal(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int CustomerRegister(Customers cust)
        {
            string qry = "insert into Customers values(@name,@email,@contact,@password)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", cust.name);
            cmd.Parameters.AddWithValue("@email", cust.email);
            cmd.Parameters.AddWithValue("@contact", cust.contact);
            cmd.Parameters.AddWithValue("@password", cust.password);
            con.Open();
            int res=cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public Customers CustomersLogin(Customers cust)
        {
            Customers c = new Customers();
            string qry = "select *from Customers where email=@email and password=@password";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email",cust.email);
            cmd.Parameters.AddWithValue("@password", cust.password);
            con.Open();
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                if(dr.Read())
                {
                    c.id=Convert.ToInt32(dr["ID"]);
                    c.name = dr["name"].ToString();
                    c.email = dr["email"].ToString();
                }
                return c;
            }
            else
            {
                return null;
            }
        }
    }
}
