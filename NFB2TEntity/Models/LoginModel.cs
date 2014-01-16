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
    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string dcLogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string dcSenha { get; set; }

        public bool IsValid(string _dcLogin, string _dcSenha)
        {
            dbNF_B2TEntity db = new dbNF_B2TEntity();

            _dcSenha = Helpers.SHA1.Encode(_dcSenha);
            return db.tblUsuarios.Any(x => x.dcLogin == _dcLogin && x.dcSenha == _dcSenha);
        }
    }
}