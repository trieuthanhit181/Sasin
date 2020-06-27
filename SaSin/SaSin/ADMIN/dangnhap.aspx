<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dangnhap.aspx.cs" Inherits="SaSin.ADMIN.dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
        }
        .auto-style3 {
            height: 26px;
            text-align: center;
            color: #663300;
            background-color: #3399FF;
        }
        .auto-style5 {
            width: 156px;
            text-align: center;
        }
        .auto-style6 {
            width: 118px;
            text-align: right;
        }
        .auto-style7 {
            width: 315px;
            text-align: left;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            height: 26px;
            text-align: center;
            color: #663300;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body style="width: 100%">
    <form id="form1" runat="server">
        <div>
            

            <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="3">ĐĂNG NHẬP</td>
                </tr>
                <tr>
                    <td class="auto-style9" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">UserName&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">PassWord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8" colspan="3">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Đăng Nhập" />
                    </td>
                </tr>
            </table>
            

        </div>
    </form>
</body>
</html>
