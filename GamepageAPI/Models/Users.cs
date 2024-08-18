namespace GamepageAPI.Models
{
    public class Users
    {
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public byte[] UserPassword { get; set; }

        public byte[] Salt { get; set; }

        public int IdRol { get; set; }

        // Navigation property for the Rol class
        public Rols Role { get; set; }
    }
}
