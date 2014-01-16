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
    public class UserModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int codUsuario { get; set; }

        [Required]
        [Display(Name = "Nome do Usuário")]
        public string noUsusario { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public string dcLogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string dcSenha { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string dcEmail { get; set; }


        public UserModel()
        {
            
        }

        public UserModel(string _dcLogin, string _dcSenha)
        {
            dbNF_B2TEntity db = new dbNF_B2TEntity();

            _dcSenha = Helpers.SHA1.Encode(_dcSenha);
            var tbUser = db.tblUsuarios.FirstOrDefault(x => x.dcLogin == _dcLogin && x.dcSenha == _dcSenha);

            this.codUsuario = tbUser.codUsuario;
            this.noUsusario = tbUser.noUsuario;
            this.dcLogin = tbUser.dcLogin;
            this.dcSenha = tbUser.dcSenha;
            this.dcEmail = tbUser.dcEmail;

        }

    }
}