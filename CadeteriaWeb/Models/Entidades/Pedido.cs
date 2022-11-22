namespace CadeteriaWeb.Models.Entidades
{

    public enum EstadoPedido {Vacio,En_prepacion,En_camino,Entregado,Cancelado};
    public class Pedido
    {
        private int id;
        private string observacion;
        private Cliente cliente;
        private Cadete cadete; 
        private bool alta;
        private EstadoPedido estado; 

        public int Id { get => id; set => id = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }
        public bool Alta { get => alta; set => alta = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }

        public Pedido(){}

        public Pedido(int i, string obs, Cliente cl , EstadoPedido ep, Cadete ca, bool alt)
        {
            Id= i;
            Observacion = obs;
            Cliente = cl;
            Estado = ep;
            Cadete = ca;
            Alta = alt;

            

        }
    }
}