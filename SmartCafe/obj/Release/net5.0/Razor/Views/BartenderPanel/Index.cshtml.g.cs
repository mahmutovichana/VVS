#pragma checksum "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ec030b775137722bf81aa95ba1730aaa207b28a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BartenderPanel_Index), @"mvc.1.0.view", @"/Views/BartenderPanel/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\_ViewImports.cshtml"
using SmartCafe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
using SmartCafe.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ec030b775137722bf81aa95ba1730aaa207b28a", @"/Views/BartenderPanel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"568aa064e73d545947419b6277d88513bebeabe2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BartenderPanel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartCafe.Models.Order>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/lagoonLogoWhiteTransparent.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Completed", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("﻿\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec030b775137722bf81aa95ba1730aaa207b28a7554", async() => {
                WriteLiteral(@"
    <title>Bartender Panel</title>
    <style>
        body {
            font-family: Montserrat sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('/images/abstractBackground2.png');
            color: black;
        }

        .header {
            background-color: transparent;
            color: white;
            padding: 0px 10px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .nav {
            list-style-type: none;
            display: flex;
            align-items: center;
        }

            .nav li {
                margin-right: 35px;
                margin-top: -50px;
                text-transform: uppercase;
                font-size: 14px;
            }

            .nav a {
                color: white;
                text-decoration: none;
                padding-bottom: 3px;
                border-bottom: 2px solid transparent;
  ");
                WriteLiteral(@"              transition: border-bottom-color 0.3s;
            }

                .nav a:hover {
                    border-bottom-color: #fff;
                }

        .logo img {
            max-width: 35%;
            margin-right: 0px;
            margin-left: 15px;
            margin-top: -20px;
        }

        .table-container {
            margin: 0 auto;
            max-width: 100%;
            background-color: transparent;
            border-radius: 5px;
            text-align: center;
        }

        table {
            font-family: Montserrat;
            margin: 0 auto;
            text-align: center;
            border-collapse: collapse;
            background-color: rgba(255, 255, 255, 0.8);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-left: auto;
            margin-right: auto;
            margin-bottom: 2%;
            width: fit-content;
        }

        th,
        td {
            border: 1px solid #dddddd;
      ");
                WriteLiteral(@"      text-align: center;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap; 
        }

        th {
            background-color: #f5f5f5;
            font-weight: bold;
        }

        tbody tr:nth-child(even) {
            background-color: #f9f9f9;
            vertical-align: center;
        }

        tbody tr:hover {
            background-color: #e0e0e0;
        }

        td:last-child {
            display: flex;
            justify-content: space-around;
        }


        .completed-checkbox {
            cursor: pointer;
        }

        .nav-item {
            list-style-type: none;
        }


        .edit,
        .completed,
        .delete {
            font-family: Montserrat;
            font-size: 12px;
            display: inline-block;
            padding: 8px 12px;
            border-radius: 4px;
            background-color: #007bff;
            color: #ffffff;
            text-decorat");
                WriteLiteral(@"ion: none;
            font-weight: bold;
            transition: background-color 0.3s;
        }

            .edit:hover,
            .completed:hover,
            .delete:hover {
                background-color: #0056b3;
            }


        /* Stilovi za carousel */
        .carousel {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            grid-gap: 40px;
            margin: 15%;
            margin-top: 0;
            margin-bottom: 40px;
        }

        .carousel-item {
            display: flex;
            width: fit-content;
            flex-direction: column;
            align-items: center;
            text-align: center;
            background-color: #f5f5f5;
            padding: 10px;
            margin: 2% auto;
            border-radius: 5px;
            transition: background-color 0.3s;
            cursor: pointer;
            text-decoration: none; 
            color: black; 
        }

            .carousel-item");
                WriteLiteral(@":hover {
                background-color: #e0e0e0;
            }

        .carousel-image {
            width: 200px;
            max-width: 100%;
            height: 200px;
            object-fit: cover; 
            border-radius: 5px;
        }


        .logout-button {
            display: inline-block;
            position: relative;
            z-index: 1;
            overflow: hidden;
            text-decoration: none;
            font-family: sans-serif;
            font-weight: 600;
            font-size: 2em;
            padding: 0.75em 1em;
            color: #FF5A5F;
            border: 0.15em solid #FF5A5F;
            border-radius: calc(0.75em + 0.5em + 0.15em);
            transition: 3s;
        }

            .logout-button:before,
            .logout-button:after {
                content: '';
                position: absolute;
                top: -1.5em;
                z-index: -1;
                width: 200%;
                aspect-ratio: 1;
     ");
                WriteLiteral(@"           border: none;
                border-radius: 40%;
                background-color: rgba(0, 0, 0, 0.7);
                transition: 4s;
            }

            .logout-button:before {
                left: -80%;
                transform: translate3d(0, 5em, 0) rotate(-340deg);
            }

            .logout-button:after {
                right: -80%;
                transform: translate3d(0, 5em, 0) rotate(390deg);
            }

            .logout-button:hover,
            .logout-button:focus {
                color: #FFFFFF;
            }

                .logout-button:hover:before,
                .logout-button:hover:after,
                .logout-button:focus:before,
                .logout-button:focus:after {
                    transform: none;
                    background-color: rgba(255, 90, 95, 0.75); /* Življa boja */
                }
    </style>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/al");
                WriteLiteral("l.min.css\">\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec030b775137722bf81aa95ba1730aaa207b28a14895", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"header\">\r\n        <div class=\"logo\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3ec030b775137722bf81aa95ba1730aaa207b28a15232", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n        <ul class=\"navbar-nav\">\r\n            <h1 style=\"margin-right:2px;\">Bartender Panel</h1>\r\n");
#nullable restore
#line 250 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
             if (SignInManager.IsSignedIn(User))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <li class=\"nav-item\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec030b775137722bf81aa95ba1730aaa207b28a16872", async() => {
                    WriteLiteral("\r\n                        <button type=\"submit\" class=\"logout-button\" style=\"font-family: Montserrat; text-transform: uppercase; font-size: 16px; color:white; text-decoration:none;\">LOG OUT</button>\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 253 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                                                                                      WriteLiteral(Url.Action("Index", "Home", new { area = "" }));

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 257 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </ul>
    </div>

    <div class=""table-container"">
    <table class=""table-fixed"">
        <thead>
            <tr>
                <th>ORDER ID</th>
                <th>TABLE NUMBER</th>
                <th>TIME RECEIVED</th>
                <th>PRICE</th>
                <th>ORDERED COCKTAILS</th>
                <th>COMPLETED</th>
                <th>OPTIONS</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 275 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
             if (Model != null)
            {
                var orderItems = ViewBag.OrderItems as IEnumerable<SmartCafe.Models.OrderItem>;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 278 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                 foreach (var item in Model.Where(order => !order.done))
                {
                    var orderItemForOrder = orderItems.Where(oi => oi.idOrder == item.id);

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 282 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.id));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 283 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.tableNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 284 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.orderTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 286 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                              
                                double totalPrice = orderItemForOrder.Sum(oi => oi.price);
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
#nullable restore
#line 289 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                       Write(totalPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                            <td>\r\n");
#nullable restore
#line 292 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                  
                                    var groupedItems = orderItemForOrder.GroupBy(oi => oi.Drink.name);
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 295 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                 foreach (var group in groupedItems)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <br>\r\n");
                WriteLiteral("                                    <span>");
#nullable restore
#line 299 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                      Write(group.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(" × ");
#nullable restore
#line 299 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                                        Write(group.Key);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
                WriteLiteral("                                    <br />\r\n");
#nullable restore
#line 302 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </td>\r\n\r\n                        <td>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec030b775137722bf81aa95ba1730aaa207b28a25072", async() => {
                    WriteLiteral("\r\n                                <input type=\"hidden\" name=\"id\"");
                    BeginWriteAttribute("value", " value=\"", 9244, "\"", 9260, 1);
#nullable restore
#line 307 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
WriteAttributeValue("", 9252, item.id, 9252, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                <input type=\"submit\" value=\"Completed\" class=\"completed\" /> \r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec030b775137722bf81aa95ba1730aaa207b28a27274", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 312 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                                                   WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" |\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec030b775137722bf81aa95ba1730aaa207b28a29665", async() => {
                    WriteLiteral("\r\n                                <input type=\"hidden\" name=\"id\"");
                    BeginWriteAttribute("value", " value=\"", 9674, "\"", 9690, 1);
#nullable restore
#line 314 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
WriteAttributeValue("", 9682, item.id, 9682, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                <input type=\"submit\" value=\"Delete\" class=\"delete\" />\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 319 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 319 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                 



            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n    </div>\r\n\r\n    <h1 style=\"align-content: center; color: white; text-align: center; \">Menu Items</h1>\r\n    <!-- kod za menu -->\r\n    <div class=\"carousel\">\r\n");
#nullable restore
#line 331 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
         if (ViewBag.Drinks != null)
        {
            var drinks = ViewBag.Drinks as IEnumerable<SmartCafe.Models.Drink>;
            foreach (var drink in drinks)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"carousel-item\">\r\n                    <h3>");
#nullable restore
#line 337 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                   Write(drink.name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                    <p>Price: ");
#nullable restore
#line 338 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
                         Write(drink.price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    <img");
                BeginWriteAttribute("src", " src=\"", 10456, "\"", 10509, 1);
#nullable restore
#line 339 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
WriteAttributeValue("", 10462, Url.Content("~/images/" + drink.name + ".jpg"), 10462, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 10510, "\"", 10527, 1);
#nullable restore
#line 339 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
WriteAttributeValue("", 10516, drink.name, 10516, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"carousel-image\" />\r\n                </div>\r\n");
#nullable restore
#line 341 "C:\Users\Administrator\Desktop\OOAD-G5-Tech-Trifecta\SmartCafe\Views\BartenderPanel\Index.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js\"></script>\r\n");
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
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartCafe.Models.Order>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
