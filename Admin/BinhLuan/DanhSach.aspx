<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/TrangChu/Admin.master" AutoEventWireup="true" CodeFile="DanhSach.aspx.cs" Inherits="Admin_BinhLuan_DanhSach" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cssContent" runat="Server">
    <!-- datatable  -->
    <link href="../../assets/css/vendor/dataTables.bootstrap4.css" rel="stylesheet" type="text/css" />
    <link href="../../assets/css/vendor/responsive.bootstrap4.css" rel="stylesheet" type="text/css" />
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row">
        <div class="col-12">
            <asp:Label ID="debug" runat="server" Text=""></asp:Label>
            <asp:GridView ID="DanhSachBinhLuan" runat="server" CssClass="table dt-responsive nowrap w-100" AutoGenerateColumns="False" EmptyDataText="Chưa có dữ liệu">
                <Columns>
                    <%--<asp:HyperLinkField HeaderText="Mã Bình Luận" DataNavigateUrlFields="MaBinhLuan" DataNavigateUrlFormatString="CapNhat.aspx?MaBinhLuan={0}" DataTextField="MaBinhLuan"></asp:HyperLinkField>--%>
                    <asp:HyperLinkField HeaderText="Nội Dung" DataNavigateUrlFields="MaBaiViet" DataNavigateUrlFormatString="../../ChiTiet?Ma={0}" DataTextField="NoiDung"></asp:HyperLinkField>
                    <asp:HyperLinkField HeaderText="Ngày Đăng" DataNavigateUrlFields="MaBaiViet" DataNavigateUrlFormatString="../../ChiTiet?Ma={0}" DataTextField="NgayDang"></asp:HyperLinkField>
                    <asp:HyperLinkField HeaderText="Tên Người Dùng" DataNavigateUrlFields="MaBaiViet" DataNavigateUrlFormatString="../../ChiTiet?Ma={0}" DataTextField="TenNguoiDung"></asp:HyperLinkField>
                    <asp:HyperLinkField HeaderText="Tiêu Đề" DataNavigateUrlFields="MaBaiViet" DataNavigateUrlFormatString="../../ChiTiet?Ma={0}" DataTextField="TieuDe"></asp:HyperLinkField>
                    <asp:HyperLinkField Text="Xóa" HeaderText="Xóa" DataNavigateUrlFields="MaBinhLuan" DataNavigateUrlFormatString="Xoa.aspx?MaBinhLuan={0}">

                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                    </asp:HyperLinkField>

                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="Server">
    <!-- Datatables js -->
    <script src="../../assets/js/vendor/jquery.dataTables.min.js"></script>
    <script src="../../assets/js/vendor/dataTables.bootstrap4.js"></script>
    <script src="../../assets/js/vendor/dataTables.responsive.min.js"></script>
    <script src="../../assets/js/vendor/responsive.bootstrap4.min.js"></script>

    <!-- Datatable Init js -->
    <script src="../../assets/js/pages/demo.datatable-init.js"></script>
    <script>
        $(function () {
            $("[id*=DanhSachBinhLuan]").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    "order": [],
                    columnDefs: [
                        { "searchable": false, "targets": [2, 3] },
                        { "orderable": false, "targets": [2, 3] },
                    ]
                });
        });
    </script>
</asp:Content>