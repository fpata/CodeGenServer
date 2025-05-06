using Newtonsoft.Json;
using System.Data;
using System.Configuration;

namespace CodeGenServer
{
    public partial class Form1 : Form
    {
        SchemaController schemaController = null;
        SchemaInputModel schemaInputModel = null;
        public Form1()
        {
            InitializeComponent();
            schemaController = new SchemaController();
            schemaInputModel = new SchemaInputModel();
            txtConnectionString.Text = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cbDBType.SelectedIndex = 1;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConnectionString.Text) || String.IsNullOrEmpty(cbDBType.Text))
            {
                MessageBox.Show("Please select a DB Type and enter a Connection String.");
                return;
            }

            try
            {
                // Assuming you have a method to connect to the database
                // ConnectToDatabase(txtConnectionString.Text);
                schemaInputModel.dbType = Enum.Parse<DBType>(cbDBType.Text);
                schemaInputModel.connectStr = txtConnectionString.Text;
                string jsonData = schemaController.GetTables(schemaInputModel);

                // Fix for CS8600: Ensure the deserialization result is not null
                DataTable? dtTables = JsonConvert.DeserializeObject<DataTable>(jsonData);

                if (dtTables == null)
                {
                    MessageBox.Show("Failed to retrieve Tables data from the database.");
                    return;
                }
                List<String> tableNames = new List<String>();
                foreach (DataRow row in dtTables.Rows)
                {
                    tableNames.Add(row["Table_Name"].ToString());
                }
                cbTables.DataSource = tableNames;
                dgvTablesSchema.DataSource = dtTables;
                dgvTablesSchema.DataMember = dtTables.TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}");
            }
        }

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbSchemaCode.TabIndex == 1)
                SetColumnsData();
        }

        private void tbColumns_Click(object sender, EventArgs e)
        {
            SetColumnsData();
        }

        private void SetColumnsData()
        {
            if (String.IsNullOrEmpty(cbTables.Text))
            {
                MessageBox.Show("Please select a table first.");
                return;
            }
            schemaInputModel.tableName = cbTables.SelectedItem.ToString();
            schemaInputModel.connectStr = txtConnectionString.Text;
            string jsonData = schemaController.GetColumns(schemaInputModel);
            DataTable? dtColumns = JsonConvert.DeserializeObject<DataTable>(jsonData);
            if (dtColumns == null)
            {
                MessageBox.Show("Failed to retrieve Columns data from the database.");
                return;
            }
            dgvColumnsSchema.DataSource = dtColumns;
            dgvColumnsSchema.DataMember = dtColumns.TableName;
        }

        private void tbTypeScript_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.TypeScript;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtTypeScriptCode.Text = codeVal;
        }

        private void tbCSharp_Poco_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.CSharpEntity;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtCSharp_Poco.Text = codeVal;
        }



        private void tbSchemaCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbSchemaCode.SelectedIndex)
            {
                case 1:
                    SetColumnsData();
                    break;
                case 2:
                    tbTypeScript_Click(sender, e);
                    break;
                case 3:
                    tbCSharp_Poco_Click(sender, e);
                    break;
                case 4:
                    tbCSharpEFMapping_Click(sender, e);
                    break;
                case 5:
                    tbCSharpDAL_Click(sender, e);
                    break;
                case 6:
                    tbCSharpDBContext_Click(sender, e);
                    break;
                case 7:
                    tbHTML_Click(sender, e);
                    break;
                case 8:
                    tbHTMLBootStrap_Click(sender, e);
                    break;
                case 9:
                    tbHTMLMaterial_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void tbCSharpEFMapping_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.CSharpEFMapping;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtCSharpEFMapping.Text = codeVal;
        }

        private void tbCSharpDAL_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.CSharpDAL;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtCSharpDAL.Text = codeVal;
        }

        private void tbCSharpDBContext_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.CSharpDBContext;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtCSharpDBContext.Text = codeVal;
        }

        private void tbHTML_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.HTML;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtHTML.Text = codeVal;
        }

        private void tbHTMLBootStrap_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.HTMLBootStrap;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtHTMLBootStrap.Text = codeVal;
        }

        private void tbHTMLMaterial_Click(object sender, EventArgs e)
        {
            schemaInputModel.codeType = CodeGenServer.CodeType.HTMLMaterial;
            string codeVal = schemaController.GetCode(schemaInputModel);
            txtHTMLMaterial.Text = codeVal;
        }
    }
}
