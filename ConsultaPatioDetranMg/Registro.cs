namespace ConsultaPatioDetranMg
{
    public class Registro
    {
        public string Placa { get; set; }
        public string Proprietario { get; set; }
        public string DataApr { get; set; }
        public string PatioApreensao { get; set; }
        public string EnderecoPatio { get; set; }
        public string Valor { get; set; }
        public int Status { get; set; }

        public void TemRegistro()
        {
            Status = 1;
        }

        public void NaoTemRegistro()
        {
            Status = 2;
        }

        public void DeuProblema()
        {
            Status = 3;
        }
    }
}
