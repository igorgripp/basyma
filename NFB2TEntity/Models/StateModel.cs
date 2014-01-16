using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Linq;
using System.Text;

namespace NFB2TEntity.Models
{
    public class StateModel
    {
        private dbNF_B2TEntity db = new dbNF_B2TEntity();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código UF")]
        public int codUF { get; set; }

        [Required]
        [Display(Name = "Descrição UF")]
        public string dcUF { get; set; }

        [Required]
        [Display(Name = "Sigla UF")]
        public string sgUF { get; set; }

        public List<tblUF> getAllStates()
        {
            return db.tblUFs.ToList();
        }

    }
}