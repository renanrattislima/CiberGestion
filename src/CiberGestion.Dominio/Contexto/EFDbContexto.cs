﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberGestion.Dominio.Contexto
{
    public class EFDbContexto : DbContext
    {
        public EFDbContexto()
            : base("ConnectionString")
        {
        }
    }
}
