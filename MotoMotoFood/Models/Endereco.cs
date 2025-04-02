using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoMotoFood.Models
{
    public class Endereco
    {
        public string Rua { get; private set; }
        public string Numero {  get; private set; }
        public string CEP { get; private set; }

        public Endereco(string rua, string numero, string cep)
        {
            Rua = rua;
            Numero = numero;
            CEP = cep;
        }
    }
}
