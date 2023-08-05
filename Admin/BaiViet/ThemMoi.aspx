<%@ Page Title="Thêm bài viết" Language="C#" MasterPageFile="~/Admin/TrangChu/Admin.master" AutoEventWireup="true"
    CodeFile="ThemMoi.aspx.cs" Inherits="Admin_Default" ValidateRequest="false" %>

    <asp:Content ID="Content3" ContentPlaceHolderID="cssContent" runat="Server">
        <link href="../../assets/css/vendor/summernote-bs4.css" rel="stylesheet" type="text/css" />
        <style>
            .ExploreImage {
                width: 100px;
                height: 100px;
                margin: 5px;
            }
        </style>
    </asp:Content>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
        <div class="card">
            <div class="card-body">
                <div class="tab-content">
                    <div class="tab-pane show active" id="input-types-preview">
                        <div class="row">
                            <div class="col-8">
                                <asp:Label ID="debug" runat="server" Text=""></asp:Label>
                                <div class="form-group mb-3">
                                    <label for="simpleinput">
                                        Danh mục
                                        <span class="text-muted font-14"></span>
                                    </label>
                                    <asp:DropDownList ID="DanhMuc" runat="server" class="select2 form-control"
                                        AppendDataBoundItems="true" data-toggle="select2">
                                        <Items>
                                            <asp:ListItem Text="-----Chọn danh mục-----" Value="-1" />
                                        </Items>
                                    </asp:DropDownList>
                                    <%--<asp:TextBox ID="DanhMuc" runat="server" class="form-control">
                                        </asp:TextBox>--%>
                                </div>
                                <div class="form-group mb-3">
                                    <label for="simpleinput">
                                        Tiêu đề bài viết
                                        <span class="text-muted font-14">(Tối đa <code>50 </code>ký tự)
                                        </span>
                                    </label>
                                    <asp:TextBox ID="TieuDe" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group mb-3">
                                    <label for="simpleinput">
                                        Tóm tắt bài viết
                                        <span class="text-muted font-14">(Tối đa <code>50 </code>ký tự)
                                        </span>
                                    </label>
                                    <asp:TextBox ID="TomTat" runat="server" class="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button type="button" class="btn btn-warning" data-toggle="modal"
                                        data-target="#scrollable-modal">Lấy hình ảnh</asp:Button>
                                    <div class="modal fade" id="scrollable-modal" tabindex="-1" role="dialog"
                                        aria-labelledby="scrollableModalTitle" aria-hidden="true">
                                        <div class="modal-dialog modal-dialog-scrollable" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header d-flex">
                                                    <asp:FileUpload ID="FileImage" runat="server"
                                                        accept=".png,.jpg,.jpeg,.gif" />
                                                    <asp:TextBox ID="ChuThichFile" runat="server"
                                                        CssClass="form-control" placeholder="Chú thích ảnh">
                                                    </asp:TextBox>
                                                    <asp:Button Text="Tải lên" runat="server" ID="UploadImage"
                                                        CssClass="btn btn-success" OnClick="UploadImage_Click" />
                                                    <button type="button" class="close" data-dismiss="modal"
                                                        aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <h5 class="modal-header" id="scrollableModalTitle">Duyệt qua hình ảnh
                                                </h5>
                                                <div class="modal-body">
                                                    <asp:Repeater ID="RepeaterImages" runat="server">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image" runat="server" class="ExploreImage"
                                                                data-toggle="tooltip" title="Nhấn vào ảnh để lấy URL"
                                                                ImageUrl='<%# Container.DataItem %>' />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                                                        Đóng menu</button>
                                                </div>
                                            </div>
                                            <!-- /.modal-content -->
                                        </div>
                                        <!-- /.modal-dialog -->
                                    </div>
                                    <!-- /.modal -->
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="NoiDung" runat="server" TextMode="MultiLine">
                                    </asp:TextBox>
                                </div>


                            </div>
                            <div class="col-4">

                                <div class="card">
                                    <div class="card-body">
                                        <h4 class="header-title">Input Types</h4>
                                        <p class="text-muted font-14">
                                            Most common form control, text-based input fields. Includes support for all
                                            HTML5 types: <code>text</code>, <code>password</code>,
                                            <code>datetime</code>,
                                            <code>datetime-local</code>, <code>date</code>, <code>month</code>,
                                            <code>time</code>, <code>week</code>, <code>number</code>,
                                            <code>email</code>,
                                            <code>url</code>, <code>search</code>, <code>tel</code>, and
                                            <code>color</code>.
                                        </p>


                                        <div class="tab-content">
                                            <div class="tab-pane show active" id="input-types-preview">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group">
                                                            <asp:FileUpload ID="AnhThuNho" runat="server"
                                                                accept=".png,.jpg,.jpeg,.gif" />
                                                            <label for="simpleinput">
                                                                Chú thích hình ảnh <span class="text-muted font-14">(Văn
                                                                    bản thay thế khi <code>không tải được</code> hình
                                                                    ảnh)
                                                                </span>
                                                            </label>
                                                            <asp:TextBox ID="ChuThichAnh" runat="server"
                                                                class="form-control"></asp:TextBox>
                                                        </div>


                                                        <%--<form action="#" class="dropzone" id="myAwesomeDropzone"
                                                            data-plugin="dropzone"
                                                            data-previews-container="#file-previews"
                                                            data-upload-preview-template="#uploadPreviewTemplate">
                                                            <div class="fallback">
                                                            </div>
                                                            <div class="dz-message needsclick">
                                                                <i class="h1 text-muted dripicons-cloud-upload"></i>
                                                                <h3>Drop files here or click to upload.</h3>
                                                                <span class="text-muted font-13">(This is just a demo
                                                                    dropzone. Selected files are
                                                                    <strong>not</strong> actually uploaded.)</span>
                                                            </div>
                                                            </form>--%>
                                                    </div>
                                                </div>
                                                <!-- end row-->
                                            </div>
                                            <!-- end preview-->

                                        </div>
                                        <!-- end tab-content-->
                                    </div>
                                </div>
                                <!-- Preview -->
                                <div class="dropzone-previews mt-3" id="file-previews"></div>

                                <!-- file preview template -->
                                <div class="d-none" id="uploadPreviewTemplate">
                                    <div class="card mt-1 mb-0 shadow-none border">
                                        <div class="p-2">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <img data-dz-thumbnail src="#" class="avatar-sm rounded bg-light"
                                                        alt="">
                                                </div>
                                                <div class="col pl-0">
                                                    <a href="javascript:void(0);" class="text-muted font-weight-bold"
                                                        data-dz-name></a>
                                                    <p class="mb-0" data-dz-size></p>
                                                </div>
                                                <div class="col-auto">
                                                    <!-- Button -->
                                                    <a href="" class="btn btn-link btn-lg text-muted" data-dz-remove>
                                                        <i class="dripicons-cross"></i>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end row-->
                    </div>
                    <!-- end preview-->
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
                                <asp:Button ID="SubmitBack" Text="Lưu và thoát" runat="server" class="btn btn-primary"
                                    OnClick="SubmitBack_Click" />
                                <asp:Button ID="Submit" Text="Lưu tại trang" runat="server" class="btn btn-success"
                                    OnClick="Submit_Click" />
                                <button type="button" class="btn btn-secondary">
                                    <i class="dripicons-clockwise"></i>Làm lại</button>
                                <button type="button" class="btn btn-danger">
                                    <i class="dripicons-power"></i>Thoát</button>
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
                                <asp:Button ID="Button1" Text="Lưu và thoát" runat="server" class="btn btn-primary"
                                    OnClick="SubmitBack_Click" />
                                <asp:Button ID="Button2" Text="Lưu tại trang" runat="server" class="btn btn-success"
                                    OnClick="Submit_Click" />
                                <button type="button" class="btn btn-secondary">
                                    <i class="dripicons-clockwise"></i>Làm lại</button>
                                <button type="button" class="btn btn-danger">
                                    <i class="dripicons-power"></i>Thoát</button>
                            </div>
                        </div>
                        <!-- end row-->
                    </div>
                    <!-- end preview-->


                </div>
                <!-- end tab-content-->

            </div>
        </div>
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="Server">
        <!-- plugin js -->
        <script src="../../assets/js/vendor/dropzone.min.js"></script>
        <!-- init js -->
        <script src="../../assets/js/ui/component.fileupload.js"></script>

        <!-- plugin js -->
        <script src="../../assets/js/vendor/summernote-bs4.min.js"></script>
        <script>
            $(function () {
                $("#<%= NoiDung.ClientID %>").summernote({
                    placeholder: "Viết gì đó thật hay nào...", height: 230,
                });
                $('.form-group.note-form-group.note-group-select-from-files').remove();
            });
        </script>

        <script>
            $("img[id^=MainContent_RepeaterImages_Image_]").each(function (index) {
                $(this).on("click", function () {
                    var URLImage = $(this).attr('src');
                    $(this).attr("data-dismiss", "modal");
                    navigator.clipboard.writeText(URLImage)

                });
            });
        </script>


    </asp:Content>