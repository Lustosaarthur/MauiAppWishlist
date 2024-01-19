using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.Tests
{
    class testes
    {
        //public static ScrapedProductData ScrapeProductData(string url)
        //{
        //    try
        //    {
        //        var web = new HtmlWeb();
        //        var doc = web.Load(url);

        //        var productName = doc.DocumentNode.SelectSingleNode("//title")?.InnerText.Trim();
        //        var productPriceNode = doc.DocumentNode.SelectSingleNode("//div[@class='product-intro__head-mainprice']");

        //        if (productPriceNode != null)
        //        {
        //            // Extrair preço da parte visível
        //            var visiblePrice = productPriceNode.SelectSingleNode(".//div[contains(@class, 'discount')]//span")?.InnerText.Trim();

        //            // Extrair preço original (pode ser null)
        //            var originalPrice = productPriceNode.SelectSingleNode(".//del[contains(@class, 'del-price')]")?.InnerText.Trim();

        //            // Extrair desconto, se disponível
        //            var discountLabel = productPriceNode.SelectSingleNode(".//span[contains(@class, 'discount-label')]")?.InnerText.Trim();

        //            // Concatenar preço com desconto, se disponível
        //            var cleanedPriceString = $"{visiblePrice} {discountLabel}".Trim();

        //            // Limpar a string do preço
        //            cleanedPriceString = new string(cleanedPriceString.Where(c => char.IsDigit(c) || char.IsPunctuation(c)).ToArray());

        //            // Tentar converter a string do preço para double
        //            if (double.TryParse(cleanedPriceString, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out var productPrice))
        //            {
        //                var productDescription = doc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.Attributes["content"]?.Value?.Trim();
        //                var productImage = doc.DocumentNode.SelectSingleNode("//div[@class='cover-frame']")?.Attributes["index"]?.Value?.Trim();

        //                return new ScrapedProductData
        //                {
        //                    Name = productName ?? "Nome não encontrado",
        //                    Price = productPrice,
        //                    Description = productDescription ?? "Descrição não encontrada",
        //                    imagemUrl = productImage ?? "Não encontrado"
        //                };
        //            }
        //        }

        //        Console.WriteLine("Preço não encontrado na página.");
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Trate exceções conforme necessário.
        //        Console.WriteLine($"Erro durante o web scraping: {ex.Message}");
        //        return null;
        //    }
        //}

    }
}
