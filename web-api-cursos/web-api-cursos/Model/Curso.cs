using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_api_cursos.Model
{
    public class Curso
    {
        public int Id { get; set; }
 
        [MinLength(3)]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Range(1, int.MaxValue)]
        public int CargaHoraria { get; set; }

        [Range(0,99999999.99)]
        public decimal Valor { get; set; }

        [DataNoPassado]
        public DateTime? DataInicio { get; set; }
        public bool Online { get; set; }
        public bool Ativo { get; set; }

        public Curso() { }
    }
}