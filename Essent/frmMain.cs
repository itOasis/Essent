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

namespace Essent
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string SourceWeb = @"\\212.123.31.100\Essent\Data\Scanning\";
        string SourceONLINE = @"E:\ONLINE_OPZOEKINGEN\";
        string SourceVOICE = @"E:\VOICE_LOGS\";
        string SourceVOICE2 = @"E:\VOICE_LOGS_2\";

        private void btnCheckonDiskDelete_Click(object sender, EventArgs e)
        {
            DCWebDataContext DCW;
            foreach (string sub in Directory.GetDirectories(SourceVOICE))
            {
                using (DCW = new DCWebDataContext())
                {
                    try
                    {
                        txtCheck.Text = "OPZOEKEN..." + sub;
                        Application.DoEvents();
                        List<tblCustomDataEntry> cde = (from tbl in DCW.tblCustomDataEntries where tbl.Directory.Contains(sub.Replace(@"E:\", "").Replace("\\", "/")) select tbl).ToList();
                        if (cde.Count > 0)
                        {
                            bool ok = true;
                            txtCheck.Text = "CONTROLE BARCODE..." + sub;
                            Application.DoEvents();
                            foreach (tblCustomDataEntry tblcde in cde)
                            {
                                if (tblcde.Barcode == null)
                                {
                                    ok = false;
                                    break;
                                }

                            }
                            if (ok)
                            {
                                txtCheck.Text = "DELETING..." + sub;
                                Application.DoEvents();
                                Directory.Delete(sub, true);

                            }
                            else
                            {
                                lsbErrors.Items.Add("BARCODE NULL: " + sub.Replace(@"E:\", "").Replace("\\", "/"));

                            }



                        }
                        else
                        {
                            lsbErrors.Items.Add("ZERO ITEMS: " + sub.Replace(@"E:\", "").Replace("\\", "/"));

                        }



                    }
                    catch (Exception ex)
                    {
                        lsbErrors.Items.Add("EXCEPTION: " + sub.Replace(@"E:\", "").Replace("\\", "/"));

                    }



                }




            }




        }

        private void btnExportErrors_Click(object sender, EventArgs e)
        {

            File.WriteAllLines(@"U:\001_PER KLANT\ESSENT\EXPORTVOICE.TXT", lsbErrors.Items.Cast<string>().ToArray());


        }

        private void btnZetopDisk_Click(object sender, EventArgs e)
        {
            DCWebDataContext DC;
            List<tblCustomDataEntry> cdelist = new List<tblCustomDataEntry>();
            txtCheck.Text = "DATA OPHALEN...";
            Application.DoEvents();
            using (DC = new DCWebDataContext())
            {
                try
                {
                    cdelist = (from tbl in DC.tblCustomDataEntries where tbl.Directory.Contains("ONLINE_OPZOEKINGEN") && tbl.Barcode == null select tbl).ToList();
                }
                catch (Exception ex)
                {
                    cdelist = null;
                }

            }
            foreach (tblCustomDataEntry cde in cdelist)
            {
                txtCheck.Text = "VERWERKEN..." + cde.DataEntryID.ToString();
                Application.DoEvents();
                string subdir = cde.Directory.Substring(0, 27).Replace("/", "\\");
                if (!Directory.Exists(@"E:\" + subdir))
                {
                    if (Directory.Exists(SourceWeb + subdir))
                    {
                        if (CopyFolder(SourceWeb + subdir, @"E:\" + subdir) == false)
                        {
                            lsbErrors.Items.Add("COPY FOLDER ERORR: " + subdir);
                        }
                        else
                        {
                            List<tblCustomDataEntry> tblcde = new List<tblCustomDataEntry>();
                            using (DC = new DCWebDataContext())
                            {
                                try
                                {
                                    tblcde = (from t in DC.tblCustomDataEntries where t.Directory.Contains(subdir.Replace("\\", "/")) && t.Barcode == null select t).ToList();
                                    foreach (tblCustomDataEntry c in tblcde)
                                    {
                                        c.Barcode = "20";

                                    }
                                    DC.SubmitChanges();

                                }
                                catch (Exception ex)
                                {
                                    lsbErrors.Items.Add("UPDATING ERORR: " + subdir);

                                }
                            }

                        }

                    }
                    else
                    {
                        lsbErrors.Items.Add("NOT FIND WEB: " + subdir);

                    }

                }


            }
            MessageBox.Show("DONE");



        }

        private bool CopyFolder(string source, string destination)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.Arguments = string.Format("/C Robocopy /S {0} {1}", source, destination);
                p.StartInfo.FileName = "CMD.EXE";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.WaitForExit();
                return true;
            }

            catch (Exception ex)
            {
                return false;

            }
        }

        private void btnVoiceCheckandRemove_Click(object sender, EventArgs e)
        {
            int found = 0, notfound = 0;
            foreach (string Yearfolder in Directory.GetDirectories(SourceVOICE))
            {
                string Year = Path.GetFileName(Yearfolder);
                foreach (string weekfolder in Directory.GetDirectories(Yearfolder))
                {
                    string week = Path.GetFileName(weekfolder);
                    foreach (string wavfile in Directory.GetFiles(weekfolder, "*.wav", SearchOption.AllDirectories))
                    {
                        using (DCWebDataContext DC = new DCWebDataContext())
                        {
                            try
                            {
                                tblCustomDataEntry Vlog = null;
                                Vlog = (from t in DC.tblCustomDataEntries where t.Directory.StartsWith(weekfolder.Replace(@"E:\", "").Replace("\\", "/")) && t.Bestandsnaam == Path.GetFileName(wavfile) select t).First();
                                if (Vlog != null)
                                {
                                    found += 1;
                                    txtCheck.Text = "FOUND: " + found.ToString() + Environment.NewLine + "NOT FOUND: " + notfound.ToString();
                                    Application.DoEvents();

                                }
                                else
                                {
                                    notfound += 1;
                                    lsbErrors.Items.Add("NOT FOUND: " + wavfile);
                                    txtCheck.Text = "FOUND: " + found.ToString() + Environment.NewLine + "NOT FOUND: " + notfound.ToString();
                                    Application.DoEvents();


                                }

                            }
                            catch (Exception ex)
                            {
                                lsbErrors.Items.Add("EXception: " + wavfile);

                            }

                        }


                    }



                }


            }

        }

        private void btnGetAllWAVenMP3_Click(object sender, EventArgs e)
        {
            //  List<string> wavs = Directory.GetFiles(SourceVOICE2, "*.wav", SearchOption.AllDirectories).ToList();
            // List<string> MP3 = Directory.GetFiles(SourceVOICE2, "*.mp3", SearchOption.AllDirectories).ToList();
            List<string> PDFs = Directory.GetFiles(SourceVOICE2, "*.pdf", SearchOption.AllDirectories).ToList();
            //  File.WriteAllLines(@"U:\001_PER KLANT\ESSENT\WAVs.TXT", wavs.ToArray());
            //  File.WriteAllLines(@"U:\001_PER KLANT\ESSENT\MP3s.TXT", MP3.ToArray());
            //  File.WriteAllLines(@"U:\001_PER KLANT\ESSENT\PDFs.TXT", PDFs.ToArray());
            List<List<string>> listALL = new List<List<string>>();
            //listALL.Add(wavs);
            // listALL.Add(MP3);
            listALL.Add(PDFs);
            int a, b;
            a = 0;
            b = 1;
            foreach (List<string> list in listALL)
            {
                b = 1;
                txtCheck.Text = "LIJST " + a.ToString() + " ITEM : " + b.ToString();
                Application.DoEvents();
                a += 1;
                foreach (string item in list)
                {
                    {

                        txtCheck.Text = "LIJST " + a.ToString() + " ITEM : " + b.ToString();
                        Application.DoEvents();
                        b += 1;
                        string bestand = Path.GetFileName(item).Trim();
                        string dir = Path.GetDirectoryName(item).Replace("E:\\", "");
                        dir = dir.Replace("\\", "/").Replace("VOICE_LOGS_2", "VOICE_LOGS");
                        using (DCWebDataContext DC = new DCWebDataContext())
                        {
                            try
                            {
                                tblCustomDataEntry tblc = (from t in DC.tblCustomDataEntries where t.Bestandsnaam == bestand && t.Directory == dir && t.Barcode == null select t).First();
                                if (tblc.Barcode == null)
                                {
                                    tblc.Barcode = "20";
                                    DC.SubmitChanges();
                                }
                                else
                                {
                                    lsbErrors.Items.Add(bestand + ";REEDS VERWERKT " + tblc.Barcode);

                                }

                            }
                            catch (Exception ex)
                            {
                                lsbErrors.Items.Add(bestand + ";" + ex.Message);

                            }

                        }




                    }

                }
                MessageBox.Show("DONE");
            }
        }

        private void btnUpdatePDF_Click(object sender, EventArgs e)
        {
            StringBuilder files = new StringBuilder();
            int a = 0;
            List<tblCustomDataEntry> tblc = new List<tblCustomDataEntry>();
            using (DCWebDataContext DC = new DCWebDataContext())
            {

                try
                {
                   tblc = (from t in DC.tblCustomDataEntries where t.Barcode == null && t.Bestandsnaam.Contains(".png") select t).ToList();

                }
                catch (Exception ex)
                {
                    lsbErrors.Items.Add("NO PDFS" + ";" + ex.Message);

                }

            }
            //List<string> pdfs = File.ReadAllLines(@"U:\001_PER KLANT\ESSENT\PDFs.TXT").ToList();
            List<string> tifs = Directory.GetFiles(SourceVOICE2, "*.png", SearchOption.AllDirectories).ToList();
            foreach (string pdf in tifs)
            {
                a += 1;
                txtCheck.Text = a.ToString() + " van de " + tifs.Count().ToString();
                Application.DoEvents();
                string bestand = Path.GetFileName(pdf).Trim();
                string directory = Path.GetDirectoryName(pdf).Trim();
                directory = directory.Replace(@"E:\VOICE_LOGS_2\", "VOICE_LOGS/").Replace("\\", "/");
                tblCustomDataEntry cde = new tblCustomDataEntry();
                try
                {
                    cde = (from c in tblc where c.Bestandsnaam == bestand && c.Directory == directory select c).First();
                }
                catch (Exception ex)
                {
                    cde = null;

                }
                if (cde !=null)
                {
                    if (cde.Barcode == null)
                    {
                        files.AppendLine(cde.DataEntryID.ToString());
                        using (DCWebDataContext DC = new DCWebDataContext())
                        {

                            try
                            {
                                tblCustomDataEntry cdentry = (from t in DC.tblCustomDataEntries where t.DataEntryID == cde.DataEntryID select t).First();
                                cdentry.Barcode = "20";
                                DC.SubmitChanges();

                            }
                            catch (Exception ex)
                            {
                                lsbErrors.Items.Add("NO UPDATE" + cde.DataEntryID.ToString()) ;

                            }

                        }
                    }

                }

            }
            File.WriteAllText(@"U:\001_PER KLANT\ESSENT\UPDATED_png_IDs.TXT", files.ToString());
            MessageBox.Show("DONE");

        }

        private void btnOpenitems_Click(object sender, EventArgs e)
        {
            List<tblCustomDataEntry> tblc = new List<tblCustomDataEntry>();
            using (DCWebDataContext DC = new DCWebDataContext())
            {

                try
                {
                    tblc = (from t in DC.tblCustomDataEntries where t.Barcode == null && t.Dataveld8.Contains("VOICE_LOGS") select t).ToList();

                }
                catch (Exception ex)
                {
                    lsbErrors.Items.Add("NO FILES" + ";" + ex.Message);

                }

            }
            foreach (tblCustomDataEntry cd in tblc)
            {
                string file = cd.Directory.Replace("/", "\\").Replace("VOICE_LOGS","VOICE_LOGS_2") + "\\" + cd.Bestandsnaam.Trim();
                if (File.Exists(@"E:\"+file))
                {
                    using (DCWebDataContext DC = new DCWebDataContext())
                    {

                        try
                        {
                            tblCustomDataEntry tb = (from t in DC.tblCustomDataEntries where t.DataEntryID == cd.DataEntryID select t).First();
                            tb.Barcode = "20";
                            DC.SubmitChanges();

                        }
                        catch (Exception ex)
                        {
                            lsbErrors.Items.Add("NO UPDATE" + ";" + ex.Message);

                        }

                    }



                }


            }
            MessageBox.Show("DONE");
        }
    }
}