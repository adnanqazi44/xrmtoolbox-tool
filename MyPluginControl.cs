using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace MSToolByAdn
{
    public partial class MyPluginControl : PluginControlBase
    {
        string filepath = null;
        public List<LoadSolutionsList> LSList = new List<LoadSolutionsList>();
        private Settings mySettings;


        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        public LoadSolutionsList GetSelectedValue(string SelectedSolutionName)
        {
            return LSList.FirstOrDefault(x => x.SolutionName == SelectedSolutionName);
        }
        public LoadSolutionsList Value()
        {
            return LSList.FirstOrDefault();
        }
        private async void LoadSolutionButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
            //var loaderForm = new Form1();

            //loaderForm.Show(this);

            LoadSolutionButton.Text = "Loading...";
            // WaitingObj.Show(this);
            //DirectoryButton.Enabled = false;
            //DirectoryTBox.ReadOnly = true;
            //ExtractSolution.Enabled = true;
            //SearchStringKeyword.ReadOnly = true;
            //ClearButton.Enabled = false;
            //SearchButton.Enabled = false;
            await Task.Delay(2000);

            var query_ismanaged = false;
            var query_isvisible = true;
            var query_uniquename = "default";
            var solutionQuery = new QueryExpression("solution");
            solutionQuery.ColumnSet = new ColumnSet("friendlyname", "uniquename", "solutionid", "version");
            solutionQuery.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, query_ismanaged);
            solutionQuery.Criteria.AddCondition("isvisible", ConditionOperator.Equal, query_isvisible);
            solutionQuery.Criteria.AddCondition("friendlyname", ConditionOperator.NotEqual, query_uniquename);
            EntityCollection solutionCollection = Service.RetrieveMultiple(solutionQuery);
            SolutionComboBox.Items.Clear();
            foreach (Entity solution in solutionCollection.Entities)
            {
                var solutionId = solution.GetAttributeValue<Guid>("solutionid");
                var solutionName = solution.GetAttributeValue<string>("friendlyname");
                var uniquename = solution.GetAttributeValue<string>("uniquename");
                var version = solution.GetAttributeValue<string>("version");
                LSList.Add(new LoadSolutionsList { SolutionId = solutionId, Version = version, SolutionName = solutionName, UniqueName = uniquename });
                SolutionComboBox.Items.Add(solutionName);
            }

            //loaderForm.Close();
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
            LoadSolutionButton.Text = "Load Solutions";
            //DirectoryButton.Enabled = true;
            //DirectoryTBox.ReadOnly = false;
            //ExtractSolution.Enabled = true;
        }

        private void ExtractSolutionButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }
                //var loaderForm = new LoadingForm();
                //loaderForm.ShowDialog();

                var selectedItem = GetSelectedValue(SolutionComboBox.SelectedItem.ToString());
                var selectedSolution = selectedItem.SolutionName.ToString();
                var uniqueName = selectedItem.UniqueName.ToString();

                if (selectedSolution == null)
                {
                    //WaitingObj.Close();
                    return;
                }
                var solutionId = selectedItem.SolutionId.ToString();
                byte[] solutionFile = RetrieveSolutionFile(Service, uniqueName);
                DateTime currentDateTime = DateTime.Now;
                string randomNumber = currentDateTime.ToString("yyyyMMddHHmmss");

                if (!string.IsNullOrEmpty(DirectoryTextBox.Text))
                {
                    string selectedDirectory = DirectoryTextBox.Text;
                    string solutionFileName = selectedSolution + randomNumber + ".zip";
                    string solutionFilePath = Path.Combine(selectedDirectory, solutionFileName);
                    File.WriteAllBytes(solutionFilePath, solutionFile);
                    LogInfo("Solution '{0}' exported to: {1}", selectedSolution, solutionFilePath);
                    string extractionFolderPath = Path.Combine(Path.GetDirectoryName(solutionFilePath), Path.GetFileNameWithoutExtension(solutionFilePath));
                    UnzipSolution(solutionFilePath, extractionFolderPath);
                    filepath = extractionFolderPath;
                    // MessageBox.Show("File saved to: " + solutionFilePath);
                    //SearchStringKeyword.ReadOnly = false;
                    //SearchButton.Enabled = true;
                    //ClearButton.Enabled = true;
                }
                else
                {
                    //WaitingObj.Close();
                    MessageBox.Show("Please select a directory first.");
                }


                //loaderForm.Close();
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }
                MessageBox.Show("Operation completed successfully!");
            }
            catch (Exception ex)
            {
                // WaitingObj.Close();
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public byte[] RetrieveSolutionFile(IOrganizationService service, string solutionUniqueName)
        {
            ExportSolutionRequest exportRequest = new ExportSolutionRequest
            {
                SolutionName = solutionUniqueName,
                Managed = false,
                ExportAutoNumberingSettings = true,
                ExportCalendarSettings = true,
                ExportCustomizationSettings = true,
                ExportEmailTrackingSettings = true,
                ExportExternalApplications = true,
                ExportGeneralSettings = true,
                ExportMarketingSettings = true,
                ExportOutlookSynchronizationSettings = true,
                ExportRelationshipRoles = true,
                ExportSales = true
            };
            ExportSolutionResponse exportResponse = (ExportSolutionResponse)service.Execute(exportRequest);
            byte[] exportXml = exportResponse.ExportSolutionFile;
            return exportXml;
        }

        public void UnzipSolution(string zipFilePath, string extractionFolderPath)
        {
            if (zipFilePath != null)
            {
                ZipFile.ExtractToDirectory(zipFilePath, extractionFolderPath);
                Console.WriteLine("Solution extracted successfully to: " + extractionFolderPath);
            }
            return;
        }

        private void DirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryTextBox.Text = folder.SelectedPath;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string Keyworddata = SearchKeywordTextBox.Text;
            SearchForStringInJsonFiles(filepath, Keyworddata);
            SolutionComboBox.Items.Clear();
            DirectoryTextBox.Text = "";
        }

        public void SearchForStringInJsonFiles(string extractionFolderPath, string searchString)
        {
            ResultTextBox.Clear();
            string workflowFolderPath = Path.Combine(extractionFolderPath, "Workflows");
            if (!Directory.Exists(workflowFolderPath))
            {
                MessageBox.Show("Workflows folder not found.");
                return;
            }
            var jsonFiles = Directory.GetFiles(workflowFolderPath, "*.json", SearchOption.AllDirectories);
            foreach (var jsonFilePath in jsonFiles)
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                JObject jsonObject = JObject.Parse(jsonContent);
                if (jsonObject.ToString().Contains(searchString))
                {
                    string fileName = Path.GetFileName(jsonFilePath);
                    ResultTextBox.AppendText(fileName + Environment.NewLine);
                    ResultTextBox.Multiline = true;
                    ResultTextBox.ScrollBars = ScrollBars.Vertical;
                    //MessageBox.Show($"String '{searchString}' found in JSON file: {jsonFilePath}");
                }
            }

            if (jsonFiles.Length == 0)
            {
                MessageBox.Show("No JSON files found in the Workflows folder.");
            }
            else
            {
                MessageBox.Show("Search completed in all JSON files within the Workflows folder.");
            }
        }

        private void ExportResultButton_Click(object sender, EventArgs e)
        {
            string textToExport = ResultTextBox.Text;
            if (string.IsNullOrEmpty(textToExport))
            {
                MessageBox.Show("No Data For text export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(textToExport);
                    }

                    MessageBox.Show("Text exported to file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Clear();
        }
    }

    public class LoadSolutionsList
    {
        public Guid SolutionId { get; set; }
        public string SolutionName { get; set; }
        public string UniqueName { get; set; }
        public string Version { get; set; }
    }
}