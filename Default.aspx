<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            .bg-carousel {
                background-color: #313a46;
            }
        </style>
        <div class="row">
            <div class="col-12">
                <div id="carouselExampleCaption" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner" role="listbox">
                        <asp:Repeater ID="carousel" runat="server">
                            <ItemTemplate>
                                 <div class="carousel-item bg-carousel <%# Container.ItemIndex == 0 ? "active" : ""%>">
                            <div class="d-flex">
                                <a href="/chitiet.aspx?Ma=<%# Eval("mabaiviet") %>" class="w-50">
                                    <img src="Uploads/<%# Eval("hinhthunho") %>" alt="..." width="100%" height="100%">
                                </a>
                                <div class="w-50 pl-2">
                                             <a href="/chitiet.aspx?Ma=<%# Eval("mabaiviet") %>">
                                        <h3 class="font-14"><%# Eval("tieude") %></h3>
                                        <p class="text-truncate text-white">
                                            <%# Eval("tomtat") %>
                                        </p>
                                    </a>
                                    <a href="./Danhmuc.aspx?Ma=<%# Eval("mabaiviet") %>"> <%# Eval("tendanhmuc") %> - <%#  Eval("ngaydang", "{0:dd/M/yyyy H:mm:ss}") %></a>
                                </div>
                            </div>
                        </div> 
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleCaption" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleCaption" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:DataList runat="server" ID="NextNews">
                    <ItemTemplate>
                        <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="/chitiet.aspx?Ma=<%# Eval("mabaiviet") %>">
                                <img src="Uploads/<%# Eval("hinhthunho") %>" alt="image"
                                    class="mr-3 d-none d-sm-block avatar" width="200px" ></a>
                            <div class="media-body">
                                <a href="/chitiet.aspx?Ma=<%# Eval("mabaiviet") %>" class="mb-1 mt-0 text-dark"><%# Eval("tieude") %></a>
                                <div class="mt-2">
                                    <a href="./Danhmuc.aspx?Ma=<%# Eval("mabaiviet") %>"><%# Eval("tendanhmuc") %></a>-<span><%# Eval("ngaydang", "{0:dd/M/yyyy H:mm:ss}") %></span>
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
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center mt-3 mb-3">
                <button type="button" class="btn btn-info btn-rounded ">Xem thêm</button>
            </div>
        </div>

    </asp:Content>