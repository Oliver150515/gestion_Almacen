﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_Almacen.Models
{
    public class UsuarioLogin
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public int Audit { get; set; }
    }
}