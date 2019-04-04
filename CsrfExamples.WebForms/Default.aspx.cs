using System;
using System.Web.UI.WebControls;
using CsrfExamples.Data;

namespace CsrfExamples.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindData();
            }
        }

        protected void btnTransfer_OnClick(object sender, EventArgs e)
        {
            if (ddlFrom.SelectedValue == "-1" || 
                ddlTo.SelectedValue == "-1" || 
                String.IsNullOrWhiteSpace(txtAmount.Text))
            {
                return;
            }

            var from = Convert.ToInt32(ddlFrom.SelectedValue);
            var to = Convert.ToInt32(ddlTo.SelectedValue);
            var amount = Convert.ToDecimal(txtAmount.Text);

            DataStore.Instance.TransferFunds(from, to, amount);

            BindData();
        }
        
        protected void lvTransactiosn_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // Get Data
            var transaction = (Transaction)e.Item.DataItem;

            // Get Controls
            var litDateTime = (Literal)e.Item.FindControl("litDateTime");
            var litTransaction = (Literal)e.Item.FindControl("litTransaction");

            // Populate Data
            litDateTime.Text = transaction.DateTime.ToString("HH");
            litTransaction.Text = transaction.Description;
        }

        protected void lvBalances_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // Get Data
            var account = (BankAccount) e.Item.DataItem;

            // Get Controls
            var litAccountId = (Literal) e.Item.FindControl("litAccountId");
            var litName = (Literal) e.Item.FindControl("litName");
            var litAmount = (Literal) e.Item.FindControl("litAmount");

            // Populate Data
            litAccountId.Text = account.Id.ToString();
            litName.Text = account.Name;
            litAmount.Text = account.Balance.ToString("C");
        }

        private void BindData()
        {
            lvBalances.DataSource = DataStore.Instance.BankAccounts;
            lvTransactiosn.DataSource = DataStore.Instance.Transactions;

            lvBalances.DataBind();
            lvTransactiosn.DataBind();

            var defaultItem = new ListItem("-- Select Account --", "-1");

            ddlFrom.Items.Add(defaultItem);
            ddlTo.Items.Add(defaultItem);

            foreach (var account in DataStore.Instance.BankAccounts)
            {
                ddlFrom.Items.Add(new ListItem(account.Name, account.Id.ToString()));
                ddlTo.Items.Add(new ListItem(account.Name, account.Id.ToString()));
            }
        }
    }
}