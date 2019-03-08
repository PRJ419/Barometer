namespace Barometer.Models
{
    public class Bar
    {
        //Dont know if they belong here. Dont think they do. 
        public string Username { get; set; }
        public string Password { get; set; }

        //Properties for a bar
        public string Name { get; set; }
        public string Adress { get; set; }
        public int CVR { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BarId { get; set; }
        public string Image { get; set; }
    }
}