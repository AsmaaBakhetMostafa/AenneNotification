#pragma checksum "D:\VenuseraWork\ProjectAenne\AenneNotificationApp\NotificationApp\Pages\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27aca0f09e09f1cb124e08ede5b79673745c5ec4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NotificationApp.Pages.Pages_Contact), @"mvc.1.0.razor-page", @"/Pages/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Contact.cshtml", typeof(NotificationApp.Pages.Pages_Contact), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27aca0f09e09f1cb124e08ede5b79673745c5ec4", @"/Pages/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40a980b29a0ebe3bd56b2724dc87e55f695c789c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Contact : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(7, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(15, 222, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d5c5a7e8c7c43718f20f4306f8136e1", async() => {
                BeginContext(21, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
                BeginContext(106, 74, true);
                WriteLiteral("    <script src=\"https://maps.googleapis.com/maps/api/js?\"></script>\r\n    ");
                EndContext();
                BeginContext(180, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b2b5818723c455cb8affbc11cb5fe28", async() => {
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
                BeginContext(228, 2, true);
                WriteLiteral("\r\n");
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
            BeginContext(237, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(239, 3566, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3399ce61f6044c590c78fe481f68795", async() => {
                BeginContext(245, 3553, true);
                WriteLiteral(@"
    <input type=""text"" id=""txtLat"" />
    <input type=""text"" id=""txtLong"" />
    <input type=""button"" value=""Click to Display Map"" onclick=""DisplayGoogleMap()"" />
    <input type=""button"" id=""SendTripIdToDriver"" value=""Send Driver location"" onclick=""DisplayDriverLocation()"">

    <div id=""myDiv"" style=""width:100%;height:400px;""></div>

    <script type=""text/javascript"">

        let connection = new signalR.HubConnectionBuilder()
            .withUrl(""http://localhost:6715/tripNotification"",
                { skipNegotiation: true, transport: signalR.HttpTransportType.WebSockets })
            .build();
        setTimeout(() => {
            alert(""Hello"");
        }, 3000);
        connection.start()
            .then(res => {
                alert(""stared"");
                connection.invoke('GetClientId',135, 27.0338426000, 31.2796255000);
                connection.on('NotifiedGetClientId', (Client_Id, Driver_Pickup_Latt, Driver_Pickup_Long) => {
                    DisplayGoogleMa");
                WriteLiteral(@"p(Driver_Pickup_Latt, Driver_Pickup_Long);
                    connection.invoke('OnConnectedAsync', Client_Id, 4).then(res => {
                        alert(""dodo"");
                        connection.on(""NotifiedCurrenDriverLocationForClient"", (Driver_Id, Driver_Pickup_Long, Driver_Pickup_Latt) => {
                            DisplayGoogleMap(Driver_Pickup_Latt, Driver_Pickup_Long);
                        });
                    });
                })
            })
            .catch(err => {
                console.error(err);
            });

        connection.on(""NotifiedClientLocationUrl"", (LocationUrl) => { //Driver 

            alert(""push to client LocationUrl:"" + LocationUrl);
        });
        function DisplayDriverLocation() {
            connection.invoke(""GetCurrentLongAndLattForSpecificDriver"", 135, 30, 31.2796255000, 27.0338426000).then
                (res => {
                    alert(""driver location"");
                })
        }
  
        function Displa");
                WriteLiteral(@"yGoogleMap(Lat, Long) {

            directionsDisplay = new google.maps.DirectionsRenderer({
                suppressMarkers: true
            });

            var mapOptions = {
                zoom: 15,
                minZoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
            }

            map = new google.maps.Map(document.getElementById(""myDiv""), mapOptions);

            directionsDisplay.setMap(map);
            calcRoute();




            //  var Lat = document.getElementById(""txtLat"").value;
            //  var Long = document.getElementById(""txtLong"").value;
            //27.0338426000, 31.2796255000
            //Set the Latitude and Longitude of the Map
            var myAddress = new google.maps.LatLng(Lat, Long);

            //Create Options or set different Characteristics of Google Map
            var mapOptions = {
                center: myAddress,
                zoom: 15,
                minZoom: 15,
                mapTypeId: goog");
                WriteLiteral(@"le.maps.MapTypeId.ROADMAP
            };

            //Display the Google map in the div control with the defined Options
            var map = new google.maps.Map(document.getElementById(""myDiv""), mapOptions);

            //Set Marker on the Map
            var marker = new google.maps.Marker({
                position: myAddress,
                animation: google.maps.Animation.BOUNCE,
            });

            marker.setMap(map);
        }
    </script>
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
            BeginContext(3805, 11, true);
            WriteLiteral("\r\n</html>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Contact> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Contact> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Contact>)PageContext?.ViewData;
        public Pages_Contact Model => ViewData.Model;
    }
}
#pragma warning restore 1591
