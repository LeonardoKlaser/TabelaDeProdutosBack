namespace APIweb.ViewModel
{
    public class ProductViewModel
    {
        public string NomeProduto { get; set; }
        public string PaisDeOrigem { get; set; }
        public string PaisDeDestino { get; set; }
        public int Quantidade { get; set; }
        public int ValorUnitario { get; set; }
        public string Importador { get; set; }
        public string Exportador { get; set; }
        public DateTime DataEmbarque { get;  set; }
        public DateTime DataChegada { get;  set; }
        public string FreteModo { get; set; }

    }
}
