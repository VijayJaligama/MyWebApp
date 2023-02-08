using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages
{
    public class Challenge2Model : PageModel
    {
        // Property to store articles
        public List<string>? Articles { get; set; }

        // Method to get articles from the website and store it in Articles property
        public async Task OnGet()
        {
            // Create a new instance of HttpClient
            using var client = new HttpClient();
            // URL to fetch articles from
            var url = "https://news.ycombinator.com/";
            // Get the response from the URL
            var response = await client.GetAsync(url);
            // Read the response content as a string
            var html = await response.Content.ReadAsStringAsync();

            // Create a new instance of HtmlDocument
            var htmlDoc = new HtmlDocument();
            // Load the HTML content into the document
            htmlDoc.LoadHtml(html);
            // Select article nodes using an XPath expression
            var articleNodes = htmlDoc.DocumentNode.SelectNodes("//table[@id='hnmain']//tr[@class='athing']");

            // Initialize the Articles property with a new list
            Articles = new List<string>();
            // Check if article nodes were found
            if (articleNodes != null)
            {
                // Loop through the first 20 article nodes, or all nodes if there are less than 20
                for (int i = 0; i < 20 && i < articleNodes.Count; i++)
                {
                    // Get the title node
                    var titleNode = articleNodes[i];
                    // Add the outer HTML of the title node to the Articles list
                    Articles.Add(titleNode.OuterHtml.Trim());
                }
            }
        }
    }
}