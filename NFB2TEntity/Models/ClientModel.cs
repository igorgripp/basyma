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
    public class ClientModel
    {

        private dbNF_B2TEntity db = new dbNF_B2TEntity();

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código Cliente")]
        public int codCliente { get; set; }

        [Display(Name = "Código Cidade")]
        public int codCidade { get; set; }

        [Required(ErrorMessage="campo obrigatório")]
        [Display(Name = "Destinatário")]
        public string dcDestinatario { get; set; }

        [Display(Name = "CPF")]
        public string nuCPF { get; set; }

        [Display(Name = "CNPJ")]
        public string nuCNPJ { get; set; }

        [Display(Name = "Cadastro Fiscal")]
        public string nuCadastroFiscal { get; set; }

        [Display(Name = "Telefone")]
        public string nuTelefone { get; set; }

        [Display(Name = "Email")]
        public string dcEmail { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Endereço")]
        public string dcEndereco { get; set; }

        [Display(Name = "CEP")]
        public string nuCEP { get; set; }


        public ClientModel()
        {

        }

        public ClientModel(int codCliente)
        {
            var dbCliente = db.tblClientes.Find(codCliente);
            if (dbCliente != null)
            {
                this.codCliente = dbCliente.codCliente;
                this.codCidade = dbCliente.codCidade;
                this.dcDestinatario = dbCliente.dcDestinatario;
                this.nuCPF = dbCliente.nuCPF;
                this.nuCNPJ = dbCliente.nuCNPJ;
                this.nuCadastroFiscal = dbCliente.nuCadastroFiscal;
                this.nuTelefone = dbCliente.nuTelefone;
                this.dcEmail = dbCliente.dcEmail;
                this.dcEndereco = dbCliente.dcEndereco;
                this.nuCEP = dbCliente.nuCEP;
            }

        }


        public List<tblCliente> searchClient()
        {
            List<tblCliente> ClientList = db.tblClientes.ToList();

            if (!String.IsNullOrEmpty(this.dcDestinatario)) ClientList = ClientList.Where(q => q.dcDestinatario.ToUpper().Contains(this.dcDestinatario.ToUpper())).ToList();
            if (!String.IsNullOrEmpty(this.nuCPF)) ClientList = ClientList.Where(q => q.nuCPF == this.nuCPF).ToList();
            if (!String.IsNullOrEmpty(this.nuCNPJ)) ClientList = ClientList.Where(q => q.nuCNPJ == this.nuCNPJ).ToList();
            if (!String.IsNullOrEmpty(this.nuCadastroFiscal)) ClientList = ClientList.Where(q => q.nuCadastroFiscal == this.nuCadastroFiscal).ToList();
            if (!String.IsNullOrEmpty(this.nuTelefone)) ClientList = ClientList.Where(q => q.nuTelefone == this.nuTelefone).ToList();
            if (this.codCidade != 0) ClientList = ClientList.Where(q => q.codCidade == this.codCidade).ToList();

            return ClientList;

        }



    }
}