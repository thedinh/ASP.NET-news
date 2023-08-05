<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DanhMuc.aspx.cs" Inherits="DanhMuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:DataList ID="LayBaiVietTheoDanhMuc" runat="server">
        <ItemTemplate>
            <div class="card mb-0 mt-2">
                <div class="card-body">
                    <div class="media">
                        <a href="./chitiet.aspx?Ma=<%# Eval("MaBaiViet") %>">
                            <img src="Uploads/<%# Eval("hinhthunho") %>" alt="image"
                                class="mr-3 d-none d-sm-block avatar" width="250px"></a>
                        <div class="media-body">
                            <a href="./chitiet.aspx?Ma=<%# Eval("MaBaiViet") %>" class="mb-1 mt-0 text-dark"><%# Eval("tieude") %></a>
                            <div class="mt-2">
                                <a href="./DanhMuc.aspx?Ma=<%# Eval("MaBaiViet") %>"><%# Eval("TenDanhMuc") %></a>-<span><%# Eval("ngaydang", "{0:dd/M/yyyy H:mm:ss}") %></span>
                            </div>
                            <div class="mb-0 mt-2 text-muted">
                                <span class="font-italic"><b>"</b><%# Eval("tomtat") %></span><b>"</b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

