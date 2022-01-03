using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryEntity
{
    public class Commande
    {
        private Int32 Id;
        private String type;
        private String libelle;

        private Int32 clientId;
        private Client client;


        public int CommandeId { get => Id; set => Id = value; }
        public string Type { get => type; set => type = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public Client Client { get => client; set => client = value; }
    }
}
