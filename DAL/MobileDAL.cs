using System.Data.SqlClient;

namespace AdoUsingCRUDOperation.DAL
{
    public class MobileDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public MobileDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string str = this.configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(str);
        }
        public List<Mobile>GetAllMobile()
        {
            List<Mobile> mobiles = new List<Mobile>();
            cmd=new SqlCommand("select * from Mobile",con);
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Mobile mobile = new Mobile();
                mobile.id = Convert.ToInt32(dr["id"]);
                mobile.Mobile_Name = dr["Mobile_Name"].ToString();
                mobile.Price = Convert.ToDecimal(dr["Price"]);
                mobiles.Add(mobile);
            }
            con.Close();
            return mobiles;
        }
        public Mobile GetMobileById(int id)
        {
            Mobile mobile=new Mobile();
            cmd = new SqlCommand("select *from Mobile", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            { 
                mobile.id = Convert.ToInt32(dr["id"]);
                mobile.Mobile_Name = dr["Mobile_Name"].ToString();
                mobile.Price = Convert.ToDecimal(dr["Price"]);  
            }
            con.Close();
            return mobile;
        }
        public int AddMobile(Mobile mobile)
        {
            string query = "insert into Mobile values(@Mobile_Name,@Price)";
            cmd = new SqlCommand(query,con);
           cmd.Parameters.AddWithValue("@Mobile_Name",mobile.Mobile_Name);
            cmd.Parameters.AddWithValue("@price", mobile.Price);
            con.Open();
            int result=cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int EditeMobile(Mobile mobile)
        {
            string query = "update Mobile set Mobile_name=@Mobile_Name,Price=@Price where id=@id";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@Mobile_Name", mobile.Mobile_Name);
            cmd.Parameters.AddWithValue("@Price", mobile.Price);
            cmd.Parameters.AddWithValue("@id", mobile.id);
            con.Open();
            int results=cmd.ExecuteNonQuery();
            con.Close();
            return results;
        }

        
    }
}
