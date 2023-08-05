<%@ Page Title="Thêm mới danh mục" Language="C#" MasterPageFile="~/Admin/TrangChu/Admin.master" AutoEventWireup="true"
    CodeFile="ThemMoi.aspx.cs" Inherits="Admin_Default" %>

    <asp:Content ID="Content3" ContentPlaceHolderID="cssContent" runat="Server">
    </asp:Content>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
        <div class="row">
            <div class="col-12">
                <asp:Label ID="debug" runat="server" Text=""></asp:Label>
                <div class="card">
                    <div class="card-body">
                        <div class="tab-content">
                            <div class="tab-pane show active" id="input-types-preview">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="form-group mb-3">
                                            <label for="simpleinput">
                                                Tên danh mục
                                                <span class="text-muted font-14">(Tối đa <code>50 </code>ký tự)
                                                </span>
                                            </label>
                                            <asp:TextBox ID="TenDanhMuc" runat="server" class="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <!-- end row-->
                            </div>
                            <!-- end preview-->

                            <!-- end preview code-->
                        </div>
                        <!-- end tab-content-->

                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <div class="tab-content">
                            <div class="tab-pane show active" id="input-types-preview">
                                <div class="row">
                                    <div class="col-12">
                                        <asp:Button ID="SubmitBack" Text="Lưu và thoát" runat="server"
                                            class="btn btn-primary" OnClick="SubmitBack_Click" />
                                        <asp:Button ID="Submit" Text="Lưu tại trang" runat="server"
                                            class="btn btn-success" OnClick="Submit_Click" />
                                        <button type="button" class="btn btn-secondary"><i
                                                class="dripicons-clockwise"></i>Làm lại</button>
                                        <button type="button" class="btn btn-danger"><i
                                                class="dripicons-power"></i>Thoát</button>
                                    </div>
                                    <style>
                                        .btn-action-all {
                                            position: fixed;
                                            bottom: 70px;
                                            right: 5px;
                                            background-color: #333;
                                            padding: 10px;
                                            display: flex;
                                            flex-direction: column;
                                            z-index: 999;
                                            border-radius: 5px;
                                        }

                                        .btn-action-all>button {
                                            display: block;
                                            margin: 2px 0;
                                        }
                                    </style>
                                    <div class="btn-action-all">
                                        <asp:Button ID="Button1" Text="Lưu và thoát" runat="server"
                                            class="btn btn-primary" OnClick="SubmitBack_Click" />
                                        <asp:Button ID="Button2" Text="Lưu tại trang" runat="server"
                                            class="btn btn-success" OnClick="Submit_Click" />
                                        <button type="button" class="btn btn-secondary"><i
                                                class="dripicons-clockwise"></i>Làm lại</button>
                                        <button type="button" class="btn btn-danger"><i
                                                class="dripicons-power"></i>Thoát</button>
                                    </div>
                                </div>
                                <!-- end row-->
                            </div>
                            <!-- end preview-->


                        </div>
                        <!-- end tab-content-->

                    </div>
                </div>
            </div>
        </div>
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="Server">
        <script src="../../assets/js/pages/demo.datatable-init.js"></script>

    </asp:Content>