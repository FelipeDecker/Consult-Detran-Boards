using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPatioDetranMg
{
    public class Robo : IDisposable
    {
        private IWebDriver Driver { get; set; }
        private string BaseUrl { get; set; }
        public List<Registro> Registros { get; set; }
        public bool Parar { get; set; }
        public string Erros { get; set; }

        public Robo()
        {
            BaseUrl = "https://www.detran.mg.gov.br/veiculos/veiculos-removidos-para-o-patio-do-detran-mg/consultar-veiculos-removidos-para-o-patio-do-detran-mg";
            Registros = new List<Registro>();
        }

        private async Task<bool> TemMensagemErro()
        {
            try
            {
                await Task.Delay(1);
                IWebElement mensagemErro = Driver.FindElement(By.CssSelector(".alert.alert-danger.alert-dismissible.font-weight-bold"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> TemBotaoVoltar()
        {
            try
            {
                await Task.Delay(1);
                IWebElement buttonVoltar = Driver.FindElement(By.CssSelector(".container .mt-1 a"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task FecharNavegador()
        {
            try
            {
                await Task.Delay(1);
                Driver.Quit();
                Dispose();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Inicia()
        {
            try
            {
                await AbrirNavegador();

                var index = 1;

                var RegistrosNaoExecutados = Registros.Where(x => x.Status != 1 && x.Status != 2).ToList();

                foreach (var registro in RegistrosNaoExecutados)
                {
                    if (Parar)
                    {
                        await FecharNavegador();
                        return true;
                    }

                    if (index % 101 == 0)
                    {
                        await FecharNavegador();
                        await AbrirNavegador();
                    }


                    Registro registroSite = await BuscarRegistros(registro.Placa);

                    registro.Proprietario = registroSite.Proprietario;
                    registro.DataApr = registroSite.DataApr;
                    registro.PatioApreensao = registroSite.PatioApreensao;
                    registro.EnderecoPatio = registroSite.EnderecoPatio;
                    registro.Valor = registroSite.Valor;
                    registro.Status = registroSite.Status;

                    index++;
                }

                await FecharNavegador();

                return true;
            }
            catch (Exception ex)
            {
                Erros = ex.Message;
                await FecharNavegador();

                // serve para tratamento da função recusviva
                bool deuCertoDenovo = false;

                // caso o erro foi por conta da tela bloqueada
                if (Erros.Contains("The HTTP request to the remote WebDriver") || Erros.Contains("timed out after 60 seconds"))
                {
                    await FecharNavegador();
                    return true;
                }

                // se o botão de para não foi clicado
                if (!Parar)
                {
                    await FecharNavegador();
                    Erros = ex.Message;
                    deuCertoDenovo = await Inicia();
                }

                // serve para a recursão nao ficar no looping
                if (deuCertoDenovo)
                {
                    await FecharNavegador();
                    return true;
                }

                return false;
            }
        }

        private async Task<Registro> BuscarRegistros(string placa)
        {
            try
            {
                if (await TemBotaoVoltar()) await BotaoVoltarClique();

                await InputEscreverPlaca(placa);

                await ScriptInserirCaptcha();

                await BotaoPesquisarClique();

                Registro registro = new Registro();

                if (!await TemMensagemErro())
                {
                    return await BuscarDadosRegistro(registro);
                }
                else
                {
                    registro.NaoTemRegistro();
                    return registro;
                }
            }
            catch
            {
                await FecharNavegador();
                throw;
            }
        }

        private async Task BotaoVoltarClique()
        {
            await Task.Delay(750);
            IWebElement buttonVoltar = Driver.FindElement(By.CssSelector(".container .mt-1 a"));
            buttonVoltar.Click();
        }

        private async Task InputEscreverPlaca(string placa)
        {
            await Task.Delay(1200);
            IWebElement inputPlaca = Driver.FindElement(By.Id("placa"));
            inputPlaca.Clear();
            inputPlaca.SendKeys(placa);
        }

        private async Task ScriptInserirCaptcha()
        {
            await Task.Delay(750);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("document.querySelector('#g-recaptcha-response').value = '03AGdBq24xH97RuFwqEMfGXWBml0_mFUjghg6F18Ei9addMz2NjbuhGFvZm8LdOGvQ3p9BTJUGOJGcjBaofzCZ1zqd80pt5lq0efDk-L21qdQn05hrxsPxf5FdkABwy9cGVoGjsit73JF5QK3t5xUc1edi_NWS6jDqS_gkaFjwEn1TuZssAMmvxp5eNaNJI5YWTBM6I9nGK8oyktFDG42Hecj0FpdPFWntjMRDulUVmhg-FFHzzTLoeUAbb6tqQ4gykTMUHboPpDvUQkkU9ZS13ByCSvBidYRRB7c8MInC2bC6kZGBJLdsjA23lMeYJuxLo2zLLp4zZQX8sKU2AriI3N2uGyFxthyvrKRGjdqRjlzfOl_3GMyDDoMlcM_5f65hfigWJnQ2_yArOAphejJS2ao2kYpQTA-PBMY67DnMq_6FS-wSLGOIYXlSmTtHRf_-LLPmk9tiIJpGB6nT3QeBKzEUs6u9kN9Qxo_2waa8XTL0lMawX_IUid564Z4q0Lghmwm1gYx2URh-fHbKDHZ6ARPjus-ztd9FEX5YvYghJIbNqRsybAoYuIM'");
        }

        private async Task BotaoPesquisarClique()
        {
            await Task.Delay(750);
            IWebElement buttonPesquisa = Driver.FindElement(By.ClassName("btn-block"));
            buttonPesquisa.Click();
        }

        private async Task<Registro> BuscarDadosRegistro(Registro registro)
        {
            try
            {
                await Task.Delay(1);
                registro.Proprietario = Driver.FindElement(By.CssSelector("table.table-sm tbody tr td:nth-child(2)")).Text;
                var data = DateTime.Parse(Driver.FindElement(By.CssSelector("table.table-sm tbody tr td:nth-child(3)")).Text).ToString("dd/MM/yyyy");
                registro.DataApr = data == "01/01/0001" ? "" : data;
                registro.PatioApreensao = Driver.FindElement(By.CssSelector("table.table-sm tbody tr td:nth-child(4)")).Text;
                registro.EnderecoPatio = Driver.FindElement(By.CssSelector("table.table-sm tbody tr td:nth-child(5)")).Text;

                var valor = Driver.FindElement(By.CssSelector("table.table-sm tbody tr td:nth-child(6)")).Text;

                if (valor.Contains("R$"))
                {
                    valor = double.Parse(valor.Replace("R$ ", "")).ToString("F");
                }

                registro.Valor = valor;

                registro.TemRegistro();

                return registro;
            }
            catch (Exception)
            {
                registro.DeuProblema();
                return registro;
            }
        }

        private async Task AbrirNavegador()
        {
            try
            {
                await Task.Delay(1);
                InternetExplorerOptions config = new InternetExplorerOptions();
                config.RequireWindowFocus = false;
                config.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                config.EnableNativeEvents = true;
                config.EnsureCleanSession = true;
                config.InitialBrowserUrl = BaseUrl;
                Driver = new InternetExplorerDriver(config);
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
