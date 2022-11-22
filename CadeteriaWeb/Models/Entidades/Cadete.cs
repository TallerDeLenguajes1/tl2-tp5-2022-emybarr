namespace CadeteriaWeb.Models.Entidades
{
    public class Cadete
    {
        private int idCadete; 

        private string nombre;

        private string direccion;

        private string telefono;

        private bool alta ; 

        
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }
        public bool Alta { get => alta; set => alta = value; }

        public Cadete(){
            this.Alta = true;
        }

        public Cadete(int i , string n , string d , string tel, bool al)
        {
            IdCadete=i;
            Nombre= n;
            Direccion= d;
            Telefono= tel;
            Alta =al;
           

        }


    }
}