﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities.Models
{
    public class Autor
    {
        [Key]
        public BigInteger Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
    }
}
