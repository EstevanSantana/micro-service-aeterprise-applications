using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace NSE.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var mdrHasher = MD5.Create();
            var data = mdrHasher.ComputeHash(Encoding.Default.GetBytes(email));
            
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string MensagemEstoque(this RazorPage page, int quantidade)
        {
            return quantidade > 0 ? $"Apenas {quantidade} em estoque!" : "Produto esgotado";
        }

        public static string FormatoMoeda(this RazorPage page, decimal preco)
        {
            return preco > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", preco) : "Gratuido";
        }

        public static string UnidadesPorProduto(this RazorPage page, int unidade)
        {
            return unidade > 1 ? $"{unidade} unidades" : $"{unidade} unidade";
        }

        public static string SelectOptionsPorQuantidade(this RazorPage page, int quantidade, int valorSelecionado = 0)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < quantidade; i++)
            {
                var selected = "";
                if (i == valorSelecionado) selected = "selected";
                sb.Append($"<option {selected} value='{i}'> {i} </option>");
            }

            return sb.ToString();
        }
    }
}
