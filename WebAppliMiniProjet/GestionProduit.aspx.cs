using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLibraryEntity;

namespace WebAppliMiniProjet
{
    public partial class GestionProduit : System.Web.UI.Page
    {
        EcommerceContext DbContext = new EcommerceContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ChargementDDLCommandes();

                ChargementDDLCommandes2();
            }
        }

        

        private void ChargementDDLCommandes()
        {
            DDListeCommande.DataSource = (from com in DbContext.Commandes
                                          select com).ToList();
            DDListeCommande.DataTextField = "Libelle";
            DDListeCommande.DataValueField = "CommandeId";
            DDListeCommande.DataBind();
        }

        private void ChargementDDLCommandes2()
        {
            DDListeCommande2.DataSource = (from com in DbContext.Commandes
                                           select com).Distinct().ToList();
            DDListeCommande2.DataTextField = "Libelle";
            DDListeCommande2.DataValueField = "CommandeId";
            DDListeCommande2.DataBind();
        }

        protected void GvProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 IdPro = int.Parse(GvProduit.SelectedValue.ToString());
            Produit MonPro = new Produit();
            MonPro = (from pro in DbContext.Produits
                      where pro.ProduitId == IdPro
                      select pro).Single();
            TbIdPro.Text = MonPro.ProduitId.ToString();
            TbTitre.Text = MonPro.Titre;
            TbPrix.Text = MonPro.Prix;
            TbDescription.Text = MonPro.Prix;
            DDListeCommande2.SelectedValue = MonPro.commandeId.ToString();

        }
        

        protected void DDListeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 IdCom = int.Parse(DDListeCommande.SelectedValue.ToString());
            GvProduit.DataSource = (from pro in DbContext.Produits
                                    where pro.CommandeId == IdCom
                                    select pro).ToList();
            GvProduit.DataBind();
            GvProduit.DataBind();
        }

        public void ChargementProduits()
        {
            Int32 IdComm = int.Parse(DDListeCommande2.SelectedValue.ToString());
            GvProduit.DataSource = (from pro in DbContext.Produits
                                    where pro.CommandeId == IdComm
                                    select pro).ToList();
            GvProduit.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            
            Produit NewPro = new Produit();
            NewPro.Titre = TbTitre.Text;
            NewPro.Prix = TbPrix.Text;
            NewPro.Description = TbDescription.Text;
            NewPro.commandeId = int.Parse(DDListeCommande2.SelectedValue.ToString());
            DbContext.Produits.Add(NewPro);
            DbContext.SaveChanges();
            ChargementProduits();
        }

        protected void BtDelete_Click(object sender, EventArgs e)
        {
            Int32 IdPro = int.Parse(GvProduit.SelectedValue.ToString());
            Produit MonPro = new Produit();
            MonPro = (from pro in DbContext.Produits
                      where pro.ProduitId == IdPro
                      select pro).Single();
            DbContext.Produits.Remove(MonPro);
            DbContext.SaveChanges();
            ChargementProduits();
        }

        protected void BtMAJ_Click(object sender, EventArgs e)
        {
            Int32 IdPro = int.Parse(GvProduit.SelectedValue.ToString());
            Produit MonPro = new Produit();
            MonPro = (from pro in DbContext.Produits
                      where pro.ProduitId == IdPro
                      select pro).Single();
            MonPro.Titre = TbTitre.Text;
            MonPro.Prix = TbPrix.Text;
            MonPro.Description = TbDescription.Text;
            MonPro.CommandeId = int.Parse(DDListeCommande2.SelectedValue.ToString());
            DbContext.SaveChanges();
            ChargementProduits();
        }
    }
}