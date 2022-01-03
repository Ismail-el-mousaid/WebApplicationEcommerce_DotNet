using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLibraryEntity;

namespace WebAppliMiniProjet
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        EcommerceContext DbContext = new EcommerceContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargementClients();
        }

        private void ChargementClients()
        {
            GvClient.DataSource = (from cli in DbContext.Clients
                                   select cli).ToList();
            GvClient.DataBind();
        }

        protected void GvClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 Id = int.Parse(GvClient.SelectedValue.ToString());
            Client MonClient = new Client();
            MonClient = (from cli in DbContext.Clients
                         where cli.ClientId == Id
                         select cli).Single();
            TbId.Text = MonClient.ClientId.ToString();
            TbNom.Text = MonClient.Nom;
            TbPrenom.Text = MonClient.Prenom;
            TbVille.Text = MonClient.Ville;
            TbAdresse.Text = MonClient.Ville;
            TbMail.Text = MonClient.Mail;

        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            Client NewClient = new Client();
            NewClient.Nom = TbNom.Text;
            NewClient.Prenom = TbPrenom.Text;
            NewClient.Ville = TbVille.Text;
            NewClient.Adresse = TbAdresse.Text;
            NewClient.Mail = TbMail.Text;
            DbContext.Clients.Add(NewClient);
            DbContext.SaveChanges();
            ChargementClients();
        }

        protected void BtDelete_Click(object sender, EventArgs e)
        {
            Int32 Id = int.Parse(GvClient.SelectedValue.ToString());
            Client MonClient = new Client();
            MonClient = (from cli in DbContext.Clients
                         where cli.ClientId == Id
                         select cli).Single();
            DbContext.Clients.Remove(MonClient);
            DbContext.SaveChanges();
            ChargementClients();
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            Int32 Id = int.Parse(GvClient.SelectedValue.ToString());
            Client MonClient = new Client();
            MonClient = (from cli in DbContext.Clients
                         where cli.ClientId == Id
                         select cli).Single();
            MonClient.Nom = TbNom.Text;
            MonClient.Prenom = TbPrenom.Text;
            MonClient.Ville = TbVille.Text;
            MonClient.Adresse = TbAdresse.Text;
            MonClient.Mail = TbMail.Text;
            DbContext.SaveChanges();
            ChargementClients();
        }
    }
}