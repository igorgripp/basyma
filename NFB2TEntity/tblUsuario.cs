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
    
    public partial class tblUsuario
    {
        public tblUsuario()
        {
            this.tblNotaFiscals = new HashSet<tblNotaFiscal>();
        }
    
        public int codUsuario { get; set; }
        public string noUsuario { get; set; }
        public string dcLogin { get; set; }
        public string dcSenha { get; set; }
        public string dcEmail { get; set; }
    
        public virtual ICollection<tblNotaFiscal> tblNotaFiscals { get; set; }
    }
}
