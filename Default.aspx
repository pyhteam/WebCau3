<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebCau3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">
            ASP.NET is a free web framework for building great Web sites and Web applications using
                HTML, CSS, and JavaScript.
        </p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Id"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Họ Tên"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtHoten" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Gioi Tinh"></asp:Label>
                <asp:RadioButton ID="rdbGioiTinhNam" runat="server" Text="Nam" />
                <asp:RadioButton ID="rdbGioiTinhNu" runat="server" Text="Nu" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Xí nghiệp"></asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddbXiNghiep" runat="server"
                    DataSourceID="SqlDataSource1" DataTextField="TenXiNghiep" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:Cau3ASPNETConnectionString %>"
                    SelectCommand="SELECT * FROM [XiNghiep]"></asp:SqlDataSource>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Tiêm vacxin"></asp:Label>
                <asp:RadioButton ID="rdbTiem1" runat="server" Text="Đã Tiêm" />
                <asp:RadioButton ID="rdbTiem2" runat="server" Text="Chưa Đã Tiêm" />
            </div>
            <!-- button add edit delete -->
            <div class="form-group">
                <asp:Button ID="btnAdd" runat="server" Text="Thêm" OnClick="btnAdd_Click"
                    CssClass="btn btn-success" />
                <asp:Button ID="btnEditMan" runat="server" Text="Edit" OnClick="btnEditMan_Click"
                    CssClass="btn btn-primary" />
                <asp:Button ID="btnNamTiemVacXin" runat="server" Text="Nam Đã Tiêm"
                    CssClass="btn btn-primary" OnClick="btnNamTiemVacXin_Click" />
                <asp:Button ID="SoLuongNguoiDaTien" runat="server" Text="Sô lượng đã tiêm"
                    CssClass="btn btn-primary" OnClick="SoLuongNguoiDaTien_Click" />

            </div>
        </div>
        <div class="col-md-8">
            <!-- gird view -->
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                DataSourceID="SqlDataSource2" CssClass=" table table-responsive table-hover" Width="818px"
                OnSelectedIndexChanged="gvList_SelectedIndexChanged" AllowSorting="True" AutoGenerateSelectButton="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                        SortExpression="Id" />
                    <asp:BoundField DataField="HoTen" HeaderText="HoTen" SortExpression="HoTen" />
                    <asp:BoundField DataField="XiNghiepId" HeaderText="XiNghiepId" SortExpression="XiNghiepId" />
                    <asp:BoundField DataField="GioiTinh" HeaderText="GioiTinh" SortExpression="GioiTinh" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Sửa" OnClick="btnEdit_Click"
                                CssClass="btn btn-info" />
                            <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click"
                                CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <SelectedRowStyle BackColor="#003300" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                ConnectionString="<%$ ConnectionStrings:Cau3ASPNETConnectionString %>"
                SelectCommand="SELECT * FROM [TiemVacXin]"></asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
