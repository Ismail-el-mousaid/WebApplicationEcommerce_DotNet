using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryEntity
{
    [Table("TableClient")]

    public class Client
    {
       
        private Int32 Id;
        private String nom;
        private String prenom;
        private String ville;
        private String adresse;
        private String mail;

        
        public Int32 ClientId { get => Id; set => Id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Mail { get => mail; set => mail = value; }

        

    }
}
