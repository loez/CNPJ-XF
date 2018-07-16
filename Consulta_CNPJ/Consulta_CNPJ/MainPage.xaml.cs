using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Consulta_CNPJ.Servico;
using Plugin.Connectivity;
namespace Consulta_CNPJ
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void BtnConsulta_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                Resultado.IsVisible = true;

                if ((txtcnpj.Text.Length < 14) || (txtcnpj.Text.Contains("-")) || (txtcnpj.Text.Contains(".")))
                {
                    DisplayAlert("Erro", "Favor informar o CNPJ de forma correta", "OK");
                }
                else
                {
                    try
                    {
                        string cnpj = txtcnpj.Text.Trim();
                        CNPJ cnpjresult = Buscar.Buscarcnpj(cnpj);
                        var ultatt = new Label { Text = "Última atualização: " + cnpjresult.ultima_atualizacao };
                        Principal.Children.Add(ultatt);
                        var ncnpj = new Label { Text = "CNPJ: " + cnpjresult.cnpj };
                        Principal.Children.Add(ncnpj);
                        var rsocial = new Label { Text = "Razão Social: " + cnpjresult.nome };
                        Principal.Children.Add(rsocial);
                        var nfantasia = new Label { Text = "Nome Fantasia: " + cnpjresult.fantasia };
                        Principal.Children.Add(nfantasia);
                        var situacao = new Label { Text = "Situação: " + cnpjresult.situacao };
                        Principal.Children.Add(situacao);
                        var abertura = new Label { Text = "Data Abertura: " + cnpjresult.abertura };
                        Principal.Children.Add(abertura);
                        var end = new Label { Text = "Endereço: " + cnpjresult.logradouro + " " + cnpjresult.numero + " " + cnpjresult.complemento };
                        Principal.Children.Add(end);
                        var bairro = new Label { Text = "Bairro: " + cnpjresult.bairro };
                        Principal.Children.Add(bairro);
                        var cidade = new Label { Text = "Cidade: " + cnpjresult.municipio };
                        Principal.Children.Add(cidade);
                        var estado = new Label { Text = "Estado: " + cnpjresult.uf };
                        Principal.Children.Add(estado);
                        var cep = new Label { Text = "CEP: " + cnpjresult.cep };
                        Principal.Children.Add(cep);
                        var telefone = new Label { Text = "Telefone(s): " + cnpjresult.telefone };
                        Principal.Children.Add(telefone);
                        var email = new Label { Text = "Email(s): " + cnpjresult.email };
                        Principal.Children.Add(email);
                        var capsocial = new Label { Text = "Capital Social: " + cnpjresult.capital_social };
                        Principal.Children.Add(capsocial);

                        var ativi = new Label { Text = "Atividade Principal:", FontAttributes = FontAttributes.Bold };
                        Principal.Children.Add(ativi);

                        for (int a = 0; a < cnpjresult.atividade_principal.Count; a++)
                        {
                            var atprincipal = new Label { Text = cnpjresult.atividade_principal[0].text };
                            //var atprincipal2 = new Label { Text = cnpjresult.atividade_principal[a].code };
                            Principal.Children.Add(atprincipal);
                        }


                        var quadro = new Label { Text = "Quadro Social:", FontAttributes = FontAttributes.Bold };
                        Principal.Children.Add(quadro);

                        for (int i = 0; i < cnpjresult.qsa.Count; i++)
                        {
                            var socio = new Label { Text = "Nome:", FontAttributes = FontAttributes.Bold };

                            var nome = new Label { Text = cnpjresult.qsa[i].nome };
                            Principal.Children.Add(socio);
                            Principal.Children.Add(nome);
                        }
                        var sec = new Label { Text = "Atividades Secundárias", FontAttributes = FontAttributes.Bold };
                        Principal.Children.Add(sec);

                        for (int b = 0; b < cnpjresult.atividades_secundarias.Count; b++)
                        {

                            var atsec = new Label { Text = cnpjresult.atividades_secundarias[0].text };

                            Principal.Children.Add(atsec);
                        }
                    }
                    catch (Exception Erro)
                    {
                        DisplayAlert("Erro", Erro.Message, "OK");
                    }
                }
            }else
            {
                DisplayAlert("Atenção", "Favor verificar se você está conectado na Internet", "OK");
            }
        }
      
    }
}
