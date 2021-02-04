
namespace DigitalBank.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeDoBanco = "DigiBank";
            this.CodigoDoBanco = "023";
        }

        public string NomeDoBanco { get; private set; }
        public string CodigoDoBanco { get; set; }
    }
}
