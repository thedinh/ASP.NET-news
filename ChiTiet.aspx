<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChiTiet.aspx.cs"
    Inherits="ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <div class="page-title-right">
                    <%= DateTime.Now.ToShortDateString() %>
                </div>
                <p class="page-title font-15">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Hyper</a></li>
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Pages</a></li>
                        <li class="breadcrumb-item active">Starter</li>
                    </ol>
                </p>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <asp:DataList ID="ChiTietNoiDung" runat="server">
                    <ItemTemplate>
                        <h2><%# Eval("tieude") %>
                            <%--tieude--%>
                        </h2>
                        <div class="detail-line-top d-flex justify-content-between">
                            <div class="detail-article-date">
                                <span><%# Eval("ngaydang","{0:dd/M/yyyy H:mm:ss}") %></span>
                            </div>
                            <div class="detail-share-top ">
                                <div>
                                    Lượt xem:  <%# Eval("luotxem") %>
                                </div>
                            </div>
                        </div>
                        <p class="font-20">
                            <em>
                                <%--tomtat--%>
                                <%# Eval("tomtat") %></em>
                        </p>
                        <div class="content-news">
                            <p
                                style="margin: 0px 0px 10px; color: rgb(68, 68, 68); line-height: 26px; font-family: Arial; font-size: 16px; background-color: rgb(255, 255, 255); text-align: justify">
                                <%# Eval("NoiDung") %>
                            </p>

                            <%--noidung--%>
                        </div>
                    </ItemTemplate>
                </asp:DataList>


                <div class="row mt-3">
                    <div class="col">
                                  <h5 class="mb-2 font-16">Comments</h5>
                        <asp:DataList ID="NoiDungBinhLuan" runat="server">
                            <ItemTemplate>
                         <div class="media mt-3 p-1">
                            <img src='Uploads/avatar/<%# Eval("hinhdaidien") %> ' class="mr-2 rounded-circle" height="36"
                                alt='<%# Eval("tennguoidung") %>'>
                            <div class="media-body">
                                <h5 class="mt-0 mb-0">
                                    <span class="float-right text-muted font-12"><%# Eval("ngaydang","{0:dd/M/yyyy H:mm:ss}") %></span>
                                    <%# Eval("tennguoidung") %>
                                </h5>
                                <p class="mt-1 mb-0 text-muted">
                                    <%# Eval("noidung") %>
                                </p>
                            </div>
                        </div>
                        <hr>
                            </ItemTemplate>
                        </asp:DataList>
                        <!-- end comment -->
<%--                        <div class="media mt-2 p-1">
                            <img src="assets/images/users/avatar-5.jpg" class="mr-2 rounded-circle" height="36"
                                alt="Dominc B">
                            <div class="media-body">
                                <h5 class="mt-0 mb-0">
                                    <span class="float-right text-muted font-12">3:30am</span>
                                    Gary Somya
                                </h5>
                                <p class="mt-1 mb-0 text-muted">
                                    @Arya FYI..I have created some general guidelines last year.
                                </p>
                            </div>
                        </div>
                        <!-- end comment-->

                        <hr>--%>
                    </div>
                    <!-- end col -->
                </div>
                <div class="row mt-2">
                    <div class="col">
                        <div class="border rounded">
                            <form  class="comment-area-box" runat="server">
                               <%-- <textarea rows="3" class="form-control border-0 resize-none"
                                    placeholder="Your comment..."></textarea>--%>
                                <asp:TextBox runat="server" CssClass="form-control border-0 resize-none" ID="txtNoiDungBinhLuan" Font-Overline="False" TextMode="MultiLine" Height="100px" />  
                                <div class="p-2 bg-light">
                                    <div class="float-right">
                                       <%-- <button type="submit" class="btn btn-sm btn-success" runat="server" id="SubmitBinhLuan" OnClick="SubmitBinhLuan_Click">
                                            </button>--%>
                                        <%--<asp:Button ID="SubmitBinhLuan" runat="server" Text="Submit" CssClass="btn btn-sm btn-success"/>--%>
                                        <asp:Button ID="SubmitBinhLuan" runat="server" Text="Button" CssClass="btn btn-sm btn-success" OnClick="SubmitBinhLuan_Click1" />
                                    </div>
                                    <div>
                                        <a href="#" class="btn btn-sm px-1 btn-light"><i
                                            class="uil uil-cloud-upload"></i></a>
                                        <a href="#" class="btn btn-sm px-1 btn-light"><i class="uil uil-at"></i></a>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <!-- end .border-->
                    </div>
                    <!-- end col-->
                </div>
                <!-- tin liên quan  -->
                <h4 class="header-title mt-3 font-weight-bolder font-24 font-italic badge badge-danger">Tin liên
                        quan</h4>
                <asp:DataList ID="TinLienQuan" runat="server">
                    <ItemTemplate>
                        <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="./chitiet.aspx?Ma=<%# Eval("MaBaiViet") %>">
                                <img src="Uploads/<%# Eval("hinhthunho") %>" alt="image"
                                    class="mr-3 d-none d-sm-block avatar" width="250px"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark"><%# Eval("tieude") %></a>
                                <div class="mt-2">
                                    <a href="#"><%# Eval("tendanhmuc") %></a> <span><%# Eval("ngaydang", "{0:dd/M/yyyy H:mm:ss}") %></span>
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
                <!-- Tin mới nhất -->
                <h4 class="header-title mt-3 font-weight-bolder font-24 font-italic badge badge-primary">Tin mới
                        nhất
                </h4>
                <asp:DataList ID="TinMoiNhat" runat="server">
                    <ItemTemplate>
                        <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="./chitiet.aspx?Ma=<%# Eval("MaBaiViet") %>">
                                <img src="Uploads/<%# Eval("hinhthunho") %>" alt="image"
                                    class="mr-3 d-none d-sm-block avatar" width="250px"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark"><%# Eval("tieude") %></a>
                                <div class="mt-2">
                                    <a href="#"><%# Eval("tendanhmuc") %></a> <span><%# Eval("ngaydang", "{0:dd/M/yyyy H:mm:ss}") %></span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b><%# Eval("tomtat") %></span><b>"</b>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
