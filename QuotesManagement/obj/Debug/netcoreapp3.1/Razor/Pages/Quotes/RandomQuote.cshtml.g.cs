#pragma checksum "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\Quotes\RandomQuote.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d240d6cb27eae30b7dce53eafa37a5d260c2575e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(QuotesManagement.Pages.Quotes.Pages_Quotes_RandomQuote), @"mvc.1.0.razor-page", @"/Pages/Quotes/RandomQuote.cshtml")]
namespace QuotesManagement.Pages.Quotes
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\_ViewImports.cshtml"
using QuotesManagement;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d240d6cb27eae30b7dce53eafa37a5d260c2575e", @"/Pages/Quotes/RandomQuote.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d253eec774b7fe15d372e15ea8e17fc3c56e003a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Quotes_RandomQuote : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h2>Random Quote</h2>\n\n\n<div>\n    <strong>ID: </strong> ");
#nullable restore
#line 9 "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\Quotes\RandomQuote.cshtml"
                     Write(Model.Quote.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n<div>\n    <strong>Title: </strong>");
#nullable restore
#line 12 "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\Quotes\RandomQuote.cshtml"
                       Write(Model.Quote.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n<div>\n    <strong>Content: </strong>");
#nullable restore
#line 16 "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\Quotes\RandomQuote.cshtml"
                         Write(Model.Quote.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n<div>\n    <strong>Author: </strong>");
#nullable restore
#line 20 "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\Quotes\RandomQuote.cshtml"
                        Write(Model.Quote.Author.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 20 "E:\Courses\Interviews\Sarahah\QuotesManagement\QuotesManagement\Pages\Quotes\RandomQuote.cshtml"
                                                      Write(Model.Quote.Author.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n<br />\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d240d6cb27eae30b7dce53eafa37a5d260c2575e5192", async() => {
                WriteLiteral("All Quotes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuotesManagement.Pages.Quotes.RandomQuoteModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QuotesManagement.Pages.Quotes.RandomQuoteModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QuotesManagement.Pages.Quotes.RandomQuoteModel>)PageContext?.ViewData;
        public QuotesManagement.Pages.Quotes.RandomQuoteModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
