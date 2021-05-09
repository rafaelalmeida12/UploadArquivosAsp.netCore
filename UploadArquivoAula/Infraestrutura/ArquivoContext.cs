using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadArquivoAula.Models;

namespace UploadArquivoAula.Infraestrutura
{
    public class ArquivoContext:DbContext
    {
        public ArquivoContext(DbContextOptions<ArquivoContext> options) : base(options)
        {
            //
        }

        public DbSet<Arquivos> Arquivos { get; set; }
    }
}
