using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPatioDetranMg.Telas
{
    public partial class Upload : Form
    {
        public Robo Robo { get; set; }
        public string UltimoPathPlanilha { get; set; }

        public Upload()
        {
            InitializeComponent();
            Robo = Singleton<Robo>.Instanciar();
        }

        private void BtnUploadPlanilha_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecionar CSV";
            openFileDialog1.Filter = "Planilhas Excel | *.xls;*.xlsx";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                PathArquivo.Text = openFileDialog1.FileName;

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = null;

                try
                {
                    Planilhas.Items.Clear();
                    workbook = excel.Workbooks.Open(PathArquivo.Text);

                    foreach (Excel.Worksheet workSheet in workbook.Worksheets)
                    {
                        Planilhas.Items.Add(workSheet.Name);
                    }

                    Planilhas.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    Notificacao.Aviso("Erro ao ler arquivo");
                }
                finally
                {
                    workbook.Close(0);
                    excel.Quit();
                }
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            PathArquivo.Clear();
            Planilhas.Items.Clear();
            Planilhas.Text = "";
            LinhaInicial.Clear();
            ColunaPlaca.Clear();
            QuantidadeRegistros.Text = "0";
            dataGridView1.DataSource = null;
            UltimoPathPlanilha = "";
            Robo.Registros = new List<Registro>();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            Robo.Erros = "";
            FazerTudo();
        }

        private void BtnGerarPlanilha_Click(object sender, EventArgs e)
        {
            var nameError = "";
            if (Robo.Registros.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
                nameError = "Inicialização";
                try
                {
                    nameError = "Começo da linha";
                    Excel.Worksheet sheet = null;
                    nameError = "Criar workbook";
                    sheet = workbook.Sheets["Planilha1"];
                    sheet = workbook.ActiveSheet;
                    nameError = "Criação do cabeçalho";
                    for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                    {
                        sheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }

                    nameError = "Criação das linhas";

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    nameError = "Auto Fit";

                    excel.Columns.AutoFit();
                    nameError = "Salvar";
                    SaveFileDialog salvar = new SaveFileDialog();
                    salvar.Filter = "Excel Files|*.xlsx";

                    if (salvar.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(salvar.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        Notificacao.Informacao("Arquivo salvo com sucesso.");
                        Application.DoEvents();
                    }

                }
                catch
                {
                    Notificacao.Aviso("Erro ao gerar a planilha: " + nameError);
                }
                finally
                {
                    workbook.Close(0);
                    excel.Quit();
                }
            }
            else
            {
                Notificacao.Informacao("Não há registro para gerar a planilha");
            }
        }

        private void BtnPararRobo_Click(object sender, EventArgs e)
        {
            Robo.Parar = true;
        }

        private void LerPlanilha()
        {
            var linha = Convert.ToInt32(LinhaInicial.Text);

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = null;

            try
            {
                workbook = excel.Workbooks.Open(PathArquivo.Text);
                Excel.Worksheet sheet = workbook.Worksheets[Planilhas.Text];

                while (sheet.Range[ColunaPlaca.Text + linha].Text != "")
                {
                    Registro registro = new Registro();

                    registro.Placa = sheet.Range[ColunaPlaca.Text + linha].Text;

                    Robo.Registros.Add(registro);

                    linha++;
                }
            }
            catch (Exception ex)
            {
                Notificacao.Aviso(ex.Message);
            }
            finally
            {
                workbook.Close(0);
                excel.Quit();
            }
        }

        private bool ValidarCampos()
        {
            List<string> erros = new List<string>();

            if (PathArquivo.Text == "" || PathArquivo == null)
            {
                erros.Add("O caminho do arquivo é obrigatório");
            }

            if (Planilhas.Text == "" || Planilhas == null)
            {
                erros.Add("A planilha do arquivo é obrigatório");
            }

            if (ColunaPlaca.Text == "" || ColunaPlaca.Text == null)
            {
                erros.Add("A coluna da placa é um campo obrigatório");
            }

            if (LinhaInicial.Text == "" || LinhaInicial.Text == null)
            {
                erros.Add("A linha inicial é um campo obrigatório");
            }
            else
            {
                if (Convert.ToInt32(LinhaInicial.Text) <= 0)
                {
                    erros.Add("A linha inicial deve ser um numero maior que zero");
                }
            }

            if (erros.Count > 0)
            {
                foreach (var erro in erros)
                {
                    Notificacao.Informacao(erro);
                }

                return false;
            }

            return true;
        }

        private void DesenhaObjetosNaTela()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Linha", Type.GetType("System.Int32"));
            table.Columns.Add("Placa");
            table.Columns.Add("Nome / Proprietário");
            table.Columns.Add("Data Apr.");
            table.Columns.Add("Pátio Apr.");
            table.Columns.Add("Endereço Pátio");
            table.Columns.Add("Valor");
            table.Columns.Add("Status");

            int linha = 1;
            foreach (var registro in Robo.Registros)
            {
                var status = "";

                if (registro.Status == 0) status = "Não executado";
                if (registro.Status == 1) status = "Placa encontrada";
                if (registro.Status == 2) status = "Placa não encontrada";
                if (registro.Status == 3) status = "Erro na execução";


                table.Rows.Add(
                    linha,
                    registro.Placa,
                    registro.Proprietario,
                    registro.DataApr,
                    registro.PatioApreensao,
                    registro.EnderecoPatio,
                    registro.Valor,
                    status
                );
                linha++;
            }

            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 185;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[7].Width = 120;

            QuantidadeRegistros.Text = Robo.Registros.Count.ToString();
        }

        private async Task PrestartAsync()
        {
            if (await Robo.Inicia())
            {
                if (Robo.Erros.Contains("The HTTP request to the remote WebDriver") || Robo.Erros.Contains("timed out after 60 seconds"))
                {
                    Notificacao.Aviso("Ocorreu um erro na execução. Certifique-se de que a sessão do windows não seja bloqueada durante a execução.");
                }
                else
                {
                    Notificacao.Informacao("Todos os registros foram buscados no site");
                }
            }
            else
            {
                if (!Robo.Parar)
                {
                    await PrestartAsync();
                }
            }
        }

        private async Task FazerTudo()
        {
            if (ValidarCampos())
            {
                if (UltimoPathPlanilha != PathArquivo.Text && dataGridView1.Rows.Count == 0)
                {
                    LerPlanilha();
                    if (Robo.Registros.Where(x => x.Status != 1 && x.Status != 2).ToList().Count > 0)
                    {
                        UltimoPathPlanilha = PathArquivo.Text;
                    }
                }

                if (Robo.Registros.Where(x => x.Status != 1 && x.Status != 2).ToList().Count > 0)
                {
                    Robo.Parar = false;

                    await PrestartAsync();

                    DesenhaObjetosNaTela();
                }
                else
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        Notificacao.Informacao("Todos os registros ja foram executados");
                    }
                    else
                    {
                        Notificacao.Informacao("Não foram encontrados registros");
                    }
                }
            }
        }
    }
}
