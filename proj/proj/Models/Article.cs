//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.LigneCommandes = new HashSet<LigneCommande>();
        }

        public Article(int numArticle, string designation, string prixU, int? stock, string photo, string refCat, Categorie categorie, ICollection<LigneCommande> ligneCommandes)
        {
            this.numArticle = numArticle;
            this.designation = designation;
            this.prixU = prixU;
            this.stock = stock;
            this.photo = photo;
            this.refCat = refCat;
            Categorie = categorie;
            LigneCommandes = ligneCommandes;
        }

        public int numArticle { get; set; }
        public string designation { get; set; }
        public string prixU { get; set; }
        public Nullable<int> stock { get; set; }
        public string photo { get; set; }
        public string refCat { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }
    }
}