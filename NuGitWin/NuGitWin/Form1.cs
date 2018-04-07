using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;
using NuGet;

namespace NuGitWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(StoreSource.Text))
            {
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    StoreSource.Text = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            int startPos = GitSource.Text.LastIndexOf('/');
            int endPos = GitSource.Text.LastIndexOf(".git");
            var FolderName = GitSource.Text.Substring(startPos + 1, GitSource.Text.Length - endPos + 1);

            var co = new CloneOptions();
            //co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = "Username", Password = "Password" };
            Repository.Clone(GitSource.Text, StoreSource.Text + "\\NuGitSource\\" + FolderName, co);
            


        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            PackageBuilder builder;
            string AbstractionDIR = string.Empty;
            string DroidDIR = string.Empty;
            string iOS = string.Empty;


            //  File.WriteAllText(SolutionDir.Text, text);
            listBox1.Items.Clear();

            if (!string.IsNullOrEmpty(StoreSource.Text))
                openFileDialog1.InitialDirectory = StoreSource.Text;



            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                var packagePath = openFileDialog1.FileName;

                using (var str = ManifestUtility.ReadManifest(packagePath))
                {
                    builder = new PackageBuilder(str, Path.GetDirectoryName(packagePath));

                    int counter = 0;
                    foreach (var eachFile in builder.Files)
                    {
                        Debug.WriteLine(eachFile.Path);
                        var filePath = eachFile.EffectivePath.ToLower();

                        var framework = eachFile.Path.Split('/');
                        var projectName = framework[2].Replace(".dll", "");


                        if (filePath.Contains("netstandard"))
                        {
                            listBox1.Items.Add(filePath + "|" + "NETStandard|" + framework[1] + "|" + projectName);

                        }

                        if (filePath.Contains("portable"))
                        {
                            //  listBox1.Items.Add("  PCL - " + framework[1]);
                        }

                        if (eachFile.Path.Contains("MonoAndroid") && !eachFile.Path.Contains("+"))
                        {
                            listBox1.Items.Add(filePath + "|" + "Android|" + framework[1] + "|" + projectName);

                        }

                        if (eachFile.Path.Contains("Xamarin.iOS") && !eachFile.Path.Contains("+"))
                        {
                            listBox1.Items.Add(filePath + "|" + "iOS|" + framework[1] + "|" + projectName);
                        }

                        counter++;
                        if ((counter % 2) == 0)
                        {

                            // continue;
                        }

                    }
                }

                Debug.WriteLine("Hi: " + builder);
            }

            string text = File.ReadAllText(SolutionDir.Text);
            string insertPoint = "EndProject";
            int findPoint = text.LastIndexOf(insertPoint);
            int index = findPoint + insertPoint.Length;
            var insertText = string.Empty;
            Guid g;
            Guid g2;

            foreach (var eachInsert in listBox1.Items)
            {
                g = Guid.NewGuid();
                g2 = Guid.NewGuid();
                var splitIt = eachInsert.ToString().Split('|');

                insertText = insertText + $"\nProject(\"{{" + g +
                             "}}\") = \"" + splitIt[3] + "\", \"" + SourceDir.Text + "\\" + splitIt[3] + "\\" +
                             splitIt[3] + ".csproj\", \"{{" +
                             g2 + "}}\"\nEndProject\n";
            }

            var finalText = text.Insert(index, insertText);

            File.WriteAllText(SolutionDir.Text, finalText);

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                var droidPath = openFileDialog1.FileName;
                string insertDroid = string.Empty;

                string text2 = File.ReadAllText(droidPath);
                string insertPoint2 = "ItemGroup";
                int findPoint2 = text2.LastIndexOf(insertPoint2);
                int index2 = findPoint2 + insertPoint2.Length + 1;
                Guid rando;
                foreach (var eachInsert2 in listBox1.Items)
                {
                    if (eachInsert2.ToString().Contains("MonoAndroid"))
                    {
                        rando = Guid.NewGuid();
                        var splitIt = eachInsert2.ToString().Split('|');
                        var middleDroid = SourceDir.Text + "\\" + splitIt[3] + "\\" + splitIt[3] + ".csproj";
                        var fullInput =
                            $"     <ProjectReference Include=\"" + middleDroid + "\">\r\n      <Project>{" + rando + "}</Project>\r\n      <Name>" + splitIt[3] + "</Name>\n</ProjectReference>\n";
                        insertDroid = insertDroid + "<ItemGroup>\n" + fullInput + "</ItemGroup>\n";
                    }
                }

                if (!string.IsNullOrEmpty(insertDroid))
                {
                    var finalText2 = text2.Insert(index2, "\n" + insertDroid);

                    File.WriteAllText(droidPath, finalText2);
                }
            }
        }
    }
}

