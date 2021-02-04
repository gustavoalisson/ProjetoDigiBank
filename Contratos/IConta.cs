using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Contratos
{
    public interface IConta
    {
        void Deposita(double valor);
        bool Sacar(double valor);
        double ConsultaSaldo();
        string GetCodigoDoBanco();
        string GetNumeroAgencia();
        string GetNumeroConta();

    }
}
