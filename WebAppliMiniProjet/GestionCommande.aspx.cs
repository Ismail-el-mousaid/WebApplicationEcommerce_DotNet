using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLibraryEntity;

namespace WebAppliMiniProjet
{
    public partial class GestionCommande : System.Web.UI.Page
    {
        EcommerceContext DbContext = new EcommerceContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChargementListeClients();
                ChargementListeClients2();
            }
        }

        private void ChargementListeClients()
        {
            DDListeClients.DataSource = (from cli in DbContext.Clients
                                         select cli).ToList();
            DDListeClients.DataTextField = "Nom";
            DDListeClients.DataValueField = "ClientId";
            DDListeClients.DataBind();
        }

        protected void DDListeClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 IdCli = int.Parse(DDListeClients.SelectedValue.ToString());
            GvCommande.DataSource = (from com in DbContext.Commandes
                                     where com.ClientId == IdCli
                                     select new { com.CommandeId, com.Type, com.Libelle, com.ClientId }).ToList();
            GvCommande.DataBind();
        }

        protected void GvCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 IdCom = int.Parse(GvCommande.SelectedValue.ToString());
            Commande MonCom = new Commande();
            MonCom = (from com in DbContext.Commandes
                      where com.CommandeId == IdCom
                      select com).Single();
            TbId.Text = MonCom.CommandeId.ToString();
            TbType.Text = MonCom.Type;
            TbLibelle.Text = MonCom.Libelle;
            ChargementListeClients2();
            DDListeClients2.SelectedValue = MonCom.ClientId.ToString();
        }


        private void ChargementListeClients2()
        {
            DDListeClients2.DataSource = (from clie in DbContext.Clients
                                          select clie).Distinct().ToList();
            DDListeClients2.DataTextField = "Nom";
            DDListeClients2.DataValueField = "ClientId";
            DDListeClients2.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            Commande NewCom = new Commande();
            NewCom.Type = TbType.Text;
            NewCom.Libelle = TbLibelle.Text;
            NewCom.ClientId = int.Parse(DDListeClients2.SelectedValue.ToString());
            DbContext.Commandes.Add(NewCom);
            DbContext.SaveChanges();
            ChargementCommandes();
        }

        public void ChargementCommandes()
        {
            Int32 IdCli = int.Parse(DDListeClients2.SelectedValue.ToString());
            GvCommande.DataSource = (from com in DbContext.Commandes
                                     where com.ClientId == IdCli
                                     select com).ToList();
            GvCommande.DataBind();
        }

        protected void BtDelete_Click(object sender, EventArgs e)
        {
            Int32 IdCom = int.Parse(GvCommande.SelectedValue.ToString());
            Commande MonCom = new Commande();
            MonCom = (from com in DbContext.Commandes
                      where com.CommandeId == IdCom
                      select com).Single();
            DbContext.Commandes.Remove(MonCom);
            DbContext.SaveChanges();
            ChargementCommandes();
        }

        protected void BtMAJ_Click(object sender, EventArgs e)
        {
            Int32 IdCom = int.Parse(GvCommande.SelectedValue.ToString());
            Commande MonCom = new Commande();
            MonCom = (from com in DbContext.Commandes
                      where com.CommandeId == IdCom
                      select com).Single();
            MonCom.Type = TbType.Text;
            MonCom.Libelle = TbLibelle.Text;
            MonCom.ClientId = int.Parse(DDListeClients2.SelectedValue.ToString());
            DbContext.SaveChanges();
            ChargementCommandes();
        }
    }
}