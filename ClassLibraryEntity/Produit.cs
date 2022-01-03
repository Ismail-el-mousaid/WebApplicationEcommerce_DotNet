using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Produit
    {
        private Int32 Id;
        private String titre;
        private String prix;
        private String description;

        public Int32 commandeId;
        public Commande commande;

        public int ProduitId { get => Id; set => Id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Prix { get => prix; set => prix = value; }
        public string Description { get => description; set => description = value; }
        public Int32 CommandeId { get => commandeId; set => commandeId = value; }
        public Commande Commande { get => commande; set => commande = value; }
    }
}
