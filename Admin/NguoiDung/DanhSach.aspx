<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/TrangChu/Admin.master" AutoEventWireup="true" CodeFile="DanhSach.aspx.cs" Inherits="Admin_NguoiDung_DanhSach" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cssContent" runat="Server">
    <!-- datatable  -->
    <link href="../../assets/css/vendor/dataTables.bootstrap4.css" rel="stylesheet" type="text/css" />
    <link href="../../assets/css/vendor/responsive.bootstrap4.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="debug" runat="server" Text=""></asp:Label>
            <asp:GridView ID="DanhSachNguoiDung" runat="server" CssClass="table dt-responsive nowrap w-100" AutoGenerateColumns="False" EmptyDataText="Chưa có dữ liệu">
                <Columns>
                    <asp:BoundField DataField="TenNguoiDung" HeaderText="Tên người dùng" />
                    <asp:BoundField DataField="Email" HeaderText="email" />
                    <asp:BoundField DataField="MatKhau" HeaderText="mật khẩu" />
                    <asp:ImageField DataImageUrlField="HinhDaiDien" DataImageUrlFormatString="../../Uploads/{0}" HeaderText="Hình Ảnh">
                        <ControlStyle Width="100px"></ControlStyle>
                    </asp:ImageField>
                    <asp:BoundField DataField="NgaySinh" HeaderText="Ngày Sinh" />
                    <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
                    <asp:BoundField DataField="Gioitinh" HeaderText="Giới tính" />
                    <asp:BoundField DataField="TenVaiTro" HeaderText="Vai trò" />
                    <asp:HyperLinkField Text="Sửa" HeaderText="Sửa" DataNavigateUrlFields="MaNguoiDung" DataNavigateUrlFormatString="CapNhat.aspx?MaNguoiDung={0}">

                        <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:HyperLinkField>

                    <asp:HyperLinkField Text="Xóa" HeaderText="Xóa" DataNavigateUrlFields="MaNguoiDung" DataNavigateUrlFormatString="Xoa.aspx?MaNguoiDung={0}">

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
