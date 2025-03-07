namespace EjemploMVC_MAT.Models
{
    public class Product
    {
        public string driverId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string nationality { get; set; }
        public DateTime? birthday { get; set; } // Cambiado a DateTime?
        public string url { get; set; }
    }

}