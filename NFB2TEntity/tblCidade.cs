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
    
    public partial class tblCidade
    {
        public tblCidade()
        {
            this.tblClientes = new HashSet<tblCliente>();
        }
    
        public int codCidade { get; set; }
        public int codUF { get; set; }
        public string noCidade { get; set; }
    
        public virtual ICollection<tblCliente> tblClientes { get; set; }
        public virtual tblUF tblUF { get; set; }
    }
}
