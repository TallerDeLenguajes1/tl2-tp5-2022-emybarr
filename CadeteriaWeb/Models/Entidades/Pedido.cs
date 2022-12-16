namespace CadeteriaWeb.Models.Entidades
{
     public enum Estado {Vacio, Procesando,En_Camino,Entregado,Cancelado};

    public class Pedido
    {
        private int id;
        private string observacion;
        private int cliented;
        private int cadeted;
        private Estado state;
        private bool alta;

        



        public int Id { get => id; set => id = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Alta { get => alta; set => alta = value; }

        public int Cliented { get => cliented; set => cliented = value; }
        public int Cadeted { get => cadeted; set => cadeted = value; }
        public Estado State { get => state; set => state = value; }

        public Pedido() {} 


        public Pedido(int id, string obs, int cl, int ca, Estado e)
        {
            Id =id;
            Observacion = obs;
            Cliented = cl;
            Cadeted = ca;
            State = e;
        }

        
        
    }
}