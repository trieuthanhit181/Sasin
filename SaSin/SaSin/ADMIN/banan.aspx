<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/admin_master.Master" AutoEventWireup="true" CodeBehind="banan.aspx.cs" Inherits="SaSin.ADMIN.banan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 735px;
        }
        .auto-style2 {
            width: 735px;
            height: 32px;
        }
        .auto-style3 {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QUẢN LÍ BÀN ĂN</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Mã Bàn Ăn :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tb_maban" runat="server" Enabled="False"></asp:TextBox>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Bàn Ăn Số:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox_banso" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Số Ghế:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:TextBox ID="TextBox_soghe" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="THÊM" Width="123px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="CẬP NHẬT" Width="120px" />
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DANH SÁCH BÀN ĂN</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="text-center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="True" AllowSorting="True" OnRowEditing="GridView1_RowEditing" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />--%>
            <asp:BoundField DataField="MaBan" HeaderText="Mã Bàn Ăn " />
            <asp:BoundField DataField="BanSo" HeaderText="Bàn Số " />
            <asp:BoundField DataField="SoGhe" HeaderText="Số Ghế " />
            <asp:TemplateField HeaderText="Tính Năng">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClick="LinkButtonDelete_Click"
                                    OnClientClick="return confirm('Bạn có muốn xóa không ?')">Xóa</asp:LinkButton>
                    <asp:HiddenField ID="HiddenFieldMaBan" runat="server" Value='<%#Eval("MaBan") %>' />
                
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" OnClick="LinkButtonEdit_Click">Sửa</asp:LinkButton>
                
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <EmptyDataTemplate>
            <asp:Button ID="Button2" runat="server" Text="Edit" />
        </EmptyDataTemplate>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    </div>

   

</asp:Content>

