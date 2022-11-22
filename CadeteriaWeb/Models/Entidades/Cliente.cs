namespace CadeteriaWeb.Models.Entidades
{
    public class Cliente
    {
        private int idCliente; 

        private string nombre;

        private string direccion;

        private string telefono;

        
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }

        public Cliente(){}

        public Cliente(int i , string n , string d , string tel)
        {
            IdCliente=i;
            Nombre=n;
            Direccion= d;
            Telefono= tel ;
        }






    }
}