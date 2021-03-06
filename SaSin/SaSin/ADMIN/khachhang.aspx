﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/admin_master.Master" AutoEventWireup="true" CodeBehind="khachhang.aspx.cs" Inherits="SaSin.ADMIN.khachhang" %>
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
        .auto-style4 {
            width: 735px;
            height: 41px;
        }
        .auto-style5 {
            height: 41px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QUẢN LÍ&nbsp; KHÁCH HÀNG</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Mã Khách Hàng:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Txt_ma" runat="server" Enabled="False"></asp:TextBox>
                &nbsp;</td>
            <td class="auto-style5">Tên Khách Hàng :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="TextBox_ten" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Địa Chỉ:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_diachi" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">Số Điện Thoại :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_sdt" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style3"></td>
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
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DANH SÁCH KHÁCH HÀNG</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div class="text-center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="True" AllowSorting="True" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
        <Columns>
            <%--<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />--%>
            <asp:BoundField DataField="MaKH" HeaderText="Mã Khách Hàng" />
            <asp:BoundField DataField="TenKH" HeaderText="Tên Khách Hàng" />
            <asp:BoundField DataField="DiaChi" HeaderText="Địa Chỉ" />
            <asp:BoundField DataField="SDT" HeaderText="SĐT" />
            <asp:TemplateField HeaderText="Tính Năng">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClick="LinkButtonDelete_Click"
                                    OnClientClick="return confirm('Bạn có muốn xóa không?')">Xóa</asp:LinkButton>
                    <asp:HiddenField ID="HiddenFieldMaKH" runat="server" Value='<%#Eval("MaKH") %>' />
                
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" OnClick="LinkButtonEdit_Click">Sửa</asp:LinkButton>
                
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Button ID="Button2" runat="server" Text="Edit" />
        </EmptyDataTemplate>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

    </div>

   

</asp:Content>
