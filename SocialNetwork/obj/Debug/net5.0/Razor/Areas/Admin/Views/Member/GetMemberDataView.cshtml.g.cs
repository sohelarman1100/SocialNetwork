#pragma checksum "G:\test\SocialNetwork\Areas\Admin\Views\Member\GetMemberDataView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "821d3fbb450074e5e81822e1c3b72e2ec3d03906"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Member_GetMemberDataView), @"mvc.1.0.view", @"/Areas/Admin/Views/Member/GetMemberDataView.cshtml")]
namespace AspNetCore
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
#line 1 "G:\test\SocialNetwork\Areas\Admin\Views\_ViewImports.cshtml"
using SocialNetwork;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\test\SocialNetwork\Areas\Admin\Views\_ViewImports.cshtml"
using SocialNetwork.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\test\SocialNetwork\Areas\Admin\Views\_ViewImports.cshtml"
using SocialNetwork.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"821d3fbb450074e5e81822e1c3b72e2ec3d03906", @"/Areas/Admin/Views/Member/GetMemberDataView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c973aa138b64dfc10dea0e0ed60d52d7a4b86a23", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Member_GetMemberDataView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GetMemberModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\test\SocialNetwork\Areas\Admin\Views\Member\GetMemberDataView.cshtml"
  
    ViewData["Title"] = "GetMemberDataView";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/admin/plugins/datatables-bs4/css/dataTables.bootstrap4.css\">\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/admin/plugins/datatables/jquery.dataTables.js""></script>
    <script src=""/admin/plugins/datatables-bs4/js/dataTables.bootstrap4.js""></script>
    <script>
        $(function () {
            $('#Members').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                ""ajax"": ""/Admin/Member/GetMemberData"",
            });
        });
    </script>
");
            }
            );
            WriteLiteral(@"
<!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Available Members</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                    <li class=""breadcrumb-item active"">Members</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">All Available Members</h3>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <table id=""Members"" class=""table table-bordered table-hover"">");
            WriteLiteral(@"
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Date of Birth</th>
                                <th>Address</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Name</th>
                                <th>Date of Birth</th>
                                <th>Address</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</section>
<!-- /.content -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetMemberModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
