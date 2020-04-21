#pragma checksum "D:\VenuseraWork\ProjectAenne\AenneNotificationApp\NotificationApp\Pages\MapLocation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddf44594b24caae1d321c091f0a00a6608208e3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NotificationApp.Pages.Pages_MapLocation), @"mvc.1.0.razor-page", @"/Pages/MapLocation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/MapLocation.cshtml", typeof(NotificationApp.Pages.Pages_MapLocation), null)]
namespace NotificationApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\VenuseraWork\ProjectAenne\AenneNotificationApp\NotificationApp\Pages\_ViewImports.cshtml"
using NotificationApp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddf44594b24caae1d321c091f0a00a6608208e3a", @"/Pages/MapLocation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40a980b29a0ebe3bd56b2724dc87e55f695c789c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MapLocation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/MapTracking.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(7, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(15, 515, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "976f221634134b9bb5f0e468502c9844", async() => {
                BeginContext(21, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(104, 115, true);
                WriteLiteral("\r\n    <script src=\"https://maps.googleapis.com/maps/api/js?key=AIzaSyBSpSE7AWwQG5YQtl_uIoXW0VYedpSbX_0\"></script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(530, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(532, 2681, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ed530c3f2b649d29e55920ce5bfee60", async() => {
                BeginContext(538, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
                BeginContext(607, 2599, true);
                WriteLiteral(@"    <div class=""container"">
        <!-- Content Start -->
        <div class=""row"">
            <div class=""col-md-8"">
                <div style=""overflow: hidden;width:100%;height:500px;"">
                    <div id=""myMap"" style=""width:100%;height:500px;""></div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-5 col-sm-5"">
                <div class=""form-group"">
                    <div class=""md-form form-group"" style=""text-align:right"">
                        <label for=""inputClientId4MD"">:اسم السائق</label>
                        <label class=""form-control"" id=""inputVehicleId4MD"" placeholder=""اسم السائق""></label>

                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""md-form form-group"" style=""text-align:right"">
                        <label for=""inputClientId4MD"">:رقم جوال السائق</label>
                        <label class=""form-control"" id=""inputVehicleId4MD"" placeholder=""اسم");
                WriteLiteral(@" السائق""></label>

                    </div>
                </div>

                <div class=""form-group"">
                    <div class=""md-form form-group"" style=""text-align:right"">
                        <label for=""inputClientId4MD"">:نوعه السياره</label>
                        <label class=""form-control"" id=""inputVehicleId4MD"" placeholder=""اسم السائق""></label>

                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""md-form form-group"" style=""text-align:right"">
                        <label for=""inputClientId4MD"">:لون السياره</label>
                        <label class=""form-control"" id=""inputVehicleId4MD"" placeholder=""اسم السائق""></label>

                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""md-form form-group"" style=""text-align:right"">
                        <label for=""inputClientId4MD"">:المسافه الكليه</label>
                        <l");
                WriteLiteral(@"abel class=""form-control"" id=""inputVehicleId4MD"" placeholder=""اسم السائق""></label>

                    </div>
                </div>

                <div class=""form-group"">
                    <div class=""md-form form-group"" style=""text-align:right"">
                        <label for=""inputClientId4MD"">:الوقت الكلي</label>
                        <label class=""form-control"" id=""inputVehicleId4MD"" placeholder=""اسم السائق""></label>

                    </div>
                </div>

            </div>
        </div>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3213, 13, true);
            WriteLiteral("\r\n\r\n</html>\r\n");
            EndContext();
            BeginContext(3226, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9557fbb33a0740bd85158a14d352fefb", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3274, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3276, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccf3a06385444d5b828fdc59be83aea2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_MapLocation> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_MapLocation> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_MapLocation>)PageContext?.ViewData;
        public Pages_MapLocation Model => ViewData.Model;
    }
}
#pragma warning restore 1591