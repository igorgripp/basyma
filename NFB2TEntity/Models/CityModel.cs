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
    public class CityModel
    {
        private dbNF_B2TEntity db = new dbNF_B2TEntity();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código Cliente")]
        public int codCidade { get; set; }

        [Required]
        [Display(Name = "Código UF")]
        public int codUF { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string noCidade { get; set; }


        public List<tblCidade> getAllCities()
        {
            return db.tblCidades.ToList();
        }

        public List<tblCidade> getCitiesByState(int idState)
        {
            return db.tblCidades.Where(q => q.codUF == idState).ToList();
        }

        public tblCidade getTblCidadeById(int codCidade)
        {
            return db.tblCidades.Find(codCidade);
        }
    }
}