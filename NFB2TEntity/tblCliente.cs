//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NFB2TEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCliente
    {
        public tblCliente()
        {
            this.tblNotaFiscals = new HashSet<tblNotaFiscal>();
        }
    
        public int codCliente { get; set; }
        public int codCidade { get; set; }
        public string dcDestinatario { get; set; }
        public string nuCNPJ { get; set; }
        public string nuCPF { get; set; }
        public string nuCadastroFiscal { get; set; }
        public string nuTelefone { get; set; }
        public string dcEndereco { get; set; }
        public string nuCEP { get; set; }
        public string dcEmail { get; set; }
    
        public virtual tblCidade tblCidade { get; set; }
        public virtual ICollection<tblNotaFiscal> tblNotaFiscals { get; set; }
    }
}
