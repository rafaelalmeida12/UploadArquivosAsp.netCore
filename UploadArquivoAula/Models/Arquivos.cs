using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadArquivoAula.Models
{
    public class Arquivos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }

    }
}
