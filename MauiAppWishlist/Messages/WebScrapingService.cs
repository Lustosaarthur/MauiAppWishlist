using AppWishList.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.Messages
{
    public class WebScrapingService
    {
        public static ScrapedProductData ScrapeProductData(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var productName = doc.DocumentNode.SelectSingleNode("//title")?.InnerText.Trim();
                var productPriceString = doc.DocumentNode.SelectSingleNode("//div[@class='G27FPf']")?.InnerText.Trim();
                var productDescription = doc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.Attributes["content"]?.Value?.Trim();
                var productImage = doc.DocumentNode.SelectSingleNode("//img[@class='IMAW1w']")?.Attributes["src"]?.Value?.Trim();

                if (productPriceString == null)
                {
                    Console.WriteLine("Preço não encontrado na página.");
                    return null;
                }

                var cleanedPriceString = new string(productPriceString.Where(c => char.IsDigit(c) || char.IsPunctuation(c)).ToArray());

                if (cleanedPriceString.Contains("-"))
                {
                    var priceParts = cleanedPriceString.Split('-');

                    if (double.TryParse(priceParts[0], NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out var minPrice))
                    {
                        return new ScrapedProductData
                        {
                            Name = productName ?? "Nome não encontrado",
                            Price = minPrice,
                            Description = productDescription ?? "Descrição não encontrada",
                            imagemUrl = productImage ?? "Não encontrado"
                        };
                    }
                }
                else
                {
                    if (double.TryParse(cleanedPriceString, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out var productPrice))
                    {
                        return new ScrapedProductData
                        {
                            Name = productName ?? "Nome não encontrado",
                            Price = productPrice,
                            Description = productDescription ?? "Descrição não encontrada",
                            imagemUrl = productImage ?? "Não encontrado"
                        };
                    }
                }

                Console.WriteLine("Erro ao converter a string do preço para double.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o web scraping: {ex.Message}");
                return null;
            }
        }
        public static ScrapedProductData ScrapeProductDataStore2(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                // Lógica específica para a segunda loja
                var productName = doc.DocumentNode.SelectSingleNode("//title")?.InnerText.Trim();
                var productPriceString = doc.DocumentNode.SelectSingleNode("//div[@class='product-intro__head-mainprice']//span")?.InnerText.Trim();
                var productDescription = doc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.Attributes["content"]?.Value?.Trim();
                var productImage = doc.DocumentNode.SelectSingleNode("//img[@class='lazyload crop-image-container__img']")?.Attributes["data-src"]?.Value?.Trim();

                if (productPriceString == null)
                {
                    Console.WriteLine("Preço não encontrado na página.");
                    return null;
                }

                var cleanedPriceString = CleanPriceString(productPriceString);

                if (double.TryParse(cleanedPriceString, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out var productPrice))
                {
                    return new ScrapedProductData
                    {
                        Name = productName ?? "Nome não encontrado",
                        Price = productPrice,
                        Description = productDescription ?? "Descrição não encontrada",
                        imagemUrl = productImage ?? "Não encontrado"
                    };
                }

                Console.WriteLine("Erro ao converter a string do preço para double.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o web scraping: {ex.Message}");
                return null;
            }
        }
        private static string CleanPriceString(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || char.IsPunctuation(c)).ToArray());
        }


    }

    public class ScrapedProductData
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required string Description { get; set; }
        public required string imagemUrl { get; set; }
    }
}
