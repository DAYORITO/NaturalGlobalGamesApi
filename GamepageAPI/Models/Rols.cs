namespace GamepageAPI.Models
{
    public class Rols
    {
        public int IdRol { get; set; }

        public string RolName { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}

